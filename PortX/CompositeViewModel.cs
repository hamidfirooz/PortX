﻿using PortX.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortX
{
    public class CompositeViewModel
    {
        public MenuViewModel MenuViewModel { get; set; }
        public TabViewModel TabViewModel { get; set; }
        public ToolbarViewModel ToolbarViewModel { get; set; }
        public CompositeViewModel()
        {
            MenuViewModel = new MenuViewModel();
            TabViewModel = new TabViewModel();

        }
    }
}
