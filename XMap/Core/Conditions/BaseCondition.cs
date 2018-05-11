using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMap.Core.Conditions
{
    public class BaseCondition
    {
        public BaseCondition()
        {

        }

        public virtual bool Validate(XInputControllerState state, WindowManager window)
        {
            return false;
        }
    }
}
