using SQL_Labb2.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
            DataContext = new AddBookViewModel();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^\d*$");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true; 
            }

            var textbox = sender as TextBox;
            if (textbox != null)
            {
                if (textbox.Text.Length >= 13 || (textbox.Text.StartsWith("9") == false && textbox.Text.Length > 0))
                {
                    e.Handled = true; 
                }
            }
        }
    }
}
