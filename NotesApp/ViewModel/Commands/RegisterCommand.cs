using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        public RegisterCommand(LoginVM vm)
        {
            LoginVM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //登录的逻辑
            throw new NotImplementedException();
        }

        public LoginVM LoginVM { get; set; }
    }
}
