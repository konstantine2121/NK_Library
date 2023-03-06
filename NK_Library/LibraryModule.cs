using NK_Library.BusinessComponents;
using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;

namespace NK_Library
{
    internal class LibraryModule
    {
        private Library _library;
        private IMenuContext _menu;

        public LibraryModule(Library library, IMenuContext menu)
        {
            _library = library;
            _menu = menu;
        }

        public void Run()
        {
            while (_menu.InvalidState == false)
            {
                _menu.PerformAction();
            }
        }
    }
}
