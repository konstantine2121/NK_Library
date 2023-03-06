using NK_Library.BusinessComponents.Controllers.MenusStates;
using NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates;

namespace NK_Library.BusinessComponents.Builders
{
    internal class LibraryModuleBuilder
    {
        public LibraryModuleBuilder() { }

        public LibraryModule Build()
        {
            var library = new LibraryFactoryBuilder().Build().Create();

            IMenuContext menu = new MenuContext(library);

            return new LibraryModule(library, menu);
        }
    }
}
