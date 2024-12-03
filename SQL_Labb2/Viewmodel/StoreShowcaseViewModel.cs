using SQL_Labb2.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_Labb2.Model;

namespace SQL_Labb2.Viewmodel;

class StoreShowcaseViewModel : ViewModelBase
{
    private readonly MainWindowViewModel mainWindowViewModel;
    public DelegateCommand AddBookCommand { get; }

    public ObservableCollection<Book> Books { get; set; }


    public StoreShowcaseViewModel(MainWindowViewModel? mainWindowViewModel)
    {
        this.mainWindowViewModel = mainWindowViewModel;

        AddBookCommand = new DelegateCommand(AddBook);

    }

    private void AddBook(object obj)
    {
        mainWindowViewModel.ActiveBook?.Books.Add(new Book());
    }

}
