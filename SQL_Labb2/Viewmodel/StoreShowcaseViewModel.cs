using SQL_Labb2.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_Labb2.Model;
using static System.Reflection.Metadata.BlobBuilder;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace SQL_Labb2.Viewmodel;

class StoreShowcaseViewModel : ViewModelBase
{
    private readonly MainWindowViewModel mainWindowViewModel;
    public DelegateCommand AddBookCommand { get; }
    public DelegateCommand SetActiveBookCommand { get; }
    public ObservableCollection<Button> GenreButtons { get; set; }
    public ObservableCollection<Böcker> Books { get; set; }


    private Böcker? _activeBook;

    public Böcker? ActiveBook
    {
        get => _activeBook;
        set
        {
            _activeBook = value;
            if(ActiveBook != null) 
            {
                SetBookAuthor();
                if (mainWindowViewModel.StoreId != 4)
                {
                    SetBookDescription();
                    SetCurrentStorage();
                    mainWindowViewModel.SetBookInfoViewCommand.Execute(this);
                }
                else
                {
                    mainWindowViewModel.SetAdminViewCommand.Execute(this);

                }
            }
            RaiseProperyChanged();
        }
    }




    private string _bookInfo;

    public string BookInfo
    {
        get => _bookInfo;
        set
        {
            _bookInfo = value;
            RaiseProperyChanged();
        }
    }

    private string _bookAuthor;

    public string BookAuthor
    {
        get => _bookAuthor;
        set
        {
            _bookAuthor = value;
            RaiseProperyChanged();
        }
    }

    private int? _inStorage;

    public int? InStorage
    {
        get => _inStorage;
        set
        {
            _inStorage = value;
            RaiseProperyChanged();
        }
    }


    public StoreShowcaseViewModel(MainWindowViewModel? mainWindowViewModel)
    {
        this.mainWindowViewModel = mainWindowViewModel;
        //Delegates
        AddBookCommand = new DelegateCommand(AddBook);
        SetActiveBookCommand = new DelegateCommand(SetActiveBook);

        // Lists
        GenreButtons = new ObservableCollection<Button>();
        Books = new ObservableCollection<Böcker>();

        // Methods
        PopulateGenreButtonList();
    }

    private void AddBook(object obj)
    {
        Books.Add(new Böcker() { Pris = 1, Titel = "Hejsan"});
    }

    public void SetBookDescription()
    {
        using var db = new DanielJohanssonContext();

        var bookList = db.Böckers
            .Include(book => book.IsbnNavigation)
            .Where(bookInfo => bookInfo.Isbn == ActiveBook.Isbn)
            .ToList();

        BookInfo = bookList[0].IsbnNavigation.Beskrivning.ToString();
    }

    public void SetBookAuthor()
    {
        using var db = new DanielJohanssonContext();

        var bookList = db.Böckers
            .Include(book => book.Författares)
            .Where(bookInfo => bookInfo.Isbn == ActiveBook.Isbn)
            .ToList();

        if(bookList.Count > 0)
        {
            var authors = bookList[0].Författares;
            BookAuthor =  string.Join(" ", authors.Select(author => $"{author.Förnamn} {author.Efternamn}"));
        }

    }

    public void SetCurrentStorage()
    {
        using var db = new DanielJohanssonContext();

        var bookList = db.LagerSaldos
            .Where(bookInfo => bookInfo.Isbn == ActiveBook.Isbn && bookInfo.ButikId == mainWindowViewModel.StoreId)
            .ToList();

        InStorage = bookList[0].Antal;
    }

    private void SetActiveBook(object obj)
    {
        if (obj is Böcker selectedBook)
        {
            ActiveBook = selectedBook;
            RaiseProperyChanged(nameof(ActiveBook));
        }
    }


    public async Task PopulateBookListAsync()
    {
        using var db = new DanielJohanssonContext();

        var bookList = await db.Böckers
            .Include(book => book.LagerSaldos)
            .Where(book => book.LagerSaldos.Any(saldo => saldo.ButikId == mainWindowViewModel.StoreId && saldo.Antal > 0))
            .ToListAsync();
        Books.Clear();
        foreach (var book in bookList)
        {
            Books.Add(book);
        }
    }

    public async Task PopulateAdminBookListAsync()
    {
        using var db = new DanielJohanssonContext();

        var bookList = await db.Böckers.ToListAsync();

        Books.Clear();
        foreach (var book in bookList)
        {
            Books.Add(book);
        }
    }

    public void PopulateGenreButtonList()
    {
        using var db = new DanielJohanssonContext();

        GenreButtons.Add(new Button
        {
            Content = "All Genres",
            Command = new DelegateCommand(_ => ShowAllBooks())
        });

        var genres = db.Böckers
                       .Include(b => b.IsbnNavigation)
                       .Select(b => b.IsbnNavigation.Genre)
                       .Distinct()
                       .ToList();

        foreach (var genre in genres)
        {
            GenreButtons.Add(new Button
            {
                Content = genre,
                Command = new DelegateCommand(param => FilterBooksByGenre(genre)),
                CommandParameter = genre
            });
        }
    }

    private void ShowAllBooks()
    {
        using var db = new DanielJohanssonContext();
        Books.Clear();
        var allBooks = db.Böckers
            .Include(b => b.LagerSaldos)
            .Where(b => b.LagerSaldos.Any(l => l.Antal > 0 && l.ButikId == mainWindowViewModel.StoreId))
            .ToList();
        foreach (var book in allBooks)
        {
            Books.Add(book);
        }
        mainWindowViewModel.SetStoreShowcaseCommand.Execute(this);
    }



    private void FilterBooksByGenre(string genre)
    {
        using var db = new DanielJohanssonContext();
        Books.Clear();

        var filteredBooks = db.Böckers
            .Include(b => b.LagerSaldos) 
            .Include(b => b.IsbnNavigation) 
            .Where(b => b.IsbnNavigation.Genre == genre && b.LagerSaldos.Any(l => l.Antal > 0 && l.ButikId == mainWindowViewModel.StoreId))
            .ToList();
        foreach (var book in filteredBooks)
        {
            Books.Add(book);
        }

        mainWindowViewModel.SetStoreShowcaseCommand.Execute(this);
    }



}
