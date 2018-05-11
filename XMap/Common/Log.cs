using System;
using System.Drawing;
namespace XMap.Common
{
    public static class Log
    {
        private static void WriteDate()
        {
            Log.Write($"{DateTime.Now}: ");
        }


        public static void WriteColor(object str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }

        public static void WriteLineColor(object str, ConsoleColor color)
        {
            Log.WriteDate();
            Log.WriteColor(str, color);
            Log.Write(null, true);
        }

        public static void Write(object str, bool isEnd = false)
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

        public static void WriteLine(object str)
        {
            Log.WriteDate();
            Log.Write(str, true);
        }

        public static void WriteAction(LogMarker action, object str)
        {
            ConsoleColor color;
            switch (action)
            {
                case LogMarker.Macro:
                    color = ConsoleColor.Yellow;
                    break;
                case LogMarker.Action:
                    color = ConsoleColor.DarkYellow;
                    break;
                case LogMarker.Condtn:
                    color = ConsoleColor.DarkYellow;
                    break;
                case LogMarker.Config:
                    color = ConsoleColor.DarkGray;
                    break;
                case LogMarker.Error:
                    color = ConsoleColor.Red;
                    break;
                case LogMarker.Info:
                    color = ConsoleColor.White;
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
