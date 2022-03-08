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
        static public void Number(int input){
            List<string> translation = new List<string>(new string[]{"0","1","2","3","4","5","6","7","8","9"});
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
        static public void Interpret(char param, Dictionary<int, int> storage){
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
                Translate.Number(storage[pointer]);
            }else if(param == '['){
                Translate.SpecialChar(storage[pointer]);
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