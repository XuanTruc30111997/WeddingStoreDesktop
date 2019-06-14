using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeddingStoreDesktop.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    public class ConvertNgayToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value==null)
                return "/WeddingStoreDesktop;component/Images/noimage.png";

            bool isTrangTri = (bool)value;
            if(isTrangTri)
                return "/WeddingStoreDesktop;component/Images/ThaoDo.png";
            else
                return "/WeddingStoreDesktop;component/Images/TrangTri.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
