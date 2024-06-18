// <summary>
// The original code is AsyncCommand.cs
// </summary>
// <author>
// The initial developer of the original code is Josef Belmessabih.
// Copyright (c) 2020 CodeHC. All rights reserved.
// </author>

using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Stats_Monitoring.Infrastructure
{
    public class AsyncCommand : IAsyncCommand
    {
        #region Fields

        private readonly Func<bool> _canExecute;
        private readonly IErrorHandler _errorHandler;
        private readonly Func<Task> _execute;

        private bool _isExecuting;

        #endregion

        #region Constructors

        public AsyncCommand(Func<Task> execute, Func<bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Public Methods

        public bool CanExecute()
        {
            return !_isExecuting && (_canExecute?.Invoke() ?? true);
        }

        public async Task ExecuteAsync()
        {
            if (CanExecute())
                try
                {
                    _isExecuting = true;
                    await _execute();
                }
                finally
                {
                    _isExecuting = false;
                }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Explicit implementations

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            ExecuteAsync().FireAndForgetSafeAsync(_errorHandler);
        }

        #endregion
    }

    public class AsyncCommand<T> : IAsyncCommand<T>
    {
        #region Fields

        private readonly Func<T, bool> _canExecute;
        private readonly IErrorHandler _errorHandler;
        private readonly Func<T, Task> _execute;

        private bool _isExecuting;

        #endregion

        #region Constructors

        public AsyncCommand(Func<T, Task> execute, Func<T, bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Public Methods

        public bool CanExecute(T parameter)
        {
            return !_isExecuting && (_canExecute?.Invoke(parameter) ?? true);
        }

        public async Task ExecuteAsync(T parameter)
        {
            if (CanExecute(parameter))
                try
                {
                    _isExecuting = true;
                    await _execute(parameter);
                }
                finally
                {
                    _isExecuting = false;
                }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Explicit implementations

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute((T) parameter);
        }

        void ICommand.Execute(object parameter)
        {
            ExecuteAsync((T) parameter).FireAndForgetSafeAsync(_errorHandler);
        }

        #endregion
    }
}