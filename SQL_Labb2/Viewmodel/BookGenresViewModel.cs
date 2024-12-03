using SQL_Labb2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Labb2.Viewmodel;

class BookGenresViewModel : ViewModelBase
{
    private readonly BookGenres _model;
    public ObservableCollection<Book> Books { get; }


    public string Genre
    {
        get => _model.Genre;
        set
        {
            _model.Genre = value;
            RaiseProperyChanged();
        }
    }



    public BookGenresViewModel()
    {
        this._model = new BookGenres(string.Empty);
        this.Books = new ObservableCollection<Book>();
    }

    public BookGenresViewModel(BookGenres model)
    {
        this._model = model;
        this.Books = new ObservableCollection<Book>(model.Books);
    }


}
