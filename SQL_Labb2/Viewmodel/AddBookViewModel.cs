using Microsoft.EntityFrameworkCore;
using SQL_Labb2.Command;
using SQL_Labb2.Model;
using SQL_Labb2.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace SQL_Labb2.Viewmodel;

internal class AddBookViewModel : ViewModelBase
{

    public ObservableCollection<Böcker> DbBooks { get; set; }



    public AddBookViewModel()
    {


        PopulateAdminBookListAsync();
    }

    

    public void PopulateAdminBookListAsync()
    {
        using var db = new DanielJohanssonContext();

        DbBooks = new ObservableCollection<Böcker>
            (
                db.Böckers
                .Include(b => b.LagerSaldos)
                .Include(b => b.IsbnNavigation)
                .Include(b => b.Författares)
                .ToList()
            );
        RaiseProperyChanged("DbBooks");

    }
}
