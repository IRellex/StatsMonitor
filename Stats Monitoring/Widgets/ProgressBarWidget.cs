// <summary>
// The original code is ProgressBarWidgetControl.cs
// </summary>
// <author>
// The initial developer of the original code is .
// Copyright (c) 2024 Suragus GmbH. All rights reserved.
// </author>

using System;
using System.Windows.Controls;
using Stats_Monitoring.Config;
using Stats_Monitoring.Controls;
using Stats_Monitoring.Infrastructure;
using Stats_Monitoring.Interface;
using Stats_Monitoring.ViewModel;
using Unity;

namespace Stats_Monitoring.Widgets;

public class ProgressBarWidget : BaseDomainObject, IWidget
{
    private readonly Func<int> _valueUpdateDelegate;

    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    public ProgressBarWidget(Func<int> valueUpdateDelegate, int value, string description, int maxValue, int minValue,
        string title, string unit)
    {
        _valueUpdateDelegate = valueUpdateDelegate;
        Control = UnityConfiguration.Container.Resolve<ProgressBarWidgetControl>();
        ProgressBarWidgetViewModel progressBarWidgetViewModel = UnityConfiguration.Container.Resolve<ProgressBarWidgetViewModel>();
        progressBarWidgetViewModel.Value = value;
        progressBarWidgetViewModel.Description = description;
        progressBarWidgetViewModel.MaxValue = maxValue;
        progressBarWidgetViewModel.MinValue = minValue;
        progressBarWidgetViewModel.Title = title;
        progressBarWidgetViewModel.Unit = unit;
        ViewModel = progressBarWidgetViewModel;

        Control.DataContext = ViewModel;
        Control.Height = 300;
        Control.Width = 300;
    }

    #region Implementation of IWidget

    public UserControl Control { get; set; }
    public IUnityBaseViewModel ViewModel { get; set; }
    public void Update()
    {
        ((ProgressBarWidgetViewModel)ViewModel).Value = _valueUpdateDelegate.Invoke();
    }

    #endregion
}