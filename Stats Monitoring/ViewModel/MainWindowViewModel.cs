// <summary>
// The original code is MainWindowViewModel.cs
// </summary>
// <author>
// The initial developer of the original code is .
// Copyright (c) 2024 Suragus GmbH. All rights reserved.
// </author>

using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using LibreHardwareMonitor.Hardware.Cpu;
using Stats_Monitoring.Infrastructure;
using Stats_Monitoring.Interface;
using Stats_Monitoring.Widgets;
using Unity;

namespace Stats_Monitoring.ViewModel;

public class MainWindowViewModel : UnityBaseViewModel
{
    [Dependency]
    public SystemMonitor SystemMonitor { get; set; }
    /// <summary>
    ///     Initializes a new instance of <see cref="T:Suragus.Suite.Visual.Mvvm.ViewModels.SuiteBaseViewModel" /> class.
    /// </summary>
    public MainWindowViewModel()
    {
        Widgets = new ObservableCollection<IWidget>();

        SystemMonitor systemMonitor = new SystemMonitor();

        ProgressBarWidget cpuWidget = new ProgressBarWidget(() => systemMonitor.GetCpuUsage(), 0, "Prozessor auslastung", 100, 0, "Prozessor", "%");
        ProgressBarWidget gpuWidget = new ProgressBarWidget(() => systemMonitor.GetCpuUsage(), 0, "Grafikkarte auslastung", 100, 0, "Grafikkarte", "%");
        ProgressBarWidget memoryWidget = new ProgressBarWidget(() => systemMonitor.GetMemoryUsage(), 0, "Arbeitsspeicher auslastung", 100, 0, "Arbeitsspeicher", "%");

        Widgets.Add(cpuWidget);
        Widgets.Add(gpuWidget);
        Widgets.Add(memoryWidget);

        System.Timers.Timer updateTimer = new System.Timers.Timer(200);
        updateTimer.Elapsed += UpdateTimerOnElapsed;
        updateTimer.Start();

    }

    private void UpdateTimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        foreach (IWidget widget in Widgets)
        {
            Task.Run(() => widget.Update());
        }
    }

    /// <summary>
    ///     Field for Widgets
    /// </summary>
    private ObservableCollection<IWidget> _widgets;

    /// <summary>
    ///     Delivers or sets Widgets
    /// </summary>
    public ObservableCollection<IWidget> Widgets
    {
        get => _widgets;
        set
        {
            _widgets = value;
            RaisePropertyChanged(() => Widgets);
        }
    }
    
}