﻿using Microsoft.EntityFrameworkCore;
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
    public ObservableCollection<string> Genres { get; set; }
    public ObservableCollection<string> Authors { get; set; }
    public ObservableCollection<string> Languages { get; set; }

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

    private string _newAuthor;
    public string NewAuthor
    {
        get => _newAuthor;
        set
        {
            _newAuthor = value;
            RaiseProperyChanged();
        }
    }

    private string _selectedAuthor;
    public string SelectedAuthor
    {
        get => _selectedAuthor;
        set
        {
            _selectedAuthor = value;
            RaiseProperyChanged();
        }
    }

    private int _price;
    public int Price
    {
        get => _price;
        set
        {
            _price = value;
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

    private string _selectedGenre;
    public string SelectedGenre
    {
        get => _selectedGenre;
        set
        {
            _selectedGenre = value;
            RaiseProperyChanged();
        }
    }

    private string _newGenre;
    public string NewGenre
    {
        get => _newGenre;
        set
        {
            _newGenre = value;
            RaiseProperyChanged();
        }
    }

    private string _selectedLanguage;
    public string SelectedLanguage
    {
        get => _selectedLanguage;
        set
        {
            _selectedLanguage = value;
            RaiseProperyChanged();
        }
    }


    private string _newlanguage;
    public string NewLanguage
    {
        get => _newlanguage;
        set
        {
            _newlanguage = value;
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
        PopulateAddBookLists();
    }

    public void PopulateAddBookLists()
    {
        using var db = new DanielJohanssonContext();

       
        Authors = new ObservableCollection<string>(
            db.Författares.Select(f => f.Förnamn + " " + f.Efternamn).ToList()
            );

        Genres = new ObservableCollection<string>(
            db.BokInformations.Select(b => b.Genre).Distinct().ToList()
            );

        Languages = new ObservableCollection<string>(
            db.Böckers.Select(b => b.Språk).Distinct().ToList()
            );

        RaiseProperyChanged("Authors");
        RaiseProperyChanged("Genres");
        RaiseProperyChanged("Languages");
    }

    private void AddBook(object obj)
    {
        if (CheckIsbn(Isbn))
        {
            using var db = new DanielJohanssonContext();
            var author = NewAuthor?.Split(" ") ?? SelectedAuthor?.Split(" ");
            var newBook = new Böcker
            {
                Isbn = Isbn,
                Titel = Title,
                Språk = NewLanguage ?? SelectedLanguage,
                Utgivningsdatum = Pyear,
                Pris = Price,
                IsbnNavigation = new BokInformation
                {
                    Isbn = Isbn,
                    Beskrivning = Description
                },
                LagerSaldos = new List<LagerSaldo>()
                {
                    new LagerSaldo()
                    {
                        Isbn = Isbn,
                        ButikId = 1,
                        Antal = 0
                    },

                    new LagerSaldo()
                    {
                        Isbn = Isbn,
                        ButikId = 2,
                        Antal = 0
                    },

                    new LagerSaldo()
                    {
                        Isbn = Isbn,
                        ButikId = 3,
                        Antal = 0
                    }
                },
                Författares = new List<Författare>
                {
                    new Författare
                    {

                        Förnamn = author[0],
                        Efternamn = author[1]
                    }
                }
            };

            db.Böckers.Add(newBook);
            Debug.WriteLine(newBook.Isbn);
            Debug.WriteLine(newBook.Titel);
            Debug.WriteLine(newBook.Språk);
            Debug.WriteLine(newBook.Utgivningsdatum);
            Debug.WriteLine(newBook.IsbnNavigation.Beskrivning);
            db.SaveChanges();

            PopulateAddBookLists();
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