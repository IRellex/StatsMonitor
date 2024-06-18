// <summary>
// The original code is BaseDomainObject.cs
// </summary>
// <author>
// The initial developer of the original code is Josef Belmessabih.
// Copyright (c) 2020 CodeHC. All rights reserved.
// </author>

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Stats_Monitoring.Infrastructure
{
    /// <summary>
    ///     Base Class for DomainObject with property Change
    /// </summary>
    public class BaseDomainObject : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        ///     PropertyChanged Evenet
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Methods

        /// <summary>
        ///     Liefert den Namen eines Properties
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propertyLambda"></param>
        /// <returns></returns>
        public string GetPropertyName<TProperty>(Expression<Func<TProperty>> propertyLambda)
        {
            var type = GetType();

            var member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' referenziert eine Methode und keine Eigenschaft.", propertyLambda));

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' referenziert ein Feld und keine Eigenschaft.", propertyLambda));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType ?? throw new InvalidOperationException()))
                throw new ArgumentException(string.Format(
                    "Expression '{0}' referenziert eine Eigenschaft welche nicht vom Typ {1} ist.", propertyLambda,
                    type));

            return propInfo.Name;
        }

        /// <summary>
        ///     Führt das PropertyChangedEvent anhand eines Lambda Ausdrucks aus
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="propertyLambda"></param>
        public void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> propertyLambda)
        {
            var name = GetPropertyName(propertyLambda);
            OnPropertyChanged(name);
        }

        #endregion

        #region Protected / Internal Methods

        /// <summary>
        ///     Löst das OnPropertyChanged Event aus
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (PropertyChanged != null) handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}