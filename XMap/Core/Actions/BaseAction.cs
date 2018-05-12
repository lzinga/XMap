namespace XMap.Core.Actions
{
    public class BaseAction
    {
        protected InputManager input;
        
        public BaseAction()
        {
            input = new InputManager();
        }

        public virtual void Execute(XInputController controller) { }
    }
}
