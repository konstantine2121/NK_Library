using System.Collections.Generic;

namespace NK_Library.Interfaces.BusinessComponents
{
    internal interface IInfoPrinter <T> where T : class
    {
        void PrintInfo(T element);

        void PrintInfos(IEnumerable<T> elements);

        void PrintHeaders();
    }
}
