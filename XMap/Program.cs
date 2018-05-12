using System;
using XMap.Common;
using XMap.Core;
using XMap.Core.Actions;
using XMap.Core.Conditions;

namespace XMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.WriteLine($"Thank you for using XMap");
            Setup setup = new Setup().Execute();
            Console.ReadKey();
        }

    }
}
