using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Media.Playback;
using Windows.UI.Xaml.Controls;

namespace RssReader.Models
{
    public class Command : ICommand
    {
        Action ToDo;
        Func<bool> canEx;

        public event EventHandler CanExecuteChanged;

        public Command(Action todo,Func<bool> canExec)
        {
            this.ToDo = todo;
            canEx = canExec;
        }

        public bool CanExecute(object parameter)
        {
            return canEx();
        }

        public void Execute(object parameter)
        {
            ToDo();
        }
    }
}
