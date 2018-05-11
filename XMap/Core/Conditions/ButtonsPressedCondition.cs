using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMap.Common;

namespace XMap.Core.Conditions
{
    [XmlType(TypeName = "ButtonsPressed")]
    public class ButtonsPressedCondition : BaseCondition
    {
        [XmlAttribute]
        public string Key { get; set; }

        public override bool Validate(XInputControllerState state, WindowManager window)
        {
            if (state.State.Gamepad.Buttons.ToString()
                .Equals(this.Key, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // Default validate returns false.
            return base.Validate(state, window);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: Is {this.Key} pressed?";
        }
    }
}
