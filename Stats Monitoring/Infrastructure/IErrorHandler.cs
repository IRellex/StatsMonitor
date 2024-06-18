// <summary>
// The original code is IErrorHandler.cs
// </summary>
// <author>
// The initial developer of the original code is Josef Belmessabih.
// Copyright (c) 2020 CodeHC. All rights reserved.
// </author>

using System;

namespace Stats_Monitoring.Infrastructure
{
    public interface IErrorHandler
    {
        #region Public Methods

        void HandleError(Exception ex);

        #endregion
    }
}