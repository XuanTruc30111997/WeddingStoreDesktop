using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeddingStoreDesktop.Interfaces.Dialog;
using WeddingStoreDesktop.Models;
using WeddingStoreDesktop.Models.DesktopModel;
using WeddingStoreDesktop.Models.SystemModel;
using WeddingStoreDesktop.Services.DesktopService;

namespace WeddingStoreDesktop.ViewModels
{
    public class ucDatLichViewModel : BaseViewModel
    {
        #region Properties
        // Danh sách các tháng
        public List<string> LstThang
        {
            get => new List<string>
            {
                "Tháng 1",
                "Tháng 2",
                "Tháng 3",
                "Tháng 4",
                "Tháng 5",
                "Tháng 6",
                "Tháng 7",
                "Tháng 8",
                "Tháng 9",
                "Tháng 10",
                "Tháng 11",
                "Tháng 12",
            };
        }

        // Chọn tháng
        private string _Thang { get; set; }
        public string Thang
        {
            get => _Thang;
            set
            {
                if (_Thang != value)
                {
                    _Thang = value;
                    OnPropertyChanged();
                }
            }
        }

        // Năm nhập
        private string _Nam { get; set; }
        public string Nam
        {
            get => _Nam;
            set
            {
                _Nam = value;
                OnPropertyChanged();
            }
        }

        // Danh sách ngày
        private List<NgayDatLichModel> _LstNgayDatLich { get; set; }
        public List<NgayDatLichModel> LstNgayDatLich
        {
            get => _LstNgayDatLich;
            set
            {
                _LstNgayDatLich = value;
                OnPropertyChanged();
            }
        }

        private NgayDatLichModel _SelectedNgayDatLich { get; set; }
        public NgayDatLichModel SelectedNgayDatLich
        {
            get => _SelectedNgayDatLich;
            set
            {
                _SelectedNgayDatLich = value;
                OnPropertyChanged();
            }
        }

        private DatLich _SelectedDatlich { get; set; }
        public DatLich SelectedDatLich
        {
            get => _SelectedDatlich;
            set
            {
                _SelectedDatlich = value;
                OnPropertyChanged();
            }
        }

        string _myDatLich;
        string _myNgayDatLich;

        private DateTime _myTime { get; set; }
        public DateTime myTime
        {
            get => _myTime;
            set
            {
                _myTime = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Services
        NgayDatLichService serNgayDatLich = new NgayDatLichService();
        #endregion

        #region Constructors
        public ucDatLichViewModel()
        {
            _Nam = DateTime.Now.Year.ToString();
            _Thang = "Tháng " + DateTime.Now.Month.ToString();
            GetData();

            SearchCommand = new ActionCommand(p => GetData());
            LuuCommand = new ActionCommand(p => Luu());
            DuyetCommand = new ActionCommand(p => Duyet());
            HuyDuyetCommand = new ActionCommand(p => HuyDuyet());
            XoaCommand = new ActionCommand(p => Xoa());
            HuyCommand = new ActionCommand(p => Huy());
            ChinhSuaCommand = new ActionCommand(p => ChinhSua());
        }
        #endregion

        #region Commands
        public ICommand SearchCommand { get; }
        public ICommand LuuCommand { get; }
        public ICommand DuyetCommand { get; }
        public ICommand HuyDuyetCommand { get; }
        public ICommand XoaCommand { get; }
        public ICommand HuyCommand { get; }
        public ICommand ChinhSuaCommand { get; }
        #endregion

        #region Methods
        private void GetData()
        {
            DataProvider.Ins.RefreshDB();
            if (int.TryParse(_Nam, out int myNam))
            {
                string[] strThang = _Thang.Split(' ');
                LstNgayDatLich = serNgayDatLich.GetNgayDatLich(int.Parse(strThang[1]), myNam);
            }
            else
            {
                MessageBox.Show("Năm không đúng định dạng.", "Lỗi!", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        void ChinhSua()
        {
            _myNgayDatLich = _SelectedNgayDatLich.Ngay;
            _myDatLich = _SelectedDatlich.MaDL;
            myTime = DateTime.Parse(_SelectedDatlich.ThoiGian.ToString());
        }

        void Luu()
        {
            //DatLich myDatLich = DataProvider.Ins.DB.DatLiches.FirstOrDefault(dl => dl.MaDL == _SelectedDatlich.MaDL);
            //myDatLich.TenKH = _SelectedDatlich.TenKH;
            //myDatLich.SoDT = _SelectedDatlich.SoDT;
            //myDatLich.DiaChi = _SelectedDatlich.DiaChi;
            //myDatLich.NgayCuoi = _SelectedDatlich.NgayCuoi;
            //myDatLich.NgayDat = _SelectedDatlich.NgayDat;
            //myDatLich.ThoiGian = _SelectedDatlich.ThoiGian;
            SelectedDatLich.ThoiGian = myTime.TimeOfDay;
            DataProvider.Ins.DB.SaveChanges();
            GetData();
            //OnPropertyChanged(nameof(SelectedNgayDatLich));
            //OnPropertyChanged(nameof(SelectedDatLich));
        }

        void Duyet()
        {
            DatLich myDatLich = DataProvider.Ins.DB.DatLiches.FirstOrDefault(dl => dl.MaDL == _SelectedDatlich.MaDL);
            myDatLich.TrangThaiDuyet = true;
            OnPropertyChanged(nameof(SelectedDatLich));
            DataProvider.Ins.DB.SaveChanges();
        }

        void HuyDuyet()
        {
            DatLich myDatLich = DataProvider.Ins.DB.DatLiches.FirstOrDefault(dl => dl.MaDL == _SelectedDatlich.MaDL);
            myDatLich.TrangThaiDuyet = false;
            DataProvider.Ins.DB.SaveChanges();
        }

        void Xoa()
        {
            var response= MessageBox.Show("Xóa đặt lịch của khách hàng " + _SelectedDatlich.TenKH + " ?", "Xóa??", MessageBoxButton.OKCancel);
            if(response==MessageBoxResult.OK)
            {
                DataProvider.Ins.DB.DatLiches.Remove(_SelectedDatlich);
                DataProvider.Ins.DB.SaveChanges();
                GetData();
            }
        }

        void Huy()
        {
            DataProvider.Ins.RefreshDB();
            GetData();
            SelectedNgayDatLich = _LstNgayDatLich.FirstOrDefault(n => n.Ngay == _myNgayDatLich);
            SelectedDatLich = _SelectedNgayDatLich.LstDatLich.FirstOrDefault(dl=>dl.MaDL==_myDatLich);
        }
        #endregion
    }
}
