#include <iostream>
#include <stdlib.h>
#include <time.h>
#include <windows.h>
#include "population.h"
#include "individual.h"

using namespace std;

int getFitValue()
{
    int fitness = 0;
    cout << "Please enter the value to solve for : ";
    cin >> fitness;
    cout << endl;
    return fitness;
}

void printInfo(Population population)
{
    population.printGeneration();
    population.printFitnessAndValue();
}

void run(Population population)
{
    srand(time(NULL));
    int first_gen_seed = rand() % 1000;
    int solution = getFitValue();
    int elite_value = 0;

    population.initializePop(first_gen_seed);
    population.getBestValue(elite_value);
    while(elite_value != solution)
    {
        population.calculateFitness(solution);
        printInfo(population);

        population.getBestValue(elite_value);

        if(elite_value < solution)
            population.increasePopValue(elite_value);
        else
            population.decreasePopValue(elite_value);

        //Sleep(300);
    }

}

int main()
{
    Population population;
    run(population);
    return 0;
}
