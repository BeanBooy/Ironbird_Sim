using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EurofighterCockpit
{
    internal class TcpConnectionManager : IDisposable
    {
        private Logger logger = Logger.Instance;

        private readonly string ipAddress;
        private readonly int port;

        private TcpClient client;
        private NetworkStream stream;
        private int connectionLoopDelay = 3000;  // ms

        private readonly CancellationTokenSource cts = new CancellationTokenSource();
        private readonly object padlock = new object();
        private Task connectionTask;

        public bool IsConnected {
            get {
                try {
                    if (client == null || !client.Connected)
                        return false;

                    if (client.Client.Poll(0, SelectMode.SelectRead))
                        return client.Client.Available != 0;

                    return true;
                }
                catch {
                    return false;
                }
            }
        }


        public event Action<bool> ConnectionStatusChanged;

        public TcpConnectionManager(string ipAddress, int port) {
            this.ipAddress = ipAddress;
            this.port = port;
        }

        public void start() {
            connectionTask = Task.Run(connectionLoopAsync);
        }

        private async Task connectionLoopAsync() {
            try {
                // loop until program end
                while (!cts.Token.IsCancellationRequested) {
                    if (!IsConnected) {
                        // if not connected, try to connect
                        try {
                            TcpClient newClient = new TcpClient();
                            Task connectTask = newClient.ConnectAsync(ipAddress, port);
                            Task timeoutTask = Task.Delay(5000);

                            if (await Task.WhenAny(connectTask, timeoutTask) != connectTask) {
                                newClient.Close();
                                throw new TimeoutException("Connect timeout");
                            }

                            // required for catching possible exceptions
                            await connectTask;

                            NetworkStream newStream = newClient.GetStream();

                            lock (padlock) {
                                client = newClient;
                                stream = newStream;
                            }

                            logger.log($"TCP connected successfully to {ipAddress}:{port}");
                            ConnectionStatusChanged?.Invoke(true);
                        }
                        catch {
                            ConnectionStatusChanged?.Invoke(false);
                        }
                    }
                    // sleep
                    await Task.Delay(connectionLoopDelay, cts.Token);
                }
            }
            catch (TaskCanceledException) {
                logger.logToBox("Connection loop canceled.");
            }
            catch (Exception ex) {
                logger.logToBox("Connection loop crashed: " + ex.Message);
            }
        }

        public async Task sendAsync(byte[] payload, bool logMessage) {
            if (!IsConnected)
                return;

            try {
                await stream.WriteAsync(payload, 0, payload.Length);
            }
            catch {
                handleDisconnect();
                return;
            }
            // log to logBox
            if (logMessage)
                logger.logToBox($"sent: {string.Join(" ", payload.Select(b => Convert.ToString(b).PadLeft(3, ' ')))}");
        }

        private void handleDisconnect() {
            lock (padlock) {
                try { stream?.Close(); } catch { }
                try { client?.Close(); } catch { }

                stream = null;
                client = null;
            }
            logger.logToBox("handle disconnect");
            ConnectionStatusChanged?.Invoke(false);
        }

        public void Dispose() {
            cts.Cancel();
            handleDisconnect();
        }

    }
}
