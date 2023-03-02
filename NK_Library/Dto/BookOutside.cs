namespace NK_Library.Dto
{
    internal class BookOutside
    {
        public BookOutside(Book book, Client client)
        {
            Book = book;
            Client = client;
        }

        public Book Book { get; }
        public Client Client { get; }
    }
}
