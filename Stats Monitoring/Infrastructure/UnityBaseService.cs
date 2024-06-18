// <summary>
// The original code is UnityBaseService.cs
// </summary>
// <author>
// The initial developer of the original code is Josef Belmessabih.
// Copyright (c) 2020 CodeHC. All rights reserved.
// </author>

using System.Linq;
using Stats_Monitoring.Config;
using Unity;

namespace Stats_Monitoring.Infrastructure
{
    /// <summary>
    ///     Base Service with unity auto resolve dependency attribute
    /// </summary>
    public class UnityBaseService : IUnityBaseService
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="T:Suragus.Suite.Visual.Mvvm.ViewModels.SuiteBaseViewModel" /> class.
        /// </summary>
        public UnityBaseService()
        {
            var propertiesToInject = GetType().GetProperties()
                .Where(prop => prop.IsDefined(typeof(DependencyAttribute), false));
            foreach (var propertyInfo in propertiesToInject)
                propertyInfo.SetValue(this, UnityConfiguration.Container.Resolve(propertyInfo.PropertyType));
        }

        #endregion
    }
}