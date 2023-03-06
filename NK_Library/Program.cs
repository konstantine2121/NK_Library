using NK_Library.BusinessComponents.Builders;

namespace NK_Library
{
    class Program
    {

       

        static void Main(string[] args)
        {
            var moduleBuilder = new LibraryModuleBuilder();
            var module = moduleBuilder.Build();
            module.Run();
        }

        
    }
}
