using SQL_Labb2.Viewmodel;
using SQL_Labb2.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQL_Labb2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel() { AddBooks = OpenAddBookWindow, RemoveBooks = OpenRemoveBookWindow};
        }

        private void OpenAddBookWindow()
        {
            new AddBookWindow().Show();
        }

        private void OpenRemoveBookWindow()
        {
            new RemoveBookWindow().Show();
        }
    }
}