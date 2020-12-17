file = open("input13.1.txt", "r")
myTime = int(file.readline())
timeToWait = 100000000
busId = 100000000
for busValue in file.readline().split(','):
    if (busValue != 'x'): # Ignore all 'x' value as they don't mean anything to us
        divResult = int(myTime / int(busValue))
        newTimeToWait = ((divResult + 1) * int(busValue)) - myTime
        if (newTimeToWait < timeToWait):
            timeToWait = newTimeToWait
            busId = int(busValue)
print(busId * timeToWait)
