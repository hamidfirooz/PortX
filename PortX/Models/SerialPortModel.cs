using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortX.Models
{
    public class SerialPortModel
    {
        private SerialPort _serialPort;

        public event Action<string> DataReceived;  // برای ارسال داده‌های دریافتی به ViewModel

        public SerialPortModel()
        {
            _serialPort = new SerialPort();
            _serialPort.DataReceived += OnDataReceived;
        }

        public string[] GetAvailablePorts() => SerialPort.GetPortNames(); // لیست پورت‌ها

        public void ConfigurePort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            if (_serialPort.IsOpen) _serialPort.Close();

            _serialPort.PortName = portName;
            _serialPort.BaudRate = baudRate;
            _serialPort.Parity = parity;
            _serialPort.DataBits = dataBits;
            _serialPort.StopBits = stopBits;
        }

        public void OpenPort()
        {
            if (!_serialPort.IsOpen)
                _serialPort.Open();
        }

        public void ClosePort()
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();
        }

        public void SendData(string data)
        {
            if (_serialPort.IsOpen)
                _serialPort.WriteLine(data);
        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = _serialPort.ReadExisting();
            DataReceived?.Invoke(receivedData);
        }
    }
}
