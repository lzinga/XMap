using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMap.Common;

namespace XMap.Core.Conditions
{
    public class ButtonsPressed : BaseCondition
    {
        public string Key { get; set; }

        public int HoldTime { get; set; }

        public override bool Validate(XInputController controller, WindowManager window)
        {
            // The condition doesn't have a hold time, don't need to worry about it.
            if(this.HoldTime == 0 && !controller.HoldingButtons)
            {
                if (controller.Gamepad.Buttons.ToString()
                    .Equals(this.Key, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            else
            {
                if (controller.Gamepad.Buttons.ToString()
                    .Equals(this.Key, StringComparison.OrdinalIgnoreCase) && TimeSpan.FromSeconds(this.HoldTime) <= controller.CurrentHoldTime)
                {
                    return true;
                }
            }

            // Default validate returns false.
            return base.Validate(controller, window);
        }

        public override string ToString()
        {
            return $"Checking = {nameof(ButtonsPressed)} condition if key {this.Key} was pressed.";
        }
    }
}
