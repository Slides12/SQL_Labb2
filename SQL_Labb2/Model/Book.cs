using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Labb2.Model;

class Book
{
    public Book(string title = "The Hobbit", string author = "John Ronald Reuel (J.R.R) Tolkien", string language = "English", string description = "The Hobbits", string genre = "Fantasy", string releaseDate = "2002-01-01", int cost = 129, long ISBN = 9780261103344)
    {
        Title = title;
        Author = author;
        Language = language;
        Description = description;
        Genre = genre;
        ReleaseDate = Convert.ToDateTime(releaseDate);
        Cost = cost;
        this.ISBN = ISBN;
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public string Language { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }

    public DateTime ReleaseDate{ get; set; }

    public int Cost { get; set; }
    public long ISBN { get; set; }




}
