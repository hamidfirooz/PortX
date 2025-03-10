using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortX.Models
{
    public class SerialPortService
    {
        private readonly SerialPortModel _serialPortModel;

        public event Action<string> DataReceived;  // این رویداد برای ارسال داده‌های دریافتی به ویو مدل‌ها

        public SerialPortService()
        {
            _serialPortModel = new SerialPortModel();
            _serialPortModel.DataReceived += OnDataReceived;
        }

        public void ConfigurePort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            _serialPortModel.ConfigurePort(portName, baudRate, parity, dataBits, stopBits);
        }

        public void OpenPort()
        {
            _serialPortModel.OpenPort();
        }

        public void ClosePort()
        {
            _serialPortModel.ClosePort();
        }

        public void SendData(string data)
        {
            _serialPortModel.SendData(data);
        }

        private void OnDataReceived(string data)
        {
            // ارسال داده‌های دریافتی به ViewModel یا سایر بخش‌ها
            DataReceived?.Invoke(data);
        }
    }
}
