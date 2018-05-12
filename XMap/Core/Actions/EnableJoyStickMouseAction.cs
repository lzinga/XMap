using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsInput.Native;

namespace XMap.Core.Actions
{
    public class EnableJoyStickMouseAction : BaseAction
    {

        public override void Execute()
        {

        }

        public override string ToString()
        {
            return $"Enabled joystick as mouse.";
        }
    }
}
