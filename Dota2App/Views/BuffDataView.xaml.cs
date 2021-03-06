﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Dota2App.Models;
using System.Collections.ObjectModel;
using Dota2App.ViewModels;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Dota2App.Views {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class BuffDataView : Page {

        public ObservableCollection<Item> DotaAllItems { get; set; }
        private int pageNum = 1;

        public BuffDataView() {
            this.InitializeComponent();
            DotaAllItems = new ObservableCollection<Item>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e) {
            MyProgressRing.IsActive = true;
            MyProgressRing.Visibility = Visibility.Visible;

            await JsonManage.BuffDataManageAsync(DotaAllItems, pageNum);

            MyProgressRing.IsActive = false;
            MyProgressRing.Visibility = Visibility.Collapsed;
        }

        private async void Button_Refresh_Click(object sender, RoutedEventArgs e) {
            MyProgressRing.IsActive = true;
            MyProgressRing.Visibility = Visibility.Visible;

            DotaAllItems.Clear();
            await JsonManage.BuffDataManageAsync(DotaAllItems, pageNum);

            MyProgressRing.IsActive = false;
            MyProgressRing.Visibility = Visibility.Collapsed;
        }
    }
    
}
