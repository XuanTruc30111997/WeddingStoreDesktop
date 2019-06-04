using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeddingStoreDesktop.Views
{
    /// <summary>
    /// Interaction logic for ucChiTietHoaDon.xaml
    /// </summary>
    public partial class ucChiTietHoaDon : UserControl
    {
        private string _maHD;
        ViewModels.ucChiTietHoaDonViewModel vm;
        public ucChiTietHoaDon(string maHD)
        {
            InitializeComponent();
            _maHD = maHD;
            vm = new ViewModels.ucChiTietHoaDonViewModel(_maHD);
            DataContext = vm;
        }

        private void SanPham_Click(object sender, MouseButtonEventArgs e)
        {
            ClearGrid();
            gridThongTinMau.Children.Add(new ucThongTinSanPham(vm.SelectedMau.MaSP));
            gridChiTietMau.Children.Add(new ucChiTietSanPham(vm.SelectedMau.MaSP, _maHD));
        }

        void ClearGrid()
        {
            gridThongTinMau.Children.Clear();
            gridChiTietMau.Children.Clear();
        }
    }
}
