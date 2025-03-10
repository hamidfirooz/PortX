using MaterialDesignThemes.Wpf;
using PortX.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PortX.ViewModels
{
    public class TabViewModel : BaseViewModel
    {
        public ObservableCollection<TabItemModel> Tabs { get; set; }
        public static TabItemModel SelectedTab { get; set; }

        public ICommand AddTabCommand { get; }
        public ICommand RemoveTabCommand { get; }


        public TabViewModel()
        {

            Tabs = new ObservableCollection<TabItemModel>
            {
                new TabItemModel { Header = "Tab 1", Content = "Content of Tab 1" },
                new TabItemModel { Header = "Tab 2", Content = "Content of Tab 2" },
                new TabItemModel { Header = "Tab 3", Content = "Content of Tab 3" },
                new TabItemModel { Header = "Tab 4", Content = "Content of Tab 4" }
            };

            // انتخاب تب اول به طور پیش‌فرض
            SelectedTab = Tabs[0];
   
        }

        private void AddTab()
        {
            Tabs.Add(new TabItemModel { Header = "New Tab", Content = "Content of new Tab" });
        }

        private void RemoveTab()
        {
            if (Tabs.Count > 0)
            {
                Tabs.RemoveAt(Tabs.Count - 1);
            }
        }

        public static void SerialPortViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // تبدیل sender به SerialPortViewModel
            var serialPortViewModel = sender as SerialPortViewModel;
            if (serialPortViewModel == null)
            {
                Console.WriteLine("⚠️ sender is not of type SerialPortViewModel!");
                return;
            }

            // اگر خاصیت ReceivedData تغییر کرده باشد
            if (e.PropertyName == nameof(SerialPortViewModel.ReceivedData))
            {
                Console.WriteLine($"✅ Data Change Detected in TabViewModel: {serialPortViewModel.ReceivedData}");

                // بررسی اینکه آیا SelectedTab مقداردهی شده است
                if (SelectedTab == null)
                {
                    Console.WriteLine("⚠️ SelectedTab is NULL! No update possible.");
                    return;
                }

                Console.WriteLine($"📌 Updating Tab Content: {SelectedTab.Header} -> {serialPortViewModel.ReceivedData}");

                // به‌روزرسانی محتوا در UI Thread
                App.Current.Dispatcher.Invoke(() =>
                {
                    SelectedTab.Content += serialPortViewModel.ReceivedData + "\n";
                });
            }
        }


    }

}
