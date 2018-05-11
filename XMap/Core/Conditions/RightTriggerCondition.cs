using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMap.Common;

namespace XMap.Core.Conditions
{
    [XmlType(TypeName = "RightTrigger")]
    public class RightTriggerCondition : BaseCondition
    {
        [XmlAttribute]
        public int Key { get; set; }

        public override bool Validate(XInputControllerState controller, WindowManager window)
        {
            var percent = Math.Round(((double)controller.State.Gamepad.RightTrigger / byte.MaxValue) * 100, 2);

            if (percent >= this.Key)
            {
                return true;
            }


            // Default validate returns false.
            return base.Validate(controller, window);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: is value >= {this.Key}?";
        }
    }
}