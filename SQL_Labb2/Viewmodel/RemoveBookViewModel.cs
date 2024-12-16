using Microsoft.EntityFrameworkCore;
using SQL_Labb2.Command;
using SQL_Labb2.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQL_Labb2.Viewmodel;

class RemoveBookViewModel : ViewModelBase
{
    public DelegateCommand RemoveBookCommand { get; }


    private string _isbn;
    public string Isbn
    {
        get => _isbn;
        set
        {
            _isbn = value;
            RaiseProperyChanged();
        }
    }

    public RemoveBookViewModel()
    {
        RemoveBookCommand = new DelegateCommand(RemoveBook);
    }

    private void RemoveBook(object obj)
    {
        Debug.WriteLine(Isbn ?? "");
        if (Isbn != null)
        {
            using var db = new DanielJohanssonContext();

            var bToRemove = db.Böckers
                .Include(b => b.LagerSaldos)
                .Include(b => b.OrderInfos)
                .Include(b => b.IsbnNavigation)
                .Include(b => b.Författares)
                .FirstOrDefault(b => b.Isbn == Isbn);


            db.BokInformations.Remove(bToRemove.IsbnNavigation);
            db.Böckers.Remove(bToRemove);

            db.SaveChanges();

            var currentWindow = obj as Window;
            currentWindow.Close();
        }
        else
        {
            MessageBox.Show("Isbn cannot be null.");
        }
    }
}
