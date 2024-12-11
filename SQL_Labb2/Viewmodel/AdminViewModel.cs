using Microsoft.EntityFrameworkCore;
using SQL_Labb2.Command;
using SQL_Labb2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Reflection.Metadata.BlobBuilder;

namespace SQL_Labb2.Viewmodel;

internal class AdminViewModel : ViewModelBase
{

    private readonly MainWindowViewModel mainWindowViewModel;

    public DelegateCommand SetActiveStoreCommand { get; }
    public DelegateCommand AddBookCommand { get; }
    public DelegateCommand RemoveBookCommand { get; }

    public ObservableCollection<LagerSaldo> StockBalance { get; private set; }


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


    public AdminViewModel(MainWindowViewModel? mainWindowViewModel)
    {
        this.mainWindowViewModel = mainWindowViewModel;


        SetActiveStoreCommand = new DelegateCommand(SetActiveStore);
        AddBookCommand = new DelegateCommand(AddBook);
        RemoveBookCommand = new DelegateCommand(RemoveBook);
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

            var butik = db.Butikers.Find(SelectedIndex + 1);
            if (butik == null)
            {
                Debug.WriteLine("Store could not be found.");
                return;
            }

            var bookEntity = db.Böckers.Find(book.Isbn);
            if (bookEntity == null)
            {
                Debug.WriteLine("Book not be found in db.");
                return;
            }

            db.Attach(butik);  
            db.Attach(bookEntity); 

            db.LagerSaldos.Add(newLagerSaldo);
            db.SaveChanges(); 

        }
        else
        {
            Debug.WriteLine("Could not add book to store.");
        }
        LoadStockBalance();
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
        LoadStockBalance();
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

    public void LoadStockBalance()
    {
        using var db = new DanielJohanssonContext();

        StockBalance = new ObservableCollection<LagerSaldo>
            (
                db.LagerSaldos
                .Include(l => l.Butik)
                .Where(l => l.Isbn == mainWindowViewModel.StoreShowcaseViewModel.ActiveBook.Isbn)
                .ToList()
            );
        RaiseProperyChanged(nameof(StockBalance));
    }


}
