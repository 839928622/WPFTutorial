using NotesApp.Model;
using NotesApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.ViewModel
{
 public   class NotesVM
    {
        public NotesVM()
        {
            NewNotebook = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
        }
        public ObservableCollection<NoteBook> Notebooks { get; set; }

        private NoteBook selectedNotebook;

        public NoteBook SelectedNotebook
        {
            get { return selectedNotebook; }
            set { selectedNotebook = value;
//TODO:这里当用户选择某个笔记的时候，需要向后台发起请求，获取笔记
            }
        }

        public ObservableCollection<Note> Notes { get; set; }//选中之后，就可以拿出具体的笔记来了

        public NewNotebookCommand NewNotebook { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }

    }
}
