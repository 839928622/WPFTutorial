using NotesApp.Model;
using NotesApp.ViewModel.Commands;
using SQLite;
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
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            Notebooks = new ObservableCollection<NoteBook>();
            Notes = new ObservableCollection<Note>();
            ReadNotebooks();//读取笔记合集
        }
        public ObservableCollection<NoteBook> Notebooks { get; set; }

        private NoteBook selectedNotebook;

        public NoteBook SelectedNotebook
        {
            get { return selectedNotebook; }
            set { selectedNotebook = value;
                //TODO:这里当用户选择某个笔记的时候，需要向后台发起请求，获取笔记
                ReadNotes();
            }
        }

        public ObservableCollection<Note> Notes { get; set; }//选中之后，就可以拿出具体的笔记来了

        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }



        //创建新笔记的方法
        public void CreateNewNote(int notebookId)
        {
            var newNote = new Note
            {
                NoteBookId = notebookId,
                CreatedTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                Title = "新笔记",

                
            };
            DatabaseHelper.Insert<Note>(newNote);
            //添加完毕之后读取一下笔记
            ReadNotes();
        }

        //创建新的笔记合集
        public void CreateNewNotebook()
        {
            NoteBook newNotebook = new NoteBook
            {
                Name = "新笔记合集"
            };

            DatabaseHelper.Insert(newNotebook);
            ReadNotebooks();//插入新笔记合集之后要读取一次到Notebools属性
        }
        //读取本地存储的notebook
        public void ReadNotebooks()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelper.dbFile))
            {
               var noteBooksInLocalDb = connection.Table<NoteBook>().ToList();//从本地数据库中获取笔记合集
                Notebooks.Clear();//清除Notebooks属性，放置溢出

                foreach (var notebook in noteBooksInLocalDb)
                {
                    Notebooks.Add(notebook);
                }
            }
        }
        //根据notebook的id获取笔记合集下的笔记

        public void ReadNotes()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelper.dbFile))
            {
                if (SelectedNotebook != null)
                {

                    var notesInLocalDb = connection.Table<Note>().Where(N => N.NoteBookId == SelectedNotebook.Id).ToList();//从本地数据库中获取笔记合集
                    Notes.Clear();//清除Notebooks属性，放置溢出

                    foreach (var note in notesInLocalDb)
                    {
                        Notes.Add(note);
                    }
                }
            }
        }
    }
}
