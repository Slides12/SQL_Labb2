using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SQL_Labb2.Command;
using SQL_Labb2.Model;
using static System.Reflection.Metadata.BlobBuilder;

namespace SQL_Labb2.Viewmodel;

internal class MainWindowViewModel : ViewModelBase
{
    public StoreViewModel MenuViewModel { get; }
    public StoreShowcaseViewModel StoreShowcaseViewModel { get; }
    public ObservableCollection<Böcker> Books { get; set; }
    public DanielJohanssonContext db { get; set; }

    public DelegateCommand FullscreenCommand { get; }
    public DelegateCommand ExitCommand { get; }



    public MainWindowViewModel()
    {
        FullscreenCommand = new DelegateCommand(SetFullscreen);
        ExitCommand = new DelegateCommand(Exit);

        Books = new ObservableCollection<Böcker>();
        StoreShowcaseViewModel = new StoreShowcaseViewModel(this);
        MenuViewModel = new StoreViewModel(this);
        PopulateList();

    }

    public void PopulateList()
    {
        db = new DanielJohanssonContext();

        var bookList = db.Böckers.ToList();
        foreach (var book in bookList) 
        {
            Books.Add(book);
        }
    }

    private void SetFullscreen(object obj)
    {
        if (Application.Current.MainWindow.WindowState == WindowState.Normal)
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;

        }
        else
        {
            Application.Current.MainWindow.WindowState = WindowState.Normal;

        }
    }

    private void Exit(object obj)
    {

        Application.Current.Shutdown();
    }
}


