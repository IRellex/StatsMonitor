// <summary>
// The original code is UnityConfiguration.cs
// </summary>
// <author>
// The initial developer of the original code is Josef Belmessabih.
// Copyright (c) 2020 CodeHC. All rights reserved.
// </author>

using System;
using System.Net.Http;
using Stats_Monitoring.Infrastructure;
using Stats_Monitoring.ViewModel;
using Unity;

namespace Stats_Monitoring.Config
{
    /// <summary>
    ///     Configuration class of unity container
    /// </summary>
    public class UnityConfiguration : IUnityConfiguration
    {
        #region Properties

        public static IUnityContainer Container { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Configures the IUnityContainer
        /// </summary>
        /// <returns></returns>
        public IUnityContainer SetupContainer()
        {
            return SetupContainer(new UnityContainer());
        }

        /// <summary>
        ///     Configures the IUnityContainer
        /// </summary>
        /// <returns></returns>
        public IUnityContainer SetupContainer(IUnityContainer container)
        {
            Container = container;
            RegisterDependencies();
            RegisterServices();
            RegisterViews();
            RegisterViewModels();
            return container;
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Register dependencies to unity Container
        /// </summary>
        private void RegisterDependencies()
        {
            Container.RegisterSingleton<SystemMonitor>();
        }

        /// <summary>
        ///     Register services to unity Container
        /// </summary>
        private void RegisterServices()
        {
        }

        /// <summary>
        ///     Register view models to unity Container
        /// </summary>
        private void RegisterViewModels()
        {
            Container.RegisterSingleton<MainWindowViewModel>();
            Container.RegisterType<ProgressBarWidgetViewModel>();
        }

        /// <summary>
        ///     Register views to unity Container
        /// </summary>
        private void RegisterViews()
        {
        }

        #endregion
    }
}