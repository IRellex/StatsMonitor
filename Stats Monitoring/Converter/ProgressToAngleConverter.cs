using System;
using System.Globalization;
using System.Windows.Data;

namespace Stats_Monitoring.Converter
{
    public class ProgressToAngleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || !(values[0] is double) || !(values[1] is double))
                return null;

            double progressValue = (double)values[0];
            double maxValue = (double)values[1];

            if (maxValue <= 0)
                return 0;

            // Calculate the angle based on the progress value and maximum value
            double angle = 360 * (progressValue / maxValue);

            // Ensure angle is within valid range (0-360 degrees)
            angle = Math.Min(Math.Max(angle, 0), 360);

            return angle;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}