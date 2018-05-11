using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMap.Common;

namespace XMap.Core.Conditions
{
    public class ActiveProcess : BaseCondition
    {
        [XmlAttribute]
        public string Name { get; set; }

        public override bool Validate(XInputControllerState state, WindowManager window)
        {
            if(window.GetActiveProcessName().Equals(this.Name, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // Default validate returns false.
            return base.Validate(state, window);
        }

        public override string ToString()
        {
            return $"{nameof(ActiveProcess)} condition, is active window {this.Name}?";
        }
    }
}
