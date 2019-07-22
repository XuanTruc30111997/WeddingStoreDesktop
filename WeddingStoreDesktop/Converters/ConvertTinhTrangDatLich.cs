using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeddingStoreDesktop.Converters
{
    public class ConvertTinhTrangDatLich : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int tinhTrang = (int)value;
            string img = "";
            switch (tinhTrang)
            {
                case 0:
                    img = "ChuaDuyet.png";
                    break;
                case 1:
                    img = "ChuaGap.png";
                    break;
                case 2:
                    img = "DaGap.png";
                    break;
                case 3:
                    img = "KhongDongYLap.png";
                    break;
                case 4:
                    img = "DongYLap.png";
                    break;
                case 5:
                    img = "DaLap.png";
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
