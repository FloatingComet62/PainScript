namespace Interpreter{
    class Translate{
        static public void UpperCase(int input, bool appendToOutput = true){
            List<string> translation = new List<string>(new string[]{" ", "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"});
            try{
                string output = translation[input];
                if(appendToOutput){
                    Interpreter.AppendToOutput(output);
                }else{
                    Funcs.Util.Text(output, ConsoleColor.White , false);
                }
            }
            catch (System.Exception){
                Funcs.Sys.Exit(1, "Error: Invalid input");
            }
        }
        static public void LowerCase(int input, bool appendToOutput = true){
            List<string> translation = new List<string>(new string[]{" ", "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"});
            try{
                string output = translation[input];
                if(appendToOutput){
                    Interpreter.AppendToOutput(output);
                }else{
                    Funcs.Util.Text(output, ConsoleColor.White , false);
                }
            }
            catch (System.Exception){
                Funcs.Sys.Exit(1, "Error: Invalid input");
            }
        }
        static public void SpecialChar(int input, bool appendToOutput = true){
        List<string> translation = new List<string>(new string[]{"~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "`", "[", "]", "{", "}", "|", "\\", ";", ":", "\"", "'", "<", ">", ",", ".", "?", "/", "\n"});
            try{
                string output = translation[input];
                if(appendToOutput){
                    Interpreter.AppendToOutput(output);
                }else{
                    Funcs.Util.Text(output, ConsoleColor.White , false);
                }
            }
            catch (System.Exception){
                Funcs.Sys.Exit(1, "Error: Invalid input");
            }
        }
    }
    public class Interpreter{
        static int pointer = 0;
        static string output = "";
        static public void Interpret(List<int> storage, char[] paras){
            for(int index=0;index<paras.Length;index++){
                char param = paras[index];
                // Funcs.Util.Text(param.ToString()+"-"+index.ToString()+"-"+pointer.ToString());
                if(param == '>'){
                    if(storage.Count == pointer){
                        storage.Add(0);
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
                    if(paras.Length < index+2){
                        Translate.LowerCase(storage[pointer]);
                    }else{
                        if(paras[index+1] == '\''){
                            Translate.LowerCase(storage[pointer], false);
                            index++;
                        }else{
                            Translate.LowerCase(storage[pointer]);
                        }
                    }
                }else if(param == '\"'){
                    if(paras.Length < index+2){
                        Translate.UpperCase(storage[pointer]);
                    }else{
                        if(paras[index+1] == '\"'){
                            Translate.UpperCase(storage[pointer], false);
                            index++;
                        }else{
                            Translate.UpperCase(storage[pointer]);
                        }
                    }
                }else if(param == ']'){
                    if(paras.Length < index+2){
                        output += storage[pointer];
                    }else{
                        if(paras[index+1] == ']'){
                            Funcs.Util.Text(storage[pointer].ToString());
                            index++;
                        }else{
                            output += storage[pointer];
                        }
                    }
                }else if(param == '['){
                    if(paras.Length < index+2){
                        Translate.SpecialChar(storage[pointer]);
                    }else{
                        if(paras[index+1] == '['){
                            Translate.SpecialChar(storage[pointer], false);
                            index++;
                        }else{
                            Translate.SpecialChar(storage[pointer]);
                        }
                    }
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
                    Interpreter.Interpret(storage, loopItems);
                }
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