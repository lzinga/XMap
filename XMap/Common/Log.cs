using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMap.Common
{
    public static class Log
    {
        private static void WriteDate()
        {
            Log.Write($"{DateTime.Now}: ");
        }


        public static void WriteColor(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }

        public static void Write(string str, bool isEnd = false)
        {
            Console.Write(str);

            if (isEnd)
            {
                Console.Write(Environment.NewLine);
            }
        }
        
        public static void WriteLine(string str)
        {
            Log.WriteDate();
            Log.Write(str, true);
        }


        public static void WriteAction(LogMarker action, string str)
        {
            ConsoleColor color;
            switch (action)
            {
                case LogMarker.Action:
                    color = ConsoleColor.Yellow;
                    break;
                case LogMarker.Macro:
                    color = ConsoleColor.Green;
                    break;
                case LogMarker.Config:
                    color = ConsoleColor.White;
                    break;
                case LogMarker.Error:
                    color = ConsoleColor.Red;
                    break;
                default:
                    color = ConsoleColor.Gray;
                    break;
            }

            Log.WriteDate();
            Log.WriteColor($"[{action.ToString().ToUpper()}] \t", color);
            Log.Write(str, true);
        }
    }
}
