using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Model
{
  public  class NoteBook
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int userId;//the ower of notebook

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
            
    }
}
