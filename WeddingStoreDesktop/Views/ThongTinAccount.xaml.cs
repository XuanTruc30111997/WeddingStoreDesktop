﻿using System;
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
using System.Windows.Shapes;
using WeddingStoreDesktop.Interfaces.Dialog;

namespace WeddingStoreDesktop.Views
{
    /// <summary>
    /// Interaction logic for ThongTinAccount.xaml
    /// </summary>
    public partial class ThongTinAccount : Window,IDialog
    {
        public ThongTinAccount()
        {
            InitializeComponent();
        }
    }
}
