def ApplyMask(memValue, mask):
    newBinString = ""
    memValueBinString = format(memValue, '036b')
    for i in range(len(mask) - 1):
        if (mask[i] == 'X'): # Take from the original number
            newBinString += memValueBinString[i]
        elif (mask[i] == '0'):
            newBinString += '0'
        elif (mask[i] == '1'):
            newBinString += '1'
        else:
            raise Exception("Incorrectly formatted binary string") # Bad data, cause an error
    return int(newBinString, 2)

def GetMemValue(line):
    return int(line.split('[')[1].split(']')[1][3:]) # Messy string manip but it works

def GetMemAddress(line):
    return int(line.split('[')[1].split(']')[0])

def GetListSize():
    listSize = 0
    file = open("input14.1.txt", "r")
    for line in file.readlines():
        if (line[0:3] == "mem"):
            memValue = GetMemAddress(line)
            if (memValue > listSize):
                listSize = memValue
    return listSize + 1 # +1 just for safety in case I am off by one

file = open("input14.1.txt", "r")
memory_array = [0] * GetListSize()
mask = ""
for line in file.readlines():
    if (line[0:4] == "mask"):
        mask = line[7:]
    elif (line[0:3] == "mem"):
        memAddr = GetMemAddress(line)
        memValue = GetMemValue(line)
        actualMemValue = ApplyMask(memValue, mask)
        memory_array[memAddr] = actualMemValue
    else:
        raise Exception("Incorrectly formatted data") # Bad data, cause an error
print(sum(memory_array))
