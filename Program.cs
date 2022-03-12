using Interpreter;
using Funcs;

namespace Program{
    class Program{

        static void Main(string[] args){
            if(args.Length == 0){
                Funcs.Sys.Exit(1, "Error: No input file location provided");
            }
            if(args.Length == 1){
                Funcs.Sys.Exit(1, "Error: No output file location provided");
            }

            
            string fileLocation = args[0];
            string outputDestination = args[1];
            if(File.Exists(fileLocation)){
                List<int> storage = new List<int>(new int[30000]);
                File.Create(outputDestination).Close();
                string data = File.ReadAllText(fileLocation);
                char[] paras = data.ToCharArray();
                Interpreter.Interpreter.Interpret(storage, paras);
                File.WriteAllText(outputDestination, Interpreter.Interpreter.GetOutput());
                Funcs.Sys.Exit(0, "Success", ConsoleColor.Green);
            }else{
                Funcs.Sys.Exit(1, "Error: File not found");
            }
        }
    }
}