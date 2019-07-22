using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeddingStoreDesktop.Converters
{
    public class ConvertThanhToanToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isThanhToan = (bool)value;
            if(isThanhToan)
                return "/WeddingStoreDesktop;component/Images/DaThanhToan.png";
            else
                return "/WeddingStoreDesktop;component/Images/ChuaThanhToan.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
