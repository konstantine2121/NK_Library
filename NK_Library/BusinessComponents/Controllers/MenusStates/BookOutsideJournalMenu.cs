using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_Library.BusinessComponents.Controllers.MenusStates
{
    internal class BookOutsideJournalMenu : BaseMenuState
    {
        public BookOutsideJournalMenu(IMenuContext menuContext, IMenuStatesProvider statesProvider) : base(menuContext, statesProvider)
        {
        }

        public override string Name => "Журнал учета выдачи/возврата книг.";

        protected override void RegisterCommands()
        {
            
        }
    }
}
