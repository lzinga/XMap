using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMap.Common;

namespace XMap.Core.Conditions
{
    [XmlType(TypeName = "ActiveProcess")]
    public class ActiveProcessCondition : BaseCondition
    {
        [XmlAttribute]
        public string Key { get; set; }

        public override bool Validate(XInputControllerState state, WindowManager window)
        {
            string winName = window.GetActiveProcessName();
            if (winName.Equals(this.Key, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // Default validate returns false.
            return base.Validate(state, window);
        }

        public override string ToString()
        {
            return $"{nameof(ActiveProcessCondition)} condition, is active window {this.Key}?";
        }
    }
}