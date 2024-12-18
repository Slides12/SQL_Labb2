using Microsoft.EntityFrameworkCore;
using SQL_Labb2.Command;
using SQL_Labb2.Model;
using SQL_Labb2.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using static System.Reflection.Metadata.BlobBuilder;
using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace SQL_Labb2.Viewmodel;

internal class AdminViewModel : ViewModelBase
{

    private readonly MainWindowViewModel mainWindowViewModel;

    public DelegateCommand SetActiveStoreCommand { get; }
    public DelegateCommand AddBookCommand { get; }
    public DelegateCommand RemoveBookCommand { get; }
    public DelegateCommand SaveBookInformationCommand { get; }
    public DelegateCommand AddCoverPictureCommand { get; }

    public ObservableCollection<LagerSaldo> StockBalance { get; private set; }

    private string BooksFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Books");

    private int _selectedIndex;

    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            _selectedIndex = value;
            RaiseProperyChanged("SelectedIndex");
        }
    }

    private BokInformation _bookInfo;

    public BokInformation BookInfo
    {
        get => _bookInfo;
        set
        {
            _bookInfo = value;
            RaiseProperyChanged();
        }
    }

    private Böcker _book;

    public Böcker Book
    {
        get => _book;
        set
        {
            _book = value;
            RaiseProperyChanged();
        }
    }

    private Författare _author;

    public Författare Author
    {
        get => _author;
        set
        {
            _author = value;
            RaiseProperyChanged();
        }
    }


    public AdminViewModel(MainWindowViewModel? mainWindowViewModel)
    {
        this.mainWindowViewModel = mainWindowViewModel;


        SetActiveStoreCommand = new DelegateCommand(SetActiveStore);
        AddBookCommand = new DelegateCommand(AddBook, HasBooksAlready);
        RemoveBookCommand = new DelegateCommand(RemoveBook);
        SaveBookInformationCommand = new DelegateCommand(SaveBookChanges);
        AddCoverPictureCommand = new DelegateCommand(AddCoverPicture);

    }

    private bool HasBooksAlready(object? arg)
    {
        using var db = new DanielJohanssonContext();
        if (mainWindowViewModel.StoreShowcaseViewModel.ActiveBook == null) { return false; }
        bool gg = db.LagerSaldos.Where(ls => ls.Isbn == mainWindowViewModel.StoreShowcaseViewModel.ActiveBook.Isbn && ls.ButikId == SelectedIndex + 1).Any();

        return gg;

    }

    private void AddCoverPicture(object obj)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Title = "Select a .jpg Picture",
            Filter = "Image Files|*.jpg;",
            Multiselect = false
        };

        if (openFileDialog.ShowDialog() == true)
        {
            string selectedFile = openFileDialog.FileName;

            string extension = Path.GetExtension(selectedFile).ToLower();
            if (extension != ".jpg" )
            {
                MessageBox.Show("Choose only .jpg, only format that works for now.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string isbn = mainWindowViewModel.StoreShowcaseViewModel.ActiveBook?.Isbn;

            if (isbn is null) return;

            string destinationFileName = $"{isbn}.jpg";
            string destinationPath = Path.Combine(BooksFolderPath, destinationFileName);

            try
            {
                File.Copy(selectedFile, destinationPath, overwrite: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        mainWindowViewModel.StoreShowcaseViewModel.PopulateAdminBookListAsync();
    }





    private void SaveBookChanges(object obj)
    {
        using var db = new DanielJohanssonContext();
        foreach (var lagerSaldo in StockBalance)
        {
            db.LagerSaldos.Update(lagerSaldo);
        }

        db.BokInformations.Update(BookInfo);

        db.Böckers.Update(Book);

        db.Författares.Update(Author);


        db.SaveChanges();
    }

    private void AddBook(object obj)
    {

        using var db = new DanielJohanssonContext();

        var book = db.Böckers
            .FirstOrDefault(b => b.Isbn == mainWindowViewModel.StoreShowcaseViewModel.ActiveBook.Isbn);

        if (book == null)
        {
            Debug.WriteLine("The active book could not be found in db.");
            return;
        }

        bool bookExistsInStore = db.LagerSaldos
            .Any(l => l.ButikId == SelectedIndex + 1 && l.Isbn == book.Isbn);

        if (!bookExistsInStore)
        {
            var newLagerSaldo = new LagerSaldo
            {
                ButikId = SelectedIndex + 1,
                Isbn = book.Isbn,
                Antal = 1
            };

            var butikExists = db.Butikers.Find(SelectedIndex + 1);
            if (butikExists == null)
            {
                Debug.WriteLine("Store could not be found.");
                return;
            }

            var bookExists = db.Böckers.Find(book.Isbn);
            if (bookExists == null)
            {
                Debug.WriteLine("Book not be found in db.");
                return;
            }

            db.Attach(butikExists);  
            db.Attach(bookExists); 

            db.LagerSaldos.Add(newLagerSaldo);
            db.SaveChanges(); 

        }
        else
        {
            Debug.WriteLine("Could not add book to store.");
        }
        LoadAdminBookInfo();
        RaiseProperyChanged(nameof(StockBalance));

    }




    private void RemoveBook(object obj)
    {

        using var db = new DanielJohanssonContext();

        var existingLagerSaldo = db.LagerSaldos
            .FirstOrDefault(lagerSaldo =>
                lagerSaldo.ButikId == SelectedIndex + 1 &&
                lagerSaldo.Isbn == mainWindowViewModel.StoreShowcaseViewModel.ActiveBook.Isbn);

        if (existingLagerSaldo != null)
        {
            db.LagerSaldos.Remove(existingLagerSaldo); 
            db.SaveChanges(); 

        }
        else
        {
            Debug.WriteLine("The book does not exist in the selected store.");
        }
        LoadAdminBookInfo();
        RaiseProperyChanged(nameof(StockBalance));
    }




    private void SetActiveStore(object obj)
    {
        if (obj is ComboBox comboBox)
        {
            SelectedIndex = comboBox.SelectedIndex; 
            RaiseProperyChanged(nameof(SelectedIndex));
        }
    }

    public void LoadAdminBookInfo()
    {
        using var db = new DanielJohanssonContext();

        StockBalance = new ObservableCollection<LagerSaldo>
            (
                db.LagerSaldos
                .Include(l => l.Butik)
                .Where(l => l.Isbn == mainWindowViewModel.StoreShowcaseViewModel.ActiveBook.Isbn)
                .ToList()
            );

        BookInfo = db.BokInformations.FirstOrDefault(bi => bi.Isbn == mainWindowViewModel.StoreShowcaseViewModel.ActiveBook.Isbn);

        Book = db.Böckers.FirstOrDefault(b => b.Isbn == mainWindowViewModel.StoreShowcaseViewModel.ActiveBook.Isbn);

        Author = db.Författares.FirstOrDefault(f => f.Isbns.Any(b => b.Isbn == mainWindowViewModel.StoreShowcaseViewModel.ActiveBook.Isbn));

        RaiseProperyChanged(nameof(StockBalance));
    }


}
