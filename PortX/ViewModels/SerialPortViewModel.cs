using PortX.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PortX.ViewModels
{
    public class SerialPortViewModel : BaseViewModel
    {
        private readonly SerialPortModel _serialPortModel;
        private string _selectedPort;
        private int _baudRate = 9600;
        private Parity _parity = Parity.None;
        private int _dataBits = 8;
        private StopBits _stopBits = StopBits.One;
        private string _receivedData;
        private string _sendData;
        private bool _isPortOpen;

        public SerialPortModel SerialPortModel { get; }

        public ObservableCollection<string> AvailablePorts { get; }

        public string SelectedPort
        {
            get => _selectedPort;
            set => SetProperty(ref _selectedPort, value);
        }

        public int BaudRate
        {
            get => _baudRate;
            set => SetProperty(ref _baudRate, value);
        }

        public Parity Parity
        {
            get => _parity;
            set => SetProperty(ref _parity, value);
        }

        public int DataBits
        {
            get => _dataBits;
            set => SetProperty(ref _dataBits, value);
        }

        public StopBits StopBits
        {
            get => _stopBits;
            set => SetProperty(ref _stopBits, value);
        }

        public string ReceivedData
        {
            get => _receivedData;
            set
            {
                if (_receivedData != value)
                {
                    _receivedData = value;
                    OnPropertyChanged(nameof(ReceivedData));
                    Console.WriteLine($"ReceivedData Updated: {_receivedData}"); // دیباگ برای بررسی مقداردهی
                }
            }
        }

        public string SendData
        {
            get => _sendData;
            set => SetProperty(ref _sendData, value);
        }

        public bool IsPortOpen
        {
            get => _isPortOpen;
            set => SetProperty(ref _isPortOpen, value);
        }

        public ICommand OpenPortCommand { get; }
        public ICommand ClosePortCommand { get; }
        public ICommand SendDataCommand { get; }

        public SerialPortViewModel()
        {
            //_serialPortModel = new SerialPortModel();
            //_serialPortModel.DataReceived += data => ReceivedData += data;
            _serialPortModel = new SerialPortModel();
            _serialPortModel.DataReceived += OnDataReceived;

            AvailablePorts = new ObservableCollection<string>(_serialPortModel.GetAvailablePorts());

            OpenPortCommand = new RelayCommand(OpenPort, () => !IsPortOpen);
            ClosePortCommand = new RelayCommand(ClosePort, () => IsPortOpen);
            SendDataCommand = new RelayCommand(SendDataToPort, () => IsPortOpen && !string.IsNullOrEmpty(SendData));

        }

        private void OpenPort()
        {
            _serialPortModel.ConfigurePort(SelectedPort, BaudRate, Parity, DataBits, StopBits);
            _serialPortModel.OpenPort();
            IsPortOpen = true;
        }

        private void ClosePort()
        {
            _serialPortModel.ClosePort();
            IsPortOpen = false;
        }

        private void SendDataToPort()
        {
            _serialPortModel.SendData(SendData);
        }
        private void OnDataReceived(string data)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                ReceivedData += data + "\n"; // اطمینان از اجرای تغییرات در UI Thread
            });
        }

    }
}
