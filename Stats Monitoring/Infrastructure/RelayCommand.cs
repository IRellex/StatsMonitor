// <summary>
// The original code is RelayCommand.cs
// </summary>
// <author>
// The initial developer of the original code is Josef Belmessabih.
// Copyright (c) 2020 CodeHC. All rights reserved.
// </author>

using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Stats_Monitoring.Infrastructure
{
    public interface IRelayCommand
    {
        #region Events

        event EventHandler CanExecuteChanged;

        #endregion

        #region Public Methods

        bool CanExecute(object parameter);
        void Execute(object parameter);

        #endregion
    }

    public class RelayCommand : RelayCommand<object>, IRelayCommand
    {
        #region Constructors

        public RelayCommand(Action<object> execute) : base(execute)
        {
        }

        public RelayCommand(Action execute) : base(execute)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute) : base(execute, canExecute)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute) : base(execute, canExecute)
        {
        }

        #endregion
    }

    public class RelayCommand<T> : ICommand
    {
        #region Fields

        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        #endregion

        #region Constructors

        public RelayCommand(Action<T> execute) : this(execute, null)
        {
        }

        public RelayCommand(Action execute) : this(o => execute())
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute) : this(o => execute(), o => canExecute())
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T) parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter)
        {
            _execute((T) parameter);
        }

        #endregion
    }
}