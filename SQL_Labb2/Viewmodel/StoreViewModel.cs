using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Labb2.Viewmodel;

class StoreViewModel : ViewModelBase
{
    private readonly MainWindowViewModel mainWindowViewModel;

    public StoreViewModel(MainWindowViewModel? mainWindowViewModel)
    {
        this.mainWindowViewModel = mainWindowViewModel;
    }
}
