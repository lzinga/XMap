using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMap.Common;

namespace XMap.Core.Conditions
{
    public class ButtonsPressed : BaseCondition
    {
        [XmlAttribute]
        public string Key { get; set; }

        [XmlAttribute]
        public int HoldTime { get; set; }

        public override bool Validate(XInputControllerState state, WindowManager window)
        {
            // The condition doesn't have a hold time, don't need to worry about it.
            if(this.HoldTime == 0 && !state.HoldingButtons)
            {
                if (state.State.Gamepad.Buttons.ToString()
                    .Equals(this.Key, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            else
            {
                if (state.State.Gamepad.Buttons.ToString()
                    .Equals(this.Key, StringComparison.OrdinalIgnoreCase) && TimeSpan.FromSeconds(this.HoldTime) <= state.CurrentHoldTime)
                {
                    return true;
                }
            }

            // Default validate returns false.
            return base.Validate(state, window);
        }

        public override string ToString()
        {
            return $"{nameof(ButtonsPressed)} condition, was {this.Key} pressed?";
        }
    }
}
