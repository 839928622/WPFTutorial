using NotesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModel.Commands
{
    public class NewNoteCommand : ICommand
    {
        public NewNoteCommand(NotesVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            NoteBook notebook = parameter as NoteBook;
            if (notebook != null)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            //要获取到选中的notebook的id
            NoteBook notebook = parameter as NoteBook;
            VM.CreateNewNote(notebook.Id);
            //创建新的笔记
        }

        public NotesVM VM { get; set; }
    }
}
