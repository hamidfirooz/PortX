using MaterialDesignThemes.Wpf;
using PortX.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PortX.ViewModels
{
    public class MenuViewModel
    {
        public ObservableCollection<MenuItemModel> MenuItems { get; set; }
        public ObservableCollection<ToolbarItemModel> ToolbarItems { get; set; }
        public MenuViewModel()
        {
            // ساخت ایتم‌های منو
            MenuItems = new ObservableCollection<MenuItemModel>
            {
                new MenuItemModel { Header = "File", Command = new RelayCommand(OnFileClicked) },
                new MenuItemModel { Header = "Edit", Command = new RelayCommand(OnEditClicked) },
                new MenuItemModel { Header = "Run", Command = new RelayCommand(OnRunClicked) },
                new MenuItemModel { Header = "Tools", Command = new RelayCommand(OnToolsClicked) },
                new MenuItemModel { Header = "Help", Command = new RelayCommand(OnHelpClicked) }
            };
            // ساخت آیتم‌های نوار ابزار
            ToolbarItems = new ObservableCollection<ToolbarItemModel>
            {
                new ToolbarItemModel { Icon = PackIconKind.FileDocument, Tooltip = "New File", Command = new RelayCommand(OnFileClicked) },
                new ToolbarItemModel { Icon = PackIconKind.FolderOpen, Tooltip = "Open File", Command = new RelayCommand(OnEditClicked) },
                new ToolbarItemModel { Icon = PackIconKind.Play, Tooltip = "Run", Command = new RelayCommand(OnRunClicked) },
                new ToolbarItemModel { Icon = PackIconKind.Wrench, Tooltip = "Tools", Command = new RelayCommand(OnToolsClicked) },
                new ToolbarItemModel { Icon = PackIconKind.HelpCircle, Tooltip = "Help", Command = new RelayCommand(OnHelpClicked) }
            };

        }
        private void OnFileClicked() { MessageBox.Show("File clicked!"); }
        private void OnEditClicked() { MessageBox.Show("Edit clicked!"); }
        private void OnRunClicked() { MessageBox.Show("Run clicked!"); }
        private void OnToolsClicked() { MessageBox.Show("Tools clicked!"); }
        private void OnHelpClicked() { MessageBox.Show("Help clicked!"); }
    }
}
