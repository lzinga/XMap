using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMap.Core.Actions
{
    public class BaseAction : IAction
    {
        protected InputManager input;
        
        public BaseAction()
        {
            input = new InputManager();
        }

        public virtual void Execute() { }
    }
}
