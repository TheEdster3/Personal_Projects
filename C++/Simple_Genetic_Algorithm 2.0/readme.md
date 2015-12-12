**Preface**
-------
Genetic algorithms are algorithms that use randomness and heuristics to find the solution to a problem that isn't easily obtainable. Often times problems of global optimization, and time tables are solved using genetic algorithms. 

**Program**
-------
This program aims to solve solve a basic addition problem via the use of a simple genetic algorithm. The user gives the program a number to solve for (the solution), and a population size. A population sized by the user will be born with random values from 0 to 1000.

These individuals will be compared to the user input and given a fitness value based on their distance from the solution. If a solution is not found then the most fit individual of the group has it's parameters used as a seed for the next generation. If a solution is found then the program is complete.

**Potential additions**
--------------------------
 - Choice of population 
 - More complex solution
 - Chromosomal cross over

**Thoughts**
--------
I would love to eventually use an algorithm like this to solve popular NES games, and the such. Obviously this program is extremely simple, and is solving a known problem. It's principles stand however. I was pretty happy for a first attempt.
