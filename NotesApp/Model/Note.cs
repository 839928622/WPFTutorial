using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Model
{
  public   class Note : INotifyPropertyChanged
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

        private int noteBookId; //notebook whick note belongs to
        [Indexed]
        public int NoteBookId
        {
            get { return noteBookId; }
            set { noteBookId = value;
                OnPropertyChanged(nameof(NoteBookId));

            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; 
                OnPropertyChanged(nameof(Title));

            }
        }

        private DateTime createdTime;

        public DateTime CreatedTime
        {
            get { return createdTime; }
            set { createdTime = value;
                OnPropertyChanged(nameof(CreatedTime));

            }
        }

        private DateTime updateTime;

        public DateTime UpdateTime

        {
            get { return updateTime; }
            set { updateTime = value; 
                OnPropertyChanged(nameof(UpdateTime));

            }
        }


        private string fileLocation; //file path
        public string FileLocation
        {
            get { return fileLocation; }
            set { fileLocation = value;
                OnPropertyChanged(nameof(FileLocation));

            }
        }


    }
}
