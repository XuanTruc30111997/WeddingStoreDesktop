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
    /// Interaction logic for ucBlog.xaml
    /// </summary>
    public partial class ucBlog : UserControl
    {
        ViewModels.ucBlogViewModel vm;
        public ucBlog()
        {
            InitializeComponent();
            vm = new ViewModels.ucBlogViewModel();
            DataContext = vm;
        }
    }
}
