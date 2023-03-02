using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_Library.BusinessComponents
{
    internal class IdCounter
    {
        private readonly int _startId;

        public IdCounter(int startId) 
        {
            _startId = startId;
            Id = startId;
        }

        public int Id { get; private set; }

        public int Increment()
        { 
            Id++;
            return Id; 
        }

        public void Reset()
        {
            Id = _startId;
        }
    }
}
