#!/usr/bin/env python
# -*- coding: utf-8 -*-
import socket

# TCP_IP = '192.168.178.20'
TCP_IP = ''
TCP_PORT = 13337
BUFFER_SIZE = 20  # Normally 1024, but we want fast response

C_CLIENT_LOST = -2
C_NO_COMMAND = -1
C_STOP = 0
C_FORWARD = 1
C_LEFT = 2
C_RIGHT = 3
C_BACKWARD = 4

def default(arg):
    print arg
speedCallback = default
clientLostCallback = default



def openServer():
    global s
    global conn
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    s.bind((TCP_IP, TCP_PORT))
    s.listen(1)
    searchForClient()

def searchForClient():
    global conn
    conn, addr = s.accept()
    print 'Connection address:', addr

def closeServer():
    global conn
    conn.sendall("Connection lost: Error occurred!")
    conn.close()

def waitForCommand():
    global conn
    data = conn.recv(BUFFER_SIZE)
    #data = raw_input()

    if not data:
        clientLostCallback()
        return C_CLIENT_LOST

    if "speed" in data and len(data) > 6:
        try:
            speedCallback(float(data[6:]))
            return C_NO_COMMAND
        except ValueError:
            return C_NO_COMMAND

    cmd = {
        "stop" : C_STOP,
        "forward" : C_FORWARD,
        "left" : C_LEFT,
        "right" : C_RIGHT,
        "backward" : C_BACKWARD
    }
    return cmd.get(data, C_NO_COMMAND)


def setSpeedCallback(f):
    speedCallback = f

def setClientLostCallback(f):
    clientLostCallback = f


if __name__ == '__main__':
    print "Server main"
    openServer()
    try:
        while 1:
            c = waitForCommand()
            if c == C_CLIENT_LOST:
                print "C_CLIENT_LOST"
                searchForClient()
            print c
    except KeyboardInterrupt:
        closeServer()
    except socket.error as msg:
        closeServer()
    except:
        closeServer()