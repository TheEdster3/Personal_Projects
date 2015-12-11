#include <iostream>
#include "Population.h"


Population::Population()
{
    pop_size = 0;
    generation = 0;
}

Population::~Population()
{

}

Population& Population::decrementGen()
{
    generation--;
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
    std::cout << generation;
}

Population& Population::printFitnessAndValue()
{
    elite.printFitnessAndValue();
}

Population& Population::initializePop()
{
    //Initialize the population to 20 potentially unique individuals
    generation++;
    for(int i = 0; i < pop_size; i++)
        individual[i].initializePop();
}

Population& Population::breedPop(int seed_value)
{
    //Aims to increase the the overall value of the population
    generation++;
    for(int i = 0; i < pop_size; i++)
        individual[i].breedPop(seed_value);
}

void Population::setElite(Individual new_elite)
{
    elite.setEliteParameters(new_elite);
}

Population& Population::setSize(int size)
{
    pop_size = size;
}

Population& Population::allocateIndividuals()
{
    Individual generic_individual;
    for(int i = 0; i < pop_size; i++)
        individual.push_back(generic_individual);
}

Population& Population::calculateFitness(int fit_value)
{
    for(int i = 0; i < pop_size; i++)
    {
        individual[i].calculateFitness(fit_value);
        if(i != 0)
        {
           setElite(individual[i].calculateElite(individual[i-1])); //Pass in the strongest candidate to compare to the elite of all generations so far
        }
    }
}
