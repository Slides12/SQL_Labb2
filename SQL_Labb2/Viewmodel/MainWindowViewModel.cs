using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SQL_Labb2.Command;

namespace SQL_Labb2.Viewmodel;

internal class MainWindowViewModel : ViewModelBase
{
    public StoreViewModel MenuViewModel { get; }
    public StoreShowcaseViewModel StoreShowcaseViewModel { get; }
    public ObservableCollection<BookGenresViewModel> Books { get; set; }


    public DelegateCommand FullscreenCommand { get; }
    public DelegateCommand ExitCommand { get; }

    private BookGenresViewModel? _activePack;
    public BookGenresViewModel? ActiveBook
    {
        get => _activePack;
        set
        {
            _activePack = value;
            RaiseProperyChanged();
            StoreShowcaseViewModel?.RaiseProperyChanged("ActivePack");
        }
    }

    public MainWindowViewModel()
    {
        FullscreenCommand = new DelegateCommand(SetFullscreen);
        ExitCommand = new DelegateCommand(Exit);


        ActiveBook = new BookGenresViewModel();
        StoreShowcaseViewModel = new StoreShowcaseViewModel(this);
        MenuViewModel = new StoreViewModel(this);
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


