using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeddingStoreDesktop.Converters
{
    public class ConvertTinhTrangHoaDonToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int tinhTrang = (int)value;
            string img = "";
            switch (tinhTrang)
            {
                case 0:
                    img = "ChuaTrangTri.png";
                    break;
                case 1:
                    img = "DaTrangTri.png";
                    break;
                case 2:
                    img = "DaThaoDo.png";
                    break;
            }
            return "/WeddingStoreDesktop;component/Images/" + img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
