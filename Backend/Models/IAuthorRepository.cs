using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    interface IAuthorRepository
    {
        List<Author> GetAuthors();
        Author GetAuthorById(int id);
        Author GetAuthorByName(string Name);
        void UpdateAuthor(int id, Author author);
        Author AddAuthor(Author author);
        void DeleteAuthor(int id);

    }
}
