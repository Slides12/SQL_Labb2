using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SQL_Labb2.Command;

namespace SQL_Labb2.Viewmodel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        public DelegateCommand FullscreenCommand { get; }
        public DelegateCommand ExitCommand { get; }

        public MainWindowViewModel()
        {
            FullscreenCommand = new DelegateCommand(SetFullscreen);
            ExitCommand = new DelegateCommand(Exit);
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
}


