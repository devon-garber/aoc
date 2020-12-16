degrees = 90 # We start facing east which is 90 degrees in my mind
totalNS = 0 # Used to determine total North + South at the end
totalEW = 0 # Used to determine total East + West at the end

def MoveForward(value):
    global degrees
    global totalNS
    global totalEW
    currentFacing = degrees % 360
    if (currentFacing == 0): # 0 means move North
        totalNS += value
    elif (currentFacing == 90): # 90 degrees means move east
        totalEW += value
    elif (currentFacing == 180): # 180 means move south
        totalNS -= value
    elif (currentFacing == 270): # 270 means move west
        totalEW -= value
    else:
        raise Exception("Incorrectly formatted data") # Bad data, cause an error

def ProcessData(sentinel, value):
    global degrees
    global totalNS
    global totalEW
    if (sentinel == 'N'):
        totalNS += value
    if (sentinel == 'S'):
        totalNS -= value
    if (sentinel == 'E'):
        totalEW += value
    if (sentinel == 'W'):
        totalEW -= value
    if (sentinel == 'L'):
        degrees -= value
    if (sentinel == 'R'):
        degrees += value
    if (sentinel == 'F'):
        MoveForward(value)

file = open("input12.1.txt", "r")
for line in file:
    sentinel = line[0:1]
    value = int(line[1:])
    ProcessData(sentinel, value)
print(abs(totalNS) + abs(totalEW))
file.close()