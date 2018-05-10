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
