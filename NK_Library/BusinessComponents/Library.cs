using NK_Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_Library.BusinessComponents
{
    internal class Library
    {
        private List<Client> _clients = new List<Client>();
        private List<Book> _books = new List<Book>();
        private List<BookOutside> _bookOutside = new List<BookOutside>();

        public bool CheckBookOutside(Book book)
        {
            return false;
        }

        public bool Check(Book book)
        {
            return false;
        }
    }


}
