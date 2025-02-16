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
        }

        // دستورات برای هر آیتم منو
        private void OnFileClicked() { MessageBox.Show("File"); }
        private void OnEditClicked() { /* عمل مربوط به منو Edit */ }
        private void OnRunClicked() { /* عمل مربوط به منو Run */ }
        private void OnToolsClicked() { /* عمل مربوط به منو Tools */ }
        private void OnHelpClicked() { /* عمل مربوط به منو Help */ }
    }
}
