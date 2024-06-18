// <summary>
// The original code is IUnityConfiguration.cs
// </summary>
// <author>
// The initial developer of the original code is Josef Belmessabih.
// Copyright (c) 2020 CodeHC. All rights reserved.
// </author>

using Unity;

namespace Stats_Monitoring.Infrastructure
{
    public interface IUnityConfiguration
    {
        #region Public Methods

        /// <summary>
        ///     Configures the IUnityContainer
        /// </summary>
        /// <returns></returns>
        IUnityContainer SetupContainer(IUnityContainer container);

        #endregion
    }
}