﻿using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Model
{
  public  class NoteBook : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private int userId;//the ower of notebook
        [Indexed]
        public int UserId
        {
            get { return userId; }
            set { userId = value; 
                OnPropertyChanged(nameof(UserId));

            }
        }



        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; 
                OnPropertyChanged(nameof(Name));
            }
        }
            
    }
}
