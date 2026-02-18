#------------------------------------------------*
# Autor: Noah Gerstlauer                          |
# Department: THGM-TL1                            |
# Email: Noah.Gerstlauer@airbus.com               |
# Date: 2023-09                                   |
#------------------------------------------------*/

# Gibt alle auf dem entsprechenden Port empfangenen Daten aus. (Kommunikationstest)

import socket

HOST = socket.gethostbyname(socket.gethostname())
PORT = 4444

server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_socket.bind((HOST, PORT))
server_socket.listen(5)

own_ip = socket.gethostbyname(socket.gethostname()) # gives back the IPv4-address
print(f"Server lauscht auf {own_ip}:{PORT}")

while True:
    client_socket, addr = server_socket.accept()
    print(f"Verbindung von {addr} hergestellt")

    while True:
        data = client_socket.recv(16) # 16 is the bufsize of received data as a byte object
        if not data: # receiving 0 equals disconnect
            break

        received_data = ','.join(str(byte) for byte in data) # joins the byte objects seperated via ','
        print(f"Empfangene Daten: {received_data}")
    client_socket.close()

