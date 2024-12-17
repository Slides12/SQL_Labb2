using SQL_Labb2.Model;
using SQL_Labb2.Viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SQL_Labb2.Windows
{
    /// <summary>
    /// Interaction logic for RemoveAuthorsWindow.xaml
    /// </summary>
    public partial class RemoveAuthorsWindow : Window
    {
        public RemoveAuthorsWindow()
        {
            InitializeComponent();
            DataContext = new RemoveAuthorViewModel();
        }
    }
}
