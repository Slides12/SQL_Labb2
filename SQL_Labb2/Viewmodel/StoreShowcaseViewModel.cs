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
    public DanielJohanssonContext db { get; set; }
    public ObservableCollection<Button> GenreButtons { get; set; }
    public ObservableCollection<Böcker> Books { get; set; }


    private Böcker? _activeBook;

    public Böcker? ActiveBook
    {
        get => _activeBook;
        set
        {
            _activeBook = value;
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
        PopulateBookList();
        PopulateGenreButtonList();
    }

    private void AddBook(object obj)
    {
        Books.Add(new Böcker() { Pris = 1, Titel = "Hejsan"});
    }

    private void SetActiveBook(object obj)
    {
        if (obj is Böcker selectedBook)
        {
            ActiveBook = selectedBook;
            RaiseProperyChanged(nameof(ActiveBook));
        }
    }

    public void PopulateBookList()
    {
        db = new DanielJohanssonContext();

        var bookList = db.Böckers.ToList();
        foreach (var book in bookList)
        {
            Books.Add(book);
        }
    }

    public void PopulateGenreButtonList()
    {
        db = new DanielJohanssonContext();

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
        Books.Clear();
        var allBooks = db.Böckers.ToList();
        foreach (var book in allBooks)
        {
            Books.Add(book);
        }
    }


    private void FilterBooksByGenre(string genre)
    {
        Books.Clear();
        var filteredBooks = db.Böckers
                              .Include(b => b.IsbnNavigation)
                              .Where(b => b.IsbnNavigation.Genre == genre)
                              .ToList();

        foreach (var book in filteredBooks)
        {
            Books.Add(book);
        }
    }


}
