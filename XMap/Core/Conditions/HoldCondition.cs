using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMap.Common;

namespace XMap.Core.Conditions
{
    [XmlType(TypeName = "Hold")]
    public class HoldCondition : BaseCondition
    {
        [XmlAttribute]
        public int Key { get; set; }

        public override bool Validate(XInputControllerState controller, WindowManager window)
        {
            if (controller.CurrentHoldTime.TotalSeconds >= this.Key && controller.HoldingButtons)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: has it been held for {this.Key} seconds?";
        }
    }
}