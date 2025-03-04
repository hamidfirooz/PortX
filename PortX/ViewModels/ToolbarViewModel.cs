using MaterialDesignThemes.Wpf;
using PortX.Models;
using PortX.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PortX.ViewModels
{
    public class ToolbarViewModel
    {
        public ObservableCollection<ToolbarItemModel> ToolbarItems { get; set; }
 
        SerialPortViewModel serialPortViewModel { get; set; }
        public ToolbarViewModel()
        {

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

        private void OnRunClicked()
        {
            serialPortViewModel.OpenPortCommand.Execute(serialPortViewModel);
            MessageBox.Show("Run");
        }
    }

}
