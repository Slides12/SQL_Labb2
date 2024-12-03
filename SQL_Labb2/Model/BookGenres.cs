using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Labb2.Model;

class BookGenres
{
    public BookGenres(string genre)
    {
        Genre = genre;
        Books = new List<Book>();
    }

    public string Genre { get; set; }
    public List<Book> Books { get; set; }
}
