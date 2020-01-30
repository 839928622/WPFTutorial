using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Model
{
  public  class User: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
      
        protected virtual void OnPropertyChanged( string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;
        [PrimaryKey,AutoIncrement]//主键且自动增长
        public int Id
        {
            get { return id; }
            set { id = value; 
                OnPropertyChanged(nameof(Id));
            }
        }

        private string name;
        [MaxLength(50)]
        public string Name
        {
            get { return name; }
            set { name = value; 
                OnPropertyChanged(nameof(Name));
            }
        }

        private string lastName;
        [MaxLength(50)]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; 
                OnPropertyChanged(nameof(LastName));

            }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string password;


        public string Password
        {
            get { return password; }
            set { password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


    }
}
