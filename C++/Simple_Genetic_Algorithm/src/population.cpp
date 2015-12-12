#include <iostream>
#include "Population.h"


Population::Population()
{
    generation = 0;
}

Population::~Population()
{

}

Population& Population::getBestFitness(int& elite_fitness)
{
    //For future access to fitness
    elite.getFitness(elite_fitness);
}

Population& Population::getBestValue(int& elite_value)
{
    elite.getValue(elite_value);
}

Population& Population::printGeneration()
{
    std::cout << "Generation: " << generation;
}

Population& Population::printFitnessAndValue()
{
    elite.printFitnessAndValue();
}

Population& Population::initializePop(int seed_value)
{
    //Initialize the population to 20 potentially unique individuals
    generation++;
    for(int i = 0; i < 21; i++)
        individual[i].initializePop(seed_value);
}

Population& Population::increasePopValue(int seed_value)
{
    //Aims to increase the the overall value of the population
    generation++;
    for(int i = 0; i < 21; i++)
        individual[i].increasePopValue(seed_value);
}

Population& Population::decreasePopValue(int seed_value)
{
    //Aims to decrease the overall value of the population
    generation++;
    for(int i = 0; i < 21; i++)
        individual[i].decreasePopValue(seed_value);

}

void Population::setElite(Individual new_elite)
{
    elite.setEliteParameters(new_elite);
}

Population& Population::calculateFitness(int fit_value)
{
    for(int i = 0; i < 21; i++)
    {
        individual[i].calculateFitness(fit_value);
        if(i != 0)
        {
           setElite(individual[i].calculateElite(individual[i-1])); //Pass in the strongest candidate to compare to the elite of all generations so far
        }
    }
}
