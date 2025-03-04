using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortX.ViewModels
{
    public class MainViewModel
    {
        public MenuViewModel MenuViewModel { get; set; }
        public ToolbarViewModel ToolbarViewModel { get; set; }
        public TabViewModel TabViewModel { get; set; }
        public SerialPortViewModel SerialPortViewModel { get; set; }
        public MainViewModel()
        {
            SerialPortViewModel = new SerialPortViewModel();
            ToolbarViewModel = new ToolbarViewModel();
            MenuViewModel = new MenuViewModel();
            TabViewModel = new TabViewModel();
        }
    }

}
