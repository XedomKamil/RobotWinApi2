using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace tcp
{
    class SocketClientTCP
    {
        // public TcpClient tcpClient { get; set; }
        public TcpClient tcpClient;
        public string IP { get; set; }
        public int PORT { get; set; }
        public bool status { get; set; }

        public ASCIIEncoding asen { get; set; }
        public Stream stream { get; set; }
        public byte[] ba { get; set; }
        public byte[] bb { get; set; }
        
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="ip"> Adres IP serwera, typ string</param>
        /// <param name="port">Port serwera, typu int</param>
        public SocketClientTCP(string ip, int port)
        {
            this.IP = ip;
            this.PORT = port;
        }
        /// <summary>
        /// Ustanawia połączenie oraz łączy soket z strumieniem
        /// </summary>
        /// <returns></returns>
        public int ConnectAndGetStream()
        {
            try
            {
                //ASCIIEncoding asen = new ASCIIEncoding();
                tcpClient = new TcpClient();
                tcpClient.Connect(IP, PORT);
                status = tcpClient.Connected;
                stream = tcpClient.GetStream();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Wysłanie wiadomości TCP
        /// </summary>
        /// <param name="msg">Wiadomość typu string</param>
        public void SendMsg(string msg)
        {
            if (stream.CanWrite)
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                ba = asen.GetBytes(msg);
                if(msg!="")
                {
                    stream.Write(ba, 0, ba.Length);
                    stream.Flush();
                }
            }
        }
        /// <summary>
        /// Odczyt wiadomości z stosu TCP o podanej długości
        /// </summary>
        /// <param name="length">Ilosc bitów określająca długość wiadomośći</param>
        /// <returns></returns>
        public string ReceiveMsg(int length)
        {
            bb = new byte[length];
            int n = stream.Read(bb, 0, length);
            stream.Flush();
            ASCIIEncoding asen = new ASCIIEncoding();
            return asen.GetString(bb);
        }
        /// <summary>
        /// Zamyka soket oraz wysyła kod (-22) zamknięcia soketu na serwerze
        /// </summary>
        public void CloseSocketWithMSG()
        {
            SendMsg("-22");
            this.status = false;
            stream.Close();
            tcpClient.Close();
        }
        /// <summary>
        /// Zamyka soket
        /// </summary>
        public void CloseSocket()
        {
            this.status = false;
            stream.Close();
            tcpClient.Close();
        }
        /// <summary>
        /// Zamyka soket oraz wysyła kod (-2) zamnięcia aplikacji serwera
        /// </summary>
        public void CloseApp()
        {
            SendMsg("-2");
            this.status = false;
            stream.Close();
            tcpClient.Close();
        }
    }
}
