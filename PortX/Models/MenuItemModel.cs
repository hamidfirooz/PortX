using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PortX.Models
{
    public class MenuItemModel
    {
        public string Header { get; set; }  // عنوان منو (مثلاً "فایل")
        public List<MenuItemModel> SubItems { get; set; } // زیرمنوها
        public ICommand Command { get; set; } // فرمانی که اجرا می‌شود

        public MenuItemModel()
        {
            SubItems = new List<MenuItemModel>();
        }
    }

}
