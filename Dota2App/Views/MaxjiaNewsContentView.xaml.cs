using Dota2App.Models;
using Dota2App.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Dota2App.Views {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MaxjiaNewsContentView : Page {

        public ObservableCollection<Result> results { get; set; }

        public MaxjiaNewsContentView() {
            this.InitializeComponent();
            results = new ObservableCollection<Result>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e) {
            await JsonManage.MaxjiaDataManageAsync(results);
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e) {
            myFrame.Navigate(typeof(MaxjiaNewsView));
        }
    }
}
