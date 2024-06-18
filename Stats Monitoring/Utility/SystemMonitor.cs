using LibreHardwareMonitor.Hardware;
using System;
using System.Linq;

public class SystemMonitor
{
    private Computer _computer;

    public SystemMonitor()
    {
        _computer = new Computer();
        _computer.Open();
        _computer.IsCpuEnabled = true;
        _computer.IsGpuEnabled = true;
        _computer.IsMemoryEnabled = true; 
    }

    public int GetCpuUsage()
    {
        int cpuUsage = 0;

        foreach (var hardwareItem in _computer.Hardware)
        {
            if (hardwareItem.HardwareType == HardwareType.Cpu)
            {
                hardwareItem.Update();

                foreach (var sensor in hardwareItem.Sensors)
                {
                    if (sensor.SensorType == SensorType.Load && sensor.Name == "CPU Total")
                    {
                        cpuUsage = (int)sensor.Value.GetValueOrDefault();
                        break;
                    }
                }

                break;
            }
        }

        return cpuUsage;
    }

    public int GetGpuUsage()
    {
        int gpuUsage = 0;

        foreach (var hardwareItem in _computer.Hardware)
        {
            if (hardwareItem.HardwareType == HardwareType.GpuNvidia || hardwareItem.HardwareType == HardwareType.GpuAmd)
            {
                hardwareItem.Update();

                foreach (var sensor in hardwareItem.Sensors)
                {
                    if (sensor.SensorType == SensorType.Load && sensor.Name == "GPU Core")
                    {
                        gpuUsage = (int)sensor.Value.GetValueOrDefault();
                        break;
                    }
                }

                break;
            }
        }

        return gpuUsage;
    }

    public int GetMemoryUsage()
    {
        int memoryUsage = 0;

        foreach (var hardwareItem in _computer.Hardware)
        {
            if (hardwareItem.HardwareType == HardwareType.Memory)
            {
                hardwareItem.Update();

                foreach (var sensor in hardwareItem.Sensors)
                {
                    if (sensor.SensorType == SensorType.Load && sensor.Name == "Memory")
                    {
                        memoryUsage = (int)sensor.Value.GetValueOrDefault();
                        break;
                    }
                }

                break;
            }
        }

        return memoryUsage;
    }

    public void Close()
    {
        _computer.Close();
    }
}
