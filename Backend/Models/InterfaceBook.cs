using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Models
{
    interface InterfaceBook
    {
        List<Book> GetBooks();
        Book GetBookId(int id);

        List<Book> Search(string searchword ,string search);
        int UpdateBook(Book book);
        int DeleteBook(int id);
        int AddBook(Book book);

        List<Book> GetBooksbyId(int id);
        Book GetBooksbyName(string name);

       
    }
}
