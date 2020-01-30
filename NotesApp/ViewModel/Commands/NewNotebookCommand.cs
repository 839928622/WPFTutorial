using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModel.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public NewNotebookCommand(NotesVM vm)
        {
             VM = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //创建新的笔记合集
        }

        public NotesVM VM { get; set; }
    }
}
