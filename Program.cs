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
                Dictionary<int, int> storage = new Dictionary<int, int>(){
                    {0, 0}
                };
                File.Create(outputDestination).Close();
                string data = File.ReadAllText(fileLocation);
                char[] paras = data.ToCharArray();
                for(var i=0;i<paras.Length;i++){
                    char param = paras[i];
                    Interpreter.Interpreter.Interpret(param, storage);
                }
                File.WriteAllText(outputDestination, Interpreter.Interpreter.GetOutput());
            }
        }
    }
}