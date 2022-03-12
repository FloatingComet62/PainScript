using System;

namespace Funcs{
    public class Util{
        static public void Text(string Text, ConsoleColor color = ConsoleColor.White, bool newLine = true){
            Console.ForegroundColor = color;
            if(newLine){
                Console.WriteLine(Text);
            }else{
                Console.Write(Text);
            }
            Console.ResetColor();
        }
        static public void Pause(){
            Console.Read();
        }
    }
    public class Sys{
        static public void Exit(int ErrorCode, string ErrorMessage, ConsoleColor consoleColor = ConsoleColor.Red){
            Util.Text(ErrorMessage, consoleColor, true);
            Environment.Exit(ErrorCode);
        }
    }
}