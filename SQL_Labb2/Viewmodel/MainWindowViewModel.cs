using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore;
using SQL_Labb2.Command;
using SQL_Labb2.Model;
using static System.Reflection.Metadata.BlobBuilder;

namespace SQL_Labb2.Viewmodel;

internal class MainWindowViewModel : ViewModelBase
{
    public StoreShowcaseViewModel StoreShowcaseViewModel { get; }
    public AdminViewModel AdminViewModel { get; }
    public DanielJohanssonContext db { get; set; }

    public DelegateCommand FullscreenCommand { get; }
    public DelegateCommand ExitCommand { get; }
    public DelegateCommand SetStoreViewCommand { get; }
    public DelegateCommand SetStoreShowcaseCommand { get; }
    public DelegateCommand SetBookInfoViewCommand { get; }
    public DelegateCommand SetAdminViewCommand { get; }
    public DelegateCommand AddBooksCommand { get; private set; }
    public DelegateCommand RemoveBooksCommand { get; private set; }



    private string _storeNumber;

    public string StoreNumber
    {
        get => _storeNumber;
        set
        {
            _storeNumber = value;
            SetStoreDetails(_storeNumber);
            RaiseProperyChanged("StoreNumber");
        }
    }


    private int _storeId;
    public int StoreId
    {
        get => _storeId;
        set
        {
            _storeId = value;
            _ = UpdateStoreIdAsync();
        }
    }



    private ImageSource _storePic;

    public ImageSource StorePic
    {
        get => _storePic;
        set
        {
            if (_storePic != value)
            {
                _storePic = value;
                RaiseProperyChanged(nameof(StorePic));
            }
        }
    }

    private Visibility _storeViewVisibility;
    public Visibility StoreViewVisibility
    {
        get
        {
            return _storeViewVisibility;
        }
        set
        {
            _storeViewVisibility = value;

            RaiseProperyChanged("StoreViewVisibility");
        }
    }

    private Visibility _StoreShowcaseVisibility;
    public Visibility StoreShowcaseVisibility
    {
        get
        {
            return _StoreShowcaseVisibility;
        }
        set
        {
            _StoreShowcaseVisibility = value;

            RaiseProperyChanged("StoreShowcaseVisibility");
        }
    }


    private Visibility _bookInfoViewVisibility;
    public Visibility BookInfoViewVisibility
    {
        get => _bookInfoViewVisibility;
        set
        {
            _bookInfoViewVisibility = value;
            StoreShowcaseRowSpan = _bookInfoViewVisibility == Visibility.Visible ? 1 : 2;
            RaiseProperyChanged(nameof(BookInfoViewVisibility));
        }
    }

    private Visibility _adminViewVisibility;
    public Visibility AdminViewVisibility
    {
        get => _adminViewVisibility;
        set
        {
            _adminViewVisibility = value;
            StoreShowcaseRowSpan = _adminViewVisibility == Visibility.Visible ? 1 : 2;
            RaiseProperyChanged(nameof(AdminViewVisibility));
        }
    }

    private Visibility _addBookBTNVisibility;
    public Visibility AddBookBTNVisibility
    {
        get => _addBookBTNVisibility;
        set
        {
            _addBookBTNVisibility = value;
            RaiseProperyChanged(nameof(AddBookBTNVisibility));
        }
    }


    private int _storeShowcaseRowSpan = 1;
    public int StoreShowcaseRowSpan
    {
        get => _storeShowcaseRowSpan;
        set
        {
            _storeShowcaseRowSpan = value;
            RaiseProperyChanged(nameof(StoreShowcaseRowSpan));
        }
    }

    public Action AddBooks { get; set; }
    public Action RemoveBooks { get; set; }

    public MainWindowViewModel()
    {
        // Delegates
        FullscreenCommand = new DelegateCommand(SetFullscreen);
        ExitCommand = new DelegateCommand(Exit);
        SetStoreViewCommand = new DelegateCommand(SetStoreView);
        SetStoreShowcaseCommand = new DelegateCommand(SetStoreShowcase);
        SetBookInfoViewCommand = new DelegateCommand(SetBookInfoView);
        SetAdminViewCommand = new DelegateCommand(SetAdminView);
        AddBooksCommand = new DelegateCommand(AddBook);
        RemoveBooksCommand = new DelegateCommand(RemoveBook);

        // Visibility
        StoreViewVisibility = Visibility.Visible;
        StoreShowcaseVisibility = Visibility.Hidden;
        BookInfoViewVisibility = Visibility.Hidden;
        AdminViewVisibility = Visibility.Hidden;


        // ViewModels
        StoreShowcaseViewModel = new StoreShowcaseViewModel(this);
        AdminViewModel = new AdminViewModel(this);

        TestConnectionToDB();

    }

    private void AddBook(object obj) => AddBooks();
    private void RemoveBook(object obj) => RemoveBooks();

    private async void SetStoreDetails(string store)
    {
        await SetStorePic(store);

        await SetStoreID(store);

    }

    public void TestConnectionToDB()
    {
        try 
        { 
        using var db = new DanielJohanssonContext();
        db.Böckers.ToList();
        }
        catch (Exception ex) 
        {
            MessageBox.Show($"Seems there's something wrong with the connection to the database.{ex.Message}");
        }
    }

    private async Task SetStorePic(string store)
    {
        StorePic = store switch
        {
            "B1" => new BitmapImage(new Uri("/Assets/Adlibris.png", UriKind.Relative)),
            "B2" => new BitmapImage(new Uri("/Assets/Amazon.jpeg", UriKind.Relative)),
            "B3" => new BitmapImage(new Uri("/Assets/SciFi.png", UriKind.Relative)),
            "B4" => new BitmapImage(new Uri("/Assets/Admin.png", UriKind.Relative)),
            _ => null  
        };
    }


    private async Task SetStoreID(string store)
    {
        switch (store)
        {
            case "B1":
                StoreId = 1;
                break;
            case "B2":
                StoreId = 2;
                break;
            case "B3":
                StoreId = 3;
                break;
            case "B4":
                StoreId = 4;
                break;
        }
    }

    private async Task UpdateStoreIdAsync()
    {
        if (_storeId != null)
        {
            await StoreShowcaseViewModel.PopulateGenreButtonListAsync();

            if (_storeId == 4)
            {
                await StoreShowcaseViewModel.PopulateAdminBookListAsync();
                AddBookBTNVisibility = Visibility.Visible;
            }
            else
            {
                await StoreShowcaseViewModel.PopulateBookListAsync();
            }
        }
        RaiseProperyChanged("StoreId");
    }


    private void SetStoreView(object obj)
    {
        StoreViewVisibility = Visibility.Visible;
        StoreShowcaseVisibility = Visibility.Hidden;
        BookInfoViewVisibility = Visibility.Hidden;
        AdminViewVisibility = Visibility.Hidden;
        AddBookBTNVisibility = Visibility.Collapsed;


    }

    private void SetStoreShowcase(object obj)
    {
        StoreViewVisibility = Visibility.Hidden;
        StoreShowcaseVisibility = Visibility.Visible;
        BookInfoViewVisibility = Visibility.Collapsed;
        AdminViewVisibility = Visibility.Hidden;
        AddBookBTNVisibility = Visibility.Collapsed;

        if (obj is Button button)
        {
            StoreNumber = button.Name;
        }
    }


    private void SetBookInfoView(object obj)
    {
        StoreViewVisibility = Visibility.Hidden;
        StoreShowcaseVisibility = Visibility.Visible;
        BookInfoViewVisibility = Visibility.Visible;
        AddBookBTNVisibility = Visibility.Collapsed;

    }


    private void SetAdminView(object obj)
    {
        StoreViewVisibility = Visibility.Hidden;
        StoreShowcaseVisibility = Visibility.Visible;
        AdminViewVisibility = Visibility.Visible;

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


