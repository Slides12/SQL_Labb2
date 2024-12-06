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
    public StoreViewModel MenuViewModel { get; }
    public StoreShowcaseViewModel StoreShowcaseViewModel { get; }
    public DanielJohanssonContext db { get; set; }

    public DelegateCommand FullscreenCommand { get; }
    public DelegateCommand ExitCommand { get; }
    public DelegateCommand SetStoreViewCommand { get; }
    public DelegateCommand SetStoreShowcaseCommand { get; }
    public DelegateCommand SetBookInfoViewCommand { get; }


    private string _storeNumber;

    public string StoreNumber
    {
        get => _storeNumber;
        set
        {
            _storeNumber = value;
            SetStorePic(_storeNumber);
            SetStoreID(_storeNumber);
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
            RaiseProperyChanged("StoreNumber");
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


    public MainWindowViewModel()
    {
        // Delegates
        FullscreenCommand = new DelegateCommand(SetFullscreen);
        ExitCommand = new DelegateCommand(Exit);
        SetStoreViewCommand = new DelegateCommand(SetStoreView);
        SetStoreShowcaseCommand = new DelegateCommand(SetStoreShowcase);
        SetBookInfoViewCommand = new DelegateCommand(SetBookInfoView);

        // Visibility
        StoreViewVisibility = Visibility.Visible;
        StoreShowcaseVisibility = Visibility.Hidden;
        BookInfoViewVisibility = Visibility.Hidden;


        // ViewModels
        StoreShowcaseViewModel = new StoreShowcaseViewModel(this);
        MenuViewModel = new StoreViewModel(this);

        
    }

    private void SetStorePic(string store)
    {
        StorePic = store switch
        {
            "B1" => new BitmapImage(new Uri("/Assets/Adlibris.png", UriKind.Relative)),
            "B2" => new BitmapImage(new Uri("/Assets/Amazon.jpeg", UriKind.Relative)),
            "B3" => new BitmapImage(new Uri("/Assets/SciFi.png", UriKind.Relative)),
            _ => null  
        };
    }


    private void SetStoreID(string store)
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
        }
    }


    private void SetStoreView(object obj)
    {
        StoreViewVisibility = Visibility.Visible;
        StoreShowcaseVisibility = Visibility.Hidden;
        BookInfoViewVisibility = Visibility.Hidden;

        
    }

    private void SetStoreShowcase(object obj)
    {
        StoreViewVisibility = Visibility.Hidden;
        StoreShowcaseVisibility = Visibility.Visible;
        BookInfoViewVisibility = Visibility.Collapsed;
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


