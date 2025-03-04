using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PortX.ViewModels
{
    public class SerialPortSettingsViewModel : BaseViewModel
    {
        private string _selectedPort;
        private int _selectedBaudRate;
        private Parity _selectedParity;
        private int _selectedDataBits;
        private StopBits _selectedStopBits;

        public ObservableCollection<string> AvailablePorts { get; }
        public ObservableCollection<int> BaudRates { get; }
        public ObservableCollection<Parity> Parities { get; }
        public ObservableCollection<int> DataBitsOptions { get; }
        public ObservableCollection<StopBits> StopBitsOptions { get; }

        public string SelectedPort
        {
            get => _selectedPort;
            set => SetProperty(ref _selectedPort, value);
        }

        public int SelectedBaudRate
        {
            get => _selectedBaudRate;
            set => SetProperty(ref _selectedBaudRate, value);
        }

        public Parity SelectedParity
        {
            get => _selectedParity;
            set => SetProperty(ref _selectedParity, value);
        }

        public int SelectedDataBits
        {
            get => _selectedDataBits;
            set => SetProperty(ref _selectedDataBits, value);
        }

        public StopBits SelectedStopBits
        {
            get => _selectedStopBits;
            set => SetProperty(ref _selectedStopBits, value);
        }

        public ICommand SaveSettingsCommand { get; }

        public SerialPortSettingsViewModel()
        {
            AvailablePorts = new ObservableCollection<string>(SerialPort.GetPortNames());
            BaudRates = new ObservableCollection<int> { 9600, 19200, 38400, 57600, 115200 };
            Parities = new ObservableCollection<Parity>(Enum.GetValues(typeof(Parity)).Cast<Parity>());
            DataBitsOptions = new ObservableCollection<int> { 5, 6, 7, 8 };
            StopBitsOptions = new ObservableCollection<StopBits>(Enum.GetValues(typeof(StopBits)).Cast<StopBits>());

            SelectedBaudRate = 9600;
            SelectedParity = Parity.None;
            SelectedDataBits = 8;
            SelectedStopBits = StopBits.One;

            SaveSettingsCommand = new RelayCommand(SaveSettings);
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Port = SelectedPort;
            Properties.Settings.Default.BaudRate = SelectedBaudRate;
            Properties.Settings.Default.SelectedParity = SelectedParity;
            Properties.Settings.Default.SelectedStopBits = SelectedStopBits;
            Properties.Settings.Default.Save(); 

            // ذخیره تنظیمات پورت سریال
            Console.WriteLine($"Port: {SelectedPort}, BaudRate: {SelectedBaudRate}, Parity: {SelectedParity}, DataBits: {SelectedDataBits}, StopBits: {SelectedStopBits}");
        }
    }
}
