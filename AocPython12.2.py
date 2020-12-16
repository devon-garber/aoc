totalNS = 0 # Used to determine total North + South at the end
totalEW = 0 # Used to determine total East + West at the end
waypointNS = 1 # Used for waypoint's current NS position
waypointEW = 10 # Used for waypoint's current EW position

def RotateLeft(value):
    global waypointNS
    global waypointEW
    if (value == 270):
        swapHolder = waypointNS
        waypointNS = -waypointEW
        waypointEW = swapHolder
    elif (value == 180):
        waypointNS = -waypointNS
        waypointEW = -waypointEW
    elif (value == 90):
        swapHolder = waypointNS
        waypointNS = waypointEW
        waypointEW = -swapHolder
    else:
        raise Exception("Incorrectly formatted data") # Bad data, cause an error

def RotateRight(value):
    global waypointNS
    global waypointEW
    if (value == 90):
        swapHolder = waypointNS
        waypointNS = -waypointEW
        waypointEW = swapHolder
    elif (value == 180):
        waypointNS = -waypointNS
        waypointEW = -waypointEW
    elif (value == 270):
        swapHolder = waypointNS
        waypointNS = waypointEW
        waypointEW = -swapHolder
    else:
        raise Exception("Incorrectly formatted data") # Bad data, cause an error

def MoveForward(value):
    global waypointNS
    global waypointEW
    global totalNS
    global totalEW
    totalNS += waypointNS * value
    totalEW += waypointEW * value

def ProcessData(sentinel, value):
    global waypointNS
    global waypointEW
    if (sentinel == 'N'):
        waypointNS += value
    if (sentinel == 'S'):
        waypointNS -= value
    if (sentinel == 'E'):
        waypointEW += value
    if (sentinel == 'W'):
        waypointEW -= value
    if (sentinel == 'L'):
        RotateLeft(value)
    if (sentinel == 'R'):
        RotateRight(value)
    if (sentinel == 'F'):
        MoveForward(value)

file = open("input12.1.txt", "r")
for line in file:
    sentinel = line[0:1]
    value = int(line[1:])
    ProcessData(sentinel, value)
print(abs(totalNS) + abs(totalEW))
file.close()