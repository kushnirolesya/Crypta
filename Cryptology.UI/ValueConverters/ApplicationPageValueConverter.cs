using System;
using System.Diagnostics;
using System.Globalization;

namespace Cryptology.UI
{
    internal class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Choose:
                    return new ChoosePage();
                case ApplicationPage.CaesarAlgorithm:
                    return new CaesarAlgorithmPage();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
