using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DesktopContactsApp.Classes
{
  public  class Contact
    {
        [PrimaryKey,AutoIncrement]//Id还会自动增长 类似EF中的Identity
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
