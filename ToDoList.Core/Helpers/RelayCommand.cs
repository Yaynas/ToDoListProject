﻿using System.Diagnostics;
using System.Windows.Input;

namespace ToDoList.Core
{
    public class RelayCommand : ICommand
    {
        private Action mAction;
        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action action)
        {
            mAction = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            mAction();
        }
    }
}
