using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SharpDX.XInput;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XMap.Core;

namespace XMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup setup = new Setup().Execute();
        }

    }
}
