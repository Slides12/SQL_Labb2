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
        Debug.WriteLine($"Adding a book to store: {SelectedIndex+1}");
        using var db = new DanielJohanssonContext();

        var bookAtStore = db.Böckers
            .Include(book => book.LagerSaldos)
            .Where(
            book => book.Isbn == mainWindowViewModel.StoreShowcaseViewModel.ActiveBook.Isbn
            && book.LagerSaldos.Any(saldo => saldo.ButikId == SelectedIndex)
            ).ToString();

    }

    private void RemoveBook(object obj)
    {
        Debug.WriteLine($"Removing a book from store: {SelectedIndex+1}");
    }


    private void SetActiveStore(object obj)
    {
        if (obj is ComboBox comboBox)
        {
            SelectedIndex = comboBox.SelectedIndex; 
            RaiseProperyChanged(nameof(SelectedIndex));
        }
    }


}
