import numpy as np
from matplotlib import pyplot
import pylab
from mpl_toolkits.mplot3d import Axes3D
import csv

fig = pylab.figure()
ax = Axes3D(fig)
f = open('points.csv')
csv_f = csv.reader(f)

xo = []
yo = []
zo = []

xi = []
yi = []
zi = []
color = []

for row in csv_f:
    if (row[3] == "IN"):
        xi.append(float(row[0]))
        yi.append(float(row[1]))
        zi.append(float(row[2]))
    else:
        xo.append(float(row[0]))
        yo.append(float(row[1]))
        zo.append(float(row[2]))

ax.scatter(xi, yi, zi, c = 'r')
#ax.scatter(xo, yo, zo, alpha = .01)
pyplot.show()
