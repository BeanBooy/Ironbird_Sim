#!/usr/bin/env python3
import sys
import signal
import socket



PORT_CONST = 4443

try:
    # initialize socket
    HOST = '' # We are the Server
    PORT = PORT_CONST
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    server_socket.bind((HOST, PORT))
    server_socket.listen(5)
    print(f"Server waits for {HOST}:{PORT}")
except Exception as e:
    print(f"Server could not be started: {e}")
    sys.exit(1)



#-------------------------------------------------------------------------------------------
# Main server loop
while True:
    try:
        print("Wait for Connection...")
        client_socket, addr = server_socket.accept()
        print(f"Connected to {addr} succesfull")
    except Exception as e:
        print(f"Connection cannot be established: {e}")
        break

    try:
        while True:
            receivedData = client_socket.recv(16)
            if not receivedData:
                break

            printData = ','.join(str(byte) for byte in receivedData)
            print(f"Received data: {printData}")

    except Exception as e:
        print(f"Connection error: {e}")
    finally:
        try:
            client_socket.close()
        except Exception:
            pass