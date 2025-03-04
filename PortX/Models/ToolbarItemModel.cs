using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PortX.Models
{
    public class ToolbarItemModel
    {
        public PackIconKind Icon { get; set; }
        public string Tooltip { get; set; }
        public ICommand Command { get; set; }
    }

}
