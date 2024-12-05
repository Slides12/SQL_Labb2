using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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



    public MainWindowViewModel()
    {
        // Delegates
        FullscreenCommand = new DelegateCommand(SetFullscreen);
        ExitCommand = new DelegateCommand(Exit);

        
        
        
        // ViewModels
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


