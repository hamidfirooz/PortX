# PortX
Serial & TCP Communication Project

This project is developed using Visual Studio and is designed to handle both Serial Port (RS232/RS422/RS485) and TCP/IP communication. It provides a simple and efficient way to send and receive data through these communication interfaces.

Features

Serial Port Communication: Supports multiple COM ports with configurable baud rate, parity, stop bits, and data bits.

TCP/IP Communication: Acts as both client and server for network communication.

Logging: Stores sent and received data for debugging purposes.

User-Friendly Interface: Simple UI for easy configuration and data monitoring.

Installation

Prerequisites

Windows OS (Tested on Windows 10/11)

.NET Framework (or .NET Core if applicable)

Visual Studio (Recommended version: 2019 or later)

Steps

Clone the repository:

git clone https://github.com/yourusername/yourproject.git

Open the project in Visual Studio.

Restore NuGet packages if required.

Build and run the project.

Usage

Serial Port Configuration

Select the desired COM port from the dropdown.

Set baud rate, parity, stop bits, and data bits.

Click "Connect" to establish a serial connection.

TCP Communication

Enter the server IP and port for TCP client mode.

Start the TCP server and listen for incoming connections.

Send and receive messages through the network.

Contributing

Feel free to fork this repository and submit pull requests for improvements.

License

This project is licensed under the MIT License.

Made with ❤️ by Hamid Firooz