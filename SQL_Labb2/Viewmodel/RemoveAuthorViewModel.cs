using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SQL_Labb2.Command;
using SQL_Labb2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQL_Labb2.Viewmodel
{
    internal class RemoveAuthorViewModel : ViewModelBase
    {
        public ObservableCollection<Författare> Authors { get; set; }

        public DelegateCommand RemoveAuthorCommand { get; }


        private Författare _selectedAuthor;
        public Författare SelectedAuthor
        {
            get => _selectedAuthor;
            set
            {
                _selectedAuthor = value;
                RaiseProperyChanged();
            }
        }


        public RemoveAuthorViewModel()
        {
            RemoveAuthorCommand = new DelegateCommand(RemoveBook);
            PopulateAuthors();
        }
        private void PopulateAuthors()
        {
            using var db = new DanielJohanssonContext();

            Authors = new ObservableCollection<Författare>(
                db.Författares.Where(f => !f.Isbns.Any()).ToList()
                );
        }


        private void RemoveBook(object obj)
        {
            if (SelectedAuthor != null)
            {
                using var db = new DanielJohanssonContext();

                var authorToRemove = db.Författares.Where(f => f.Id == SelectedAuthor.Id).FirstOrDefault();

                db.Författares.Remove(authorToRemove);

                db.SaveChanges();

                var currentWindow = obj as Window;
                if (currentWindow != null)
                {
                    currentWindow.Close();
                }
            }
            else
            {
                MessageBox.Show("You need to choose a Author.");
            }
        }
    }
}
