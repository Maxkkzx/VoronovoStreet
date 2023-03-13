﻿using System;
using System.Windows.Input;

namespace VoronovoStreet.View
{
	public class DelegateCommand : ICommand
	{
		private Action<object> _execute;
		private Func<object, bool> _canExecute;

		public DelegateCommand(Action<object> executeAction) : this(executeAction, null) { }
		public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
		{
			_canExecute = canExecuteFunc;
			_execute = executeAction;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			if (_canExecute != null)
				return _canExecute(parameter);
			else
				return true;
		}

		public void Execute(object parameter)
		{
			if (_execute != null)
				_execute(parameter);
		}
	}
}
