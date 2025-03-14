using MaterialDesignThemes.Wpf;
using PortX.Models;
using PortX.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PortX.ViewModels
{
    public class ToolbarViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ToolbarItemModel> ToolbarItems { get; set; }
        public SerialPortViewModel SerialPortViewModel { get; set; }

        private PackIconKind _runIcon = PackIconKind.Play;
        public PackIconKind RunIcon
        {
            get => _runIcon;
            set
            {
                _runIcon = value;
                OnPropertyChanged(nameof(RunIcon));
            }
        }
        private string _receivedData;
        public string ReceivedData
        {
            get => _receivedData;
            set
            {
                _receivedData = value;
                OnPropertyChanged(nameof(ReceivedData)); // اطلاع به UI
            }
        }
        public ToolbarViewModel()
        {
            SerialPortViewModel = new SerialPortViewModel(); 

            SerialPortViewModel.PropertyChanged += SerialPortViewModel_PropertyChanged;
            SerialPortViewModel.PropertyChanged += TabViewModel.SerialPortViewModel_PropertyChanged;

            ToolbarItems = new ObservableCollection<ToolbarItemModel>
            {
                new ToolbarItemModel { Icon = PackIconKind.FileDocument, Tooltip = "New File", Command = new RelayCommand(OnNewFileClicked) },
                new ToolbarItemModel { Icon = PackIconKind.FolderOpen, Tooltip = "Open File", Command = new RelayCommand(OnOpenFileClicked) },
                new ToolbarItemModel { Icon = PackIconKind.Play, Tooltip = "Run", Command = new RelayCommand(OnRunClicked) },
                new ToolbarItemModel { Icon = PackIconKind.Settings, Tooltip = "Settings", Command = new RelayCommand(OnSettingsClicked) },
                new ToolbarItemModel { Icon = PackIconKind.Wrench, Tooltip = "Tools", Command = new RelayCommand(OnToolsClicked) },
                new ToolbarItemModel { Icon = PackIconKind.HelpCircle, Tooltip = "Help", Command = new RelayCommand(OnHelpClicked) }
            };


        }

        private void OnNewFileClicked() { /* کد مربوط به ایجاد فایل جدید */ }
        private void OnOpenFileClicked() { /* کد مربوط به باز کردن فایل */ }
        private void OnSettingsClicked() { /* نمایش تنظیمات */ }
        private void OnToolsClicked() { /* نمایش ابزارها */ }
        private void OnHelpClicked() { /* نمایش راهنما */ }

        private void SerialPortViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SerialPortViewModel.IsPortOpen))
            {
                RunIcon = SerialPortViewModel.IsPortOpen ? PackIconKind.Play : PackIconKind.Stop;
                OnPropertyChanged(nameof(RunIcon)); // اطلاع به UI
            }
            else if (e.PropertyName == nameof(SerialPortViewModel.ReceivedData))
            {
                // فرض می‌کنیم که داده‌های دریافتی در SerialPortViewModel به روز رسانی می‌شوند.
                ReceivedData = SerialPortViewModel.ReceivedData;

            }

        }


        private void OnRunClicked()
        {
            if (SerialPortViewModel != null && SerialPortViewModel.OpenPortCommand.CanExecute(null))
            {
                SerialPortViewModel.SelectedPort = SerialPortViewModel.AvailablePorts.FirstOrDefault(x => x.Equals("COM11"));

                if (string.IsNullOrEmpty(SerialPortViewModel.SelectedPort))
                {
                    MessageBox.Show("COM11 is not available!");
                    return;
                }

                SerialPortViewModel.BaudRate = 9600;
                SerialPortViewModel.Parity = Parity.None;
                SerialPortViewModel.DataBits = 8;
                SerialPortViewModel.StopBits = StopBits.One;

                SerialPortViewModel.OpenPortCommand.Execute(null);

                var runItem = ToolbarItems.FirstOrDefault(x => x.Tooltip.Contains("Run"));
                if (runItem != null)
                {
                    runItem.Icon = PackIconKind.Stop;
                }

                RunIcon = PackIconKind.Stop;
                OnPropertyChanged(nameof(RunIcon));
            }
            else
            {
                
                var runItem = ToolbarItems.FirstOrDefault(x => x.Tooltip.Contains("Run"));
                if (runItem != null)
                {
                    runItem.Icon = PackIconKind.Play;
                }
                SerialPortViewModel.ClosePortCommand.Execute(null);
                RunIcon = PackIconKind.Play;
                OnPropertyChanged(nameof(RunIcon));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
