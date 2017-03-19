using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RssReader.Models
{
    class CommandTest:ICommand
    {
        Action ToDo;
        public event EventHandler CanExecuteChanged;

        public CommandTest(Action todo)
        {
            this.ToDo = todo;
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty((string)parameter);
        }

        public void Execute(object parameter)
        {
            ToDo();
        }
    }
}
