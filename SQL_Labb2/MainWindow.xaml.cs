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
        private MainWindowViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel = new MainWindowViewModel() 
            { 
                AddBooks = OpenAddBookWindow, 
                RemoveBooks = OpenRemoveBookWindow,
                RemoveAuthors = OpenRemoveAuthorsWindow
            };
        }

        private void OpenAddBookWindow()
        {
            bool? result =  new AddBookWindow().ShowDialog();
            if(result != true)
            {
                viewModel.StoreShowcaseViewModel.PopulateAdminBookListAsync();
                viewModel.StoreShowcaseViewModel.PopulateGenreButtonListAsync();
            }
        }

        private void OpenRemoveBookWindow()
        {
            bool? result = new RemoveBookWindow().ShowDialog();
            if (result != true)
            {
                viewModel.StoreShowcaseViewModel.PopulateAdminBookListAsync();
                viewModel.StoreShowcaseViewModel.PopulateGenreButtonListAsync();
            }
        }

        private void OpenRemoveAuthorsWindow()
        {
            bool? result = new RemoveAuthorsWindow().ShowDialog();
        }
    }
}