using Microsoft.EntityFrameworkCore;
using SQL_Labb2.Command;
using SQL_Labb2.Model;
using SQL_Labb2.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

namespace SQL_Labb2.Viewmodel;

internal class AddBookViewModel : ViewModelBase
{
    public ObservableCollection<Böcker> DbBooks { get; set; }

    public DelegateCommand AddBookCommand { get; }

    private string _isbn;
    public string Isbn
    {
        get => _isbn;
        set
        {
            _isbn = value;
            RaiseProperyChanged();
        }
    }

    private string _title;
    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            RaiseProperyChanged();
        }
    }

    private string _firstName;
    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            RaiseProperyChanged();
        }
    }

    private string _lastName;
    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            RaiseProperyChanged();
        }
    }

    private string _description;
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            RaiseProperyChanged();
        }
    }

    private string _genre;
    public string Genre
    {
        get => _genre;
        set
        {
            _genre = value;
            RaiseProperyChanged();
        }
    }

    private string _language;
    public string Language
    {
        get => _language;
        set
        {
            _language = value;
            RaiseProperyChanged();
        }
    }

    private DateOnly _pyear;
    public DateOnly Pyear
    {
        get => _pyear;
        set
        {
            _pyear = value;
            RaiseProperyChanged();
        }
    }

    public AddBookViewModel()
    {
        AddBookCommand = new DelegateCommand(AddBook);
        PopulateAddBookList();
    }

    public void PopulateAddBookList()
    {
        using var db = new DanielJohanssonContext();

        DbBooks = new ObservableCollection<Böcker>
            (
                db.Böckers
                .Include(b => b.LagerSaldos)
                .Include(b => b.IsbnNavigation)
                .Include(b => b.Författares)
                .ToList()
            );
        RaiseProperyChanged("DbBooks");
    }

    private void AddBook()
    {
        if (CheckIsbn(Isbn))
        {
            using var db = new DanielJohanssonContext();

            var newBook = new Böcker
            {
                Isbn = Isbn,
                Titel = Title,
                Språk = Language,
                Utgivningsdatum = Pyear,
                Författares = new List<Författare>
                {
                    new Författare
                    {
                        Förnamn = FirstName,
                        Efternamn = LastName
                    }
                }
            };

            db.Böckers.Add(newBook);
            Debug.WriteLine(newBook.Titel);
            //db.SaveChanges();

            PopulateAddBookList();
        }
        else
        {
            Console.WriteLine("ISBN must be a number, start with a 9 and be 13 characters long.");
        }
    }

    private bool CheckIsbn(string isbn)
    {
        if (string.IsNullOrEmpty(isbn))
            return false;

        var regex = new Regex(@"^9\d+$"); 
        return regex.IsMatch(isbn);
    }
}
