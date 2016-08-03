import numpy as np
import matplotlib.mlab as mlab
import matplotlib.pyplot as plt
import statistics
import csv

f = open('volume_estimates.csv') 
csv_f = csv.reader(f)
x = []

for row in csv_f:
    if(row[1] == "Average"):
        mu = float(row[0]) # mean of distribution
    else:
        x.append(float(row[0]))
    
sigma = statistics.stdev(x)  # standard deviation of distribution


num_bins = 20
# the histogram of the data
n, bins, patches = plt.hist(x, num_bins, normed=1, facecolor='blue', alpha=.7)
# add a 'best fit' line
y = mlab.normpdf(bins, mu, sigma)
plt.plot(bins, y, 'r--')
plt.xlabel('Volume')
plt.ylabel('Probability')
plt.title(r'Histogram of Volume: $\mu=' + str(int(mu)) + '$, $\sigma=' + str(int(sigma)) +'$')

# Tweak spacing to prevent clipping of ylabel
plt.subplots_adjust(left=0.15)
plt.show()
