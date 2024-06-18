// <summary>
// The original code is IAsyncCommand.cs
// </summary>
// <author>
// The initial developer of the original code is Josef Belmessabih.
// Copyright (c) 2020 CodeHC. All rights reserved.
// </author>

using System.Threading.Tasks;
using System.Windows.Input;

namespace Stats_Monitoring.Infrastructure
{
    public interface IAsyncCommand : ICommand
    {
        #region Public Methods

        bool CanExecute();
        Task ExecuteAsync();

        #endregion
    }

    public interface IAsyncCommand<T> : ICommand
    {
        #region Public Methods

        bool CanExecute(T parameter);
        Task ExecuteAsync(T parameter);

        #endregion
    }
}