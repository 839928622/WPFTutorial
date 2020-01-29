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

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int noteBookId; //notebook whick note belongs to

        public int NoteBookId
        {
            get { return noteBookId; }
            set { noteBookId = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private DateTime createdTime;

        public DateTime CreatedTime
        {
            get { return createdTime; }
            set { createdTime = value; }
        }

        private DateTime updateTime;

        public DateTime UpdateTime

        {
            get { return updateTime; }
            set { updateTime = value; }
        }


        private string fileLocation; //file path
        public string FileLocation
        {
            get { return fileLocation; }
            set { fileLocation = value; }
        }


    }
}
