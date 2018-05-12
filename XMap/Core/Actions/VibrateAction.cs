using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsInput.Native;

namespace XMap.Core.Actions
{
    [XmlType(TypeName = "Vibrate")]
    public class VibrateAction : BaseAction
    {
        [XmlAttribute]
        public int Amount { get; set; }

        [XmlAttribute]
        public double Duration { get; set; }

        public override void Execute(XInputController controller)
        {
            controller.Vibrate(Amount, Duration);
        }

        public override string ToString()
        {
            return $"Vibrating {Amount}% for {Duration} seconds.";
        }
    }
}
