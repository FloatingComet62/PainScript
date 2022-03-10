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
        static public void Exit(int ErrorCode, string ErrorMessage){
            Util.Text(ErrorMessage, ConsoleColor.Red, true);
            Environment.Exit(ErrorCode);
        }
    }
}