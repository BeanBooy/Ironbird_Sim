using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    internal class NetworkController
    {
        Logger logger = Logger.Instance;

        TcpClient client;  // UI is client
        NetworkStream nw_stream;

        int portNumber = 4443;
        string ipAdress = "192.168.178.65";

        public void connectToIp() {
            try {
                if (portNumber > 1024) {
                    client = new TcpClient();
                    client.Connect(ipAdress, portNumber);
                    client.ReceiveTimeout = 5000;  // 5s
                    nw_stream = client.GetStream();
                    string msg = $"Connection established. Port: {portNumber} IP: {ipAdress}";
                    logger.log(msg);
                    //SendData(outBuffer);
                }
                else {
                    MessageBox.Show("Bitte einen Port > 1024 wählen");
                }
            }
            catch (Exception ex) {
                logger.log("ERROR in connection");
            }
        }

        public void sendData(byte[] payload) {
            try {
                if (nw_stream != null) {
                    nw_stream.Write(payload, 0, payload.Length);
                    // log message
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < payload.Length; i++) {
                        sb.Append(payload[i].ToString());
                        if (i != payload.Length - 1)  // until one before the last
                            sb.Append(", ");
                    }
                    string payloadAsString = sb.ToString();
                    logger.logToBox($"Successfully sent: {payloadAsString}");
                }
                else {
                    logger.logToBox("stream not connected");
                }
            }
            catch (Exception ex) {
                logger.logToBox($"ERROR sending data: {ex.ToString()}");
                if (client != null) {
                    client.Close();
                    client = null;
                }
            }
        }
    }
}
