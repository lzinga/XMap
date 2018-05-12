using SharpDX.XInput;
using System;
using System.Linq;
using System.Text;
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
