using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using WeddingStoreDesktop.Command;
using WeddingStoreDesktop.Interfaces.Dialog;
using WeddingStoreDesktop.Models;
using WeddingStoreDesktop.Models.SystemModel;
using WeddingStoreDesktop.Views;

namespace WeddingStoreDesktop.ViewModels
{
    public class DangNhapViewModel : BaseViewModel
    {
        private string _UserName { get; set; }
        public string UserName
        {
            get => _UserName;
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Password { get; set; }
        public string Password
        {
            get => _Password;
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    OnPropertyChanged();
                }
            }
        }

        public DangNhapViewModel()
        {
            DangNhapCommand = new ActionCommand(p => DangNhap());
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        public ICommand DangNhapCommand { get; }
        public ICommand PasswordChangedCommand { get; set; }

        private void DangNhap()
        {
            // Check Here!!
            TaiKhoan myAcount = DataProvider.Ins.DB.TaiKhoans.FirstOrDefault(tk => tk.UserName == _UserName && tk.PassWord == _Password);
            if (myAcount!=null)
            {
                var home = new HomePage(myAcount);
                home.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu","Đăng nhập thất bại!",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
