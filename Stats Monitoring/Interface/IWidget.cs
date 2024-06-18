// <summary>
// The original code is IWid´get.cs
// </summary>
// <author>
// The initial developer of the original code is .
// Copyright (c) 2024 Suragus GmbH. All rights reserved.
// </author>

using System;
using System.Windows.Controls;
using Stats_Monitoring.Infrastructure;

namespace Stats_Monitoring.Interface;

public interface IWidget
{
    public UserControl Control { get; set; }

    public IUnityBaseViewModel ViewModel { get; set; }

    public void Update();

}