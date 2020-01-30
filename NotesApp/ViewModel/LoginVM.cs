using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesApp.Model;
using NotesApp.ViewModel.Commands;

namespace NotesApp.ViewModel
{
  public  class LoginVM
    {
        public LoginVM()
        {
            Registercommand = new RegisterCommand(this);
            loginCommand = new LoginCommand(this);
        }

        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public RegisterCommand Registercommand { get; set; }
        public LoginCommand loginCommand { get; set; }


    }
}
