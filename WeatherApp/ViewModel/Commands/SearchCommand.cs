using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
  public  class SearchCommand:ICommand
    {
        private readonly WeatherVM _vm;

        public SearchCommand(WeatherVM vm)
        {
            _vm = vm;//为了能够访问WeatherVM中的MakeQuery方法，需要把该实例注入进来
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            var query = parameter as string;
            return !string.IsNullOrWhiteSpace(query);//页面上，如果输入的字符串是空的，那么Execute方法就不能执行（即返回false）
        }

        public void Execute(object parameter)
        {
           _vm.MakeQuery();
        }

    }
}
