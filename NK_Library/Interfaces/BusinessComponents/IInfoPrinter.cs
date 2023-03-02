using NK_Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_Library.Interfaces.BusinessComponents
{
    internal interface IInfoPrinter <T> where T : class
    {
        void PrintInfo(T element);

        void PrintInfos(IEnumerable<T> elements);

        void PrintHeaders();
    }
}
