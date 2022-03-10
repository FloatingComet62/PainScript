namespace Interpreter{
    class Translate{
        static public void UpperCase(int input){
            List<string> translation = new List<string>(new string[]{" ", "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"});
                        try{
                string output = translation[input];
                Interpreter.AppendToOutput(output);
            }
            catch (System.Exception){
                Funcs.Sys.Exit(1, "Error: Invalid input");
            }
        }
        static public void LowerCase(int input){
            List<string> translation = new List<string>(new string[]{" ", "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"});
            try{
                string output = translation[input];
                Interpreter.AppendToOutput(output);
            }
            catch (System.Exception){
                Funcs.Sys.Exit(1, "Error: Invalid input");
            }
        }
        static public void SpecialChar(int input){
        List<string> translation = new List<string>(new string[]{"~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "`", "[", "]", "{", "}", "|", "\\", ";", ":", "\"", "'", "<", ">", ",", ".", "?", "/", "\n"});
            try{
                string output = translation[input];
                Interpreter.AppendToOutput(output);
            }
            catch (System.Exception){
                Funcs.Sys.Exit(1, "Error: Invalid input");
            }
        }
    }
    public class Interpreter{
        static int pointer = 0;
        static string output = "";
        static public void Interpret(char param, Dictionary<int, int> storage, char[] paras, int index){
            // Funcs.Util.Text(param.ToString()+"-"+index.ToString()+"-"+pointer.ToString());
            if(param == '>'){
                if(!storage.ContainsKey(pointer+1)){
                    storage.Add(pointer+1, 0);
                }
                pointer++;
            }else if(param == '<'){
                if(pointer == 0){
                    Funcs.Sys.Exit(1, "Error: Can't go into negetive memory");
                }else{
                    pointer--;
                }
            }else if(param == '+'){
                storage[pointer]++;
            }else if(param == '-'){
                storage[pointer]--;
            }else if(param == '\''){
                Translate.LowerCase(storage[pointer]);
            }else if(param == '\"'){
                Translate.UpperCase(storage[pointer]);
            }else if(param == ']'){
                output += storage[pointer];
            }else if(param == '['){
                Translate.SpecialChar(storage[pointer]);
            }else if(param == '.'){
                string? input = Console.ReadLine();
                if(input == null){
                    Funcs.Sys.Exit(1, "Error: Invalid input");
                }else{
                    try{
                        storage[pointer] += int.Parse(input);
                    }catch{
                        Funcs.Sys.Exit(1, "Error: Couldn't convert input to integer");
                    }
                }
            }else if(param == '{'){
                int internalLoops = 0;
                int loopEndIndex = 0;
                int loopPointer = pointer;
                for(int i = index; i < paras.Length; i++){
                    if(loopEndIndex != 0){
                        i = paras.Length;
                        break;
                    }
                    if(paras[i] == '{'){
                        internalLoops++;
                    }
                    if(paras[i] == '}'){
                        internalLoops--;
                        if(internalLoops == 0){
                            loopEndIndex = i;
                        }
                    }
                }

                char[] loopItems = new char[loopEndIndex - index];
                for(int i = index+1; i < loopEndIndex; i++){
                    loopItems[i-(index+1)] = paras[i];
                }
                while(storage[loopPointer]!=0){
                    loopItems.ToList().ForEach(x => {
                        Interpret(x, storage, paras, index);
                    });
                }
                Program.Program.SetI(loopEndIndex);
            }
        }
        static public void AppendToOutput(string input){
            output += input;
        }

        static public string GetOutput(){
            return output;
        }
    }    
}