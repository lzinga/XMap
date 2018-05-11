using XMap.Common;
using XMap.Core;
using XMap.Core.Actions;
using XMap.Core.Conditions;

namespace XMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapping test = new Mapping()
            {
                Macros = new System.Collections.Generic.List<Macro>()
                {
                    new Macro()
                    {
                        OnKeyDown = "A",

                        Actions = new System.Collections.Generic.List<Core.Actions.BaseAction>()
                        {
                            new KeyAction()
                            {
                                 Key = Common.Keys.A,
                            }
                        },
                         Conditions = new System.Collections.Generic.List<Core.Conditions.BaseCondition>()
                         {
                             new ButtonsPressed()
                         }
                    }
                }
            };

            test.Serialize();

            Setup setup = new Setup().Execute();
        }

    }
}
