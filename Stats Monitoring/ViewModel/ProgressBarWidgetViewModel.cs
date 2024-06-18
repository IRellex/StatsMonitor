// <summary>
// The original code is ProgressBarWidgetViewModel.cs
// </summary>
// <author>
// The initial developer of the original code is .
// Copyright (c) 2024 Suragus GmbH. All rights reserved.
// </author>

using Stats_Monitoring.Infrastructure;

namespace Stats_Monitoring.ViewModel;

public class ProgressBarWidgetViewModel : UnityBaseViewModel
{
    /// <summary>
    ///     Field for MinValue
    /// </summary>
    private int _minValue;

    /// <summary>
    ///     Delivers or sets MinValue
    /// </summary>
    public int MinValue
    {
        get => _minValue;
        set
        {
            _minValue = value;
            RaisePropertyChanged(() => MinValue);
        }
    }

    /// <summary>
    ///     Field for MaxValue
    /// </summary>
    private int _maxValue;

    /// <summary>
    ///     Delivers or sets MaxValue
    /// </summary>
    public int MaxValue
    {
        get => _maxValue;
        set
        {
            _maxValue = value;
            RaisePropertyChanged(() => MaxValue);
        }
    }

    /// <summary>
    ///     Field for Value
    /// </summary>
    private int _value;

    /// <summary>
    ///     Delivers or sets Value
    /// </summary>
    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            RaisePropertyChanged(() => Value);
        }
    }

    /// <summary>
    ///     Field for Unit
    /// </summary>
    private string _unit;

    /// <summary>
    ///     Delivers or sets Unit
    /// </summary>
    public string Unit
    {
        get => _unit;
        set
        {
            _unit = value;
            RaisePropertyChanged(() => Unit);
        }
    }

    /// <summary>
    ///     Field for Title
    /// </summary>
    private string _title;

    /// <summary>
    ///     Delivers or sets Title
    /// </summary>
    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            RaisePropertyChanged(() => Title);
        }
    }

    /// <summary>
    ///     Field for Description
    /// </summary>
    private string _description;

    /// <summary>
    ///     Delivers or sets Description
    /// </summary>
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            RaisePropertyChanged(() => Description);
        }
    }
}