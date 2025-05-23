using E.V.O_.Models.Occupation;
using System.Globalization;
using System.Windows.Data;

namespace E.V.O_.UI.Converters
{
    public class StatusImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"pack://application:,,,/Resources/Icons/{(OccupationType)value}Status.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
