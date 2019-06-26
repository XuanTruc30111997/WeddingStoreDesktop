using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using WeddingStoreDesktop.Functions;
using WeddingStoreDesktop.Interfaces.Dialog;
using WeddingStoreDesktop.Models;
using WeddingStoreDesktop.Models.SystemModel;

namespace WeddingStoreDesktop.ViewModels
{
    public class ucBlogViewModel : BaseViewModel
    {
        #region Properties
        private List<Blog> _LstBlog { get; set; }
        public List<Blog> LstBlog
        {
            get => _LstBlog;
            set
            {
                _LstBlog = value;
                OnPropertyChanged();
            }
        }

        private Blog _SelectedBlog { get; set; }
        public Blog SelectedBlog
        {
            get => _SelectedBlog;
            set
            {
                _SelectedBlog = value;
                OnPropertyChanged();
                isVisibility = true;
            }
        }
        string _myMaBlog;

        private Blog _myBlog { get; set; }
        public Blog myBlog
        {
            get => _myBlog;
            set
            {
                _myBlog = value;
                OnPropertyChanged();
            }
        }

        private bool _isVisibility { get; set; }
        public bool isVisibility
        {
            get => _isVisibility;
            set
            {
                if (_isVisibility != value)
                {
                    _isVisibility = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Constructors
        public ucBlogViewModel()
        {
            GetData();
            RefreshCommand = new ActionCommand(p => GetData());
            ChinhSuaCommand = new ActionCommand(p => ChinhSua());
            LuuCommand = new ActionCommand(p => Luu());
            HuyCommand = new ActionCommand(p => Huy());
            XoaCommand = new ActionCommand(p => Xoa());
            XoaCommand = new ActionCommand(p => Xoa());
            ThemCommand = new ActionCommand(p => Them());
            SaveCommand = new ActionCommand(p => Save());
            ChooseImageCommand = new ActionCommand(p => ChooseImage());
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand { get; }
        public ICommand ChinhSuaCommand { get; }
        public ICommand XoaCommand { get; }
        public ICommand LuuCommand { get; }
        public ICommand HuyCommand { get; }
        public ICommand ThemCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand ChooseImageCommand { get; }

        #endregion

        #region Methods
        void GetData()
        {
            myBlog = new Blog();
            LstBlog = DataProvider.Ins.DB.Blogs.ToList();
            isVisibility = false;
        }
        void ChinhSua()
        {
            _myMaBlog = _SelectedBlog.MaBlog;
        }
        void Luu()
        {
            SelectedBlog.UpdatedDate = DateTime.Now.Date;
            DataProvider.Ins.DB.SaveChanges();
        }
        void Huy()
        {
            DataProvider.Ins.RefreshDB();
            GetData();
            SelectedBlog = _LstBlog.FirstOrDefault(bl => bl.MaBlog == _myMaBlog);
        }
        void Them()
        {
            myBlog = new Blog();
            myBlog.MaBlog = "BL-" + GetMaxID.GetMaxIdBlog();
            myBlog.CreatedDate = DateTime.Now.Date;
            myBlog.UpdatedDate = DateTime.Now.Date;
            OnPropertyChanged(nameof(myBlog));
        }
        void Save()
        {
            var response = System.Windows.MessageBox.Show("Bạn muốn thêm bài đăng " + _myBlog.TenBlog + " ?", "Thêm bài đăng", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (response == MessageBoxResult.OK)
            {
                DataProvider.Ins.DB.Blogs.Add(_myBlog);
                DataProvider.Ins.DB.SaveChanges();
                GetData();
            }
        }
        void Xoa()
        {
            var response = System.Windows.MessageBox.Show("Bạn có muốn xóa bài đăng " + _SelectedBlog.TenBlog + " ?", "Xóa bài đăng?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == MessageBoxResult.Yes)
            {
                DataProvider.Ins.DB.Blogs.Remove(_SelectedBlog);
                DataProvider.Ins.DB.SaveChanges();
                GetData();
            }
        }
        void ChooseImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                    "Portable Network Graphic (*.png)|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image myImage = null;
                myImage = Image.FromFile(openFileDialog.FileName);
                using (MemoryStream mStream = new MemoryStream())
                {
                    myImage.Save(mStream, myImage.RawFormat);
                    myBlog.HinhMoTa = mStream.ToArray();
                }
                OnPropertyChanged(nameof(myBlog));
            }
        }
        #endregion
    }
}
