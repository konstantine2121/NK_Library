using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace библеотека
{
    class Program
    {
        //enum eFIO
        //{
        //    Мельникова_Ксения_Витальевна, Иванова_София_Ивановна,
        //    Буракшаева_Юлия_Сергеевна, Фурсова_Елизавета_Владимировна, Сапсай_Иван_Алексеевич
        //}

        //enum eBookName
        //{ Война_и_мир, Лолита, Одиссея, Мидлмарч, Над_пропастью_во_ржи, Уловка_22 }

        //enum eAuthorBook
        //{ Лев_Толстой, Владимир_Набоков, Гомер, Джордж_Элиот, Дж_Д_Сэлинджер, Джозеф_Хеллер }

        //enum eGenreBook
        //{ повесть, роман, поэма, расказ }

        class Client
        {
            public Client(string fullName, DateTime birthday, string phoneNumber)
            {
                FullName = fullName;
                Birthday = birthday;
                PhoneNumber = phoneNumber;
            }

            public string FullName { get; }
            public DateTime Birthday { get; }
            public string PhoneNumber { get; }
        }

        class Book
        {
            public Book(string author, string name, string genre, bool adultOnly, bool inStock)
            {
                Author = author;
                Name = name;
                Genre = genre;
                AdultOnly = adultOnly;
            }

            public string Author { get;  }
            public string Name { get;  }
            public string Genre { get;  }
            public bool AdultOnly { get;}
        }

        class BookOutside
        {
            public BookOutside(Book book, Client client)
            {
                Book = book;
                Client = client;
            }

            public Book Book { get; }
            public Client Client { get; }
        }

        class Library
        {
            private List<Client>_clients = new List<Client>();
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


        static void Main(string[] args)
        {
            //byte namberbilet = 0;

            //int[] ageLimitBooks = { 0, 6, 12, 16, 18 };
            //int maxItem = 5;// макс количество обектов
            //Random rnd = new Random();
            //person[] pipl = new person[maxItem];//масив людей
            //booksOnHand[] readerTticket = new booksOnHand[20];
            //library[] book = new library[maxItem];// масив книг

            //for (int i = 0; i < maxItem; i++)
            //{
            //    pipl[i] = new person();
            //    pipl[i].FIO = (eFIO)i;
            //    pipl[i].Birthday = new DateTime(rnd.Next(1992, 2010), rnd.Next(1, 12), rnd.Next(1, 30));
            //    pipl[i].phponN = rnd.Next(10000, 99999).ToString("#-##-##");
            //    pipl[i].piplDebtor = false;
            //}
            //for (int i = 0; i < maxItem; i++)
            //{
            //    book[i] = new library();
            //    book[i].AuthorBook = (eAuthorBook)i;
            //    book[i].BookName = (eBookName)i;
            //    book[i].GenreBook = (eGenreBook)rnd.Next(0, 2);
            //    book[i].ageLimit = ageLimitBooks[rnd.Next(0, 5)].ToString("##+");
            //    book[i].InStock = true;
            //}
            //while (true)
            //{
            //    Console.Clear();
            //    Console.WriteLine("ввдите  команду (out) если хотите выдатькнигу");
            //    Console.WriteLine("ввдите  команду (in) если хотите вернуть книгу в библеотеку");
            //    Console.WriteLine("ввдите  команду (all) список книг на руках");

            //    //блок ввода вывода первый уровень



            //    string vodKomand = "";
            //    while (vodKomand != "out" & vodKomand != "in" & vodKomand != "all")
            //    {
            //        Console.Write("ввдите  команду: ");
            //        vodKomand = Console.ReadLine();
            //    }
            //    Console.Clear();


            //    if (vodKomand == "out")
            //    {
            //        for (int i = 0; i < maxItem; i++)
            //        {
            //            Console.WriteLine("{0}) {1}", i, pipl[i].FIO);
            //        }



            //        int piplNamber = -1;
            //        bool prov = false;
            //        while (prov == false)
            //        {

            //            Console.Write("выберите номер человека: ");
            //            prov = int.TryParse(Console.ReadLine(), out piplNamber);
            //            prov = piplNamber < 0 | piplNamber > maxItem ? false : true;

            //        }
            //        Console.Clear();
            //        for (int i = 0; i < maxItem; i++)
            //        {
            //            if (book[i].InStock)
            //                Console.WriteLine("{0}) {1}", i, book[i].BookName);
            //        }

            //        int bookNamber = -1;
            //        prov = false;
            //        while (prov == false)
            //        {
            //            Console.Write("выберите номер книги: ");
            //            prov = int.TryParse(Console.ReadLine(), out bookNamber);
            //            prov = bookNamber < 0 | bookNamber > maxItem ? false : true;
            //        }
            //        pipl[piplNamber].piplDebtor = true;
            //        book[bookNamber].InStock = false;

            //        readerTticket[namberbilet] = new booksOnHand();
            //        readerTticket[namberbilet].bookBlent = namberbilet;
            //        readerTticket[namberbilet].namePipl = pipl[piplNamber].FIO;
            //        readerTticket[namberbilet].namebook = book[bookNamber].BookName;

            //        namberbilet++;
            //    }

            //    if (vodKomand == "all")
            //    {
            //        for (int i = 0; i < namberbilet; i++)
            //        {
            //            Console.WriteLine("{0} {1} \n\t{2}", readerTticket[i].bookBlent,
            //                                               readerTticket[i].namePipl,
            //                                               readerTticket[i].namebook);
            //        }
            //        Console.ReadKey();

            //    }
        }

    }
}
