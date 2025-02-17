using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PortX.ViewModels
{
    public class TabViewModel : BaseViewModel
    {
        public ObservableCollection<TabItemModel> Tabs { get; set; }
        public TabItemModel SelectedTab { get; set; }

        public ICommand AddTabCommand { get; }
        public ICommand RemoveTabCommand { get; }

        public TabViewModel()
        {
            /*
            Tabs = new ObservableCollection<TabItemModel>();
            AddTabCommand = new RelayCommand(AddTab);
            RemoveTabCommand = new RelayCommand(RemoveTab);

            // Add a sample tab
            Tabs.Add(new TabItemModel { Header = "Tab 1", Content = "Content of Tab 1" });
            */
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
    }

    public class TabItemModel
    {
        public string Header { get; set; }
        public string Content { get; set; }
    }
}
