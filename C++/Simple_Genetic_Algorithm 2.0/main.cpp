#include <iostream>
#include <vector>
#include <stdlib.h>
#include <time.h>
//#include <windows.h>
#include "population.h"
#include "individual.h"

using namespace std;

int getUserInput(Population& population, int& size)
{
    int fitness = 0;
    cout << "Please enter the value to solve for: ";
    cin >> fitness;

    cout << "Please enter the population size: ";
    cin >> size;
    population.setSize(size); //set # of individuals in population
    cout << endl;

    return fitness;
}

void printResults(Population population, int pop_size, int solution)
{
    cout << endl << "The solution " << solution
         << " was found in... " << endl;

    population.printGeneration();
    cout << " Generations with a population of "
         << pop_size << " individuals." << endl;
}

void printInfo(Population population)
{
    //Print the generation
    cout << "Generation: ";
    population.printGeneration();

    //Print the best fitness and value of a given generation
    population.printFitnessAndValue();
}

void run(Population population)
{
    int pop_size = 0;
    int solution = getUserInput(population, pop_size);
    int elite_value = 0;
    population.allocateIndividuals();

    population.initializePop();
    population.getBestValue(elite_value);

    while(elite_value != solution)
    {
        population.calculateFitness(solution);
        printInfo(population);

        population.getBestValue(elite_value);
        population.breedPop(elite_value);

        //Sleep(300);
    }

    population.decrementGen();
    printResults(population, pop_size, solution);
}

int main()
{
    Population population;
    run(population);
    return 0;
}
