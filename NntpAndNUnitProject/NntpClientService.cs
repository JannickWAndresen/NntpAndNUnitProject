using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NntpAndUnitProject
{
public class NntpClientService
{
    private TcpClient _tcpClient;
    private StreamReader _reader;
    private StreamWriter _writer;
        public bool Connect(ConnectionModel connection)
    {
        try
        {
            _tcpClient = new TcpClient(connection.Server, connection.Port);
            NetworkStream stream = _tcpClient.GetStream();
            _reader = new StreamReader(stream);
            _writer = new StreamWriter(stream) { AutoFlush = true };

            var initialResponse = _reader.ReadLine();
            if (initialResponse.StartsWith("200"))
            {
                _writer.WriteLine($"authinfo user {connection.Username}");
                var userResponse = _reader.ReadLine();
                if (!userResponse.StartsWith("381"))
                {
                    return false;  
                }

                _writer.WriteLine($"authinfo pass {connection.Password}");
                var passResponse = _reader.ReadLine();
                if (!passResponse.StartsWith("281"))
                {
                    return false;  
                }

                return true;  
            }
            else
            {
                return false; 
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

        public string SendCommand(string command)
        {
            _writer.WriteLine(command);
            _writer.Flush();

            StringBuilder response = new StringBuilder();
            string line;

            while ((line = _reader.ReadLine()) != null)
            {
                if (line == ".")
                {
                    break;
                }
                response.AppendLine(line);
            }

            return response.ToString();
        }

        public void Disconnect()
    {
        _writer?.Close();
        _reader?.Close();
        _tcpClient?.Close();
    }
}
}
