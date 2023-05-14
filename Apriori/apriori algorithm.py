data = [
        ['T100',['tea','coffee','rice']],
        ['T200',['coffee','pasta']],
        ['T300',['coffee','sugar']],
        ['T400',['tea','coffee','pasta']],
        ['T500',['tea','sugar']],
        ['T600',['coffee','sugar']],
        ['T700',['tea','sugar']],
        ['T800',['tea','coffee','sugar','rice']],
        ['T900',['tea','coffee','sugar']]
        ]

init = []
for i in data:
    for q in i[1]:
        if(q not in init):
            init.append(q)
init = sorted(init)
print(init)

sp = 0.4
s = int(sp*len(init))
s

from collections import Counter
c = Counter()
for i in init:
    for d in data:
        if(i in d[1]):
            c[i]+=1

print("C1:")
for i in c:
    print(str([i])+": "+str(c[i]))
print()

l = Counter()
for i in c:
    if(c[i] >= s):
        l[frozenset([i])]=c[i]
print("L1:")
for i in l:
    print(str(list(i))+": "+str(l[i]))
print()
pl = l
pos = 1
for count in range (2,1000):
    nc = set()
    temp = list(l)
    for i in range(0,len(temp)):
        for j in range(i+1,len(temp)):
            t = temp[i].union(temp[j])
            if(len(t) == count):
                nc.add(temp[i].union(temp[j]))

    nc = list(nc)
    c = Counter()
    for i in nc:
        c[i] = 0
        for q in data:
            temp = set(q[1])
            if(i.issubset(temp)):
                c[i]+=1

    print("C"+str(count)+":")
    for i in c:
        print(str(list(i))+": "+str(c[i]))
    print()

    l = Counter()
    for i in c:
        if(c[i] >= s):
            l[i]+=c[i]

    print("L"+str(count)+":")
    for i in l:
        print(str(list(i))+": "+str(l[i]))
    print()


    if(len(l) == 0):
        break
    pl = l
    pos = count

print("Result: ")
print("L"+str(pos)+":")
for i in pl:
    print(str(list(i))+": "+str(pl[i]))
print()