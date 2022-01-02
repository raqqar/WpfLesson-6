using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfLesson_6
{
    internal class WeatherControl:DependencyObject

    {
        public static readonly DependencyProperty TemperatureProperty;
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                    new ValidateValueCallback(ValidateTemperature)
                    );       
        }

        private static bool ValidateTemperature(object value)
        {
            int val = (int)value;
            if (val >= -100 && val <= 100)
                return true;
            else
                return false;
        }
        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int val= (int)baseValue;
            if (val < -50)
                return -50;
            else if (val >= -50 && val <= 50)
                return val;
            else if (val > 50)
                return 50;
            else
                return 0;
        }
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public int Temperature
        {
            get { return (int)GetValue(TemperatureProperty); }
            set { SetValue(TemperatureProperty, value); }
        }

        public enum WeatherType 
        {
            Sunny=0,
            Cloudy=1,
            Rain=2,
            Snow=3,
        }
    }



   
}
