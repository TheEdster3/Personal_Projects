#include <iostream>
#include <stdlib.h>
#include <time.h>
#include "Individual.h"

Individual::Individual()
{
    value = 0;
    fitness = 0;
}

Individual::~Individual()
{

}

Individual& Individual::initializePop(int seed_value)
{
    //initialize the value of the individual to it's
    //generational seed value for numbers 0 through 19
    value = seed_value + rand() % 20;
}

Individual& Individual::increasePopValue(int seed_value)
{
    //Aims to increase the the overall value of the population
    if((rand() % 30) < 25)
    {
        value = seed_value + rand() % 20;
    }
    else
    {
        value = seed_value + rand() % 30 - 10;
    }

}

Individual& Individual::decreasePopValue(int seed_value)
{
    //Aims to decrease the overall value of the population
    if((rand() % 30) < 25)
    {
        value = seed_value - rand() % 20;
    }
    else //Occassionally mutate
    {
        value = seed_value - rand() % 30 + 10;
    }
}

Individual& Individual::setEliteParameters(Individual& new_elite)
{
    if(new_elite.fitness > fitness)
    {
        value = new_elite.value;
        fitness = new_elite.fitness;
    }
}
Individual& Individual::printFitnessAndValue()
{
    std::cout << " Fitness level: " << fitness/10;
    std::cout << " Value: " << value;
    std::cout << std::endl;
}

Individual& Individual::getFitness(int& elite_fitness)
{
    elite_fitness = fitness;
}

Individual& Individual::getValue(int& elite_value)
{
    elite_value = value;
}

Individual& Individual::calculateFitness(int fit_value)
{
    int fitness_group = fit_value - value;
    //std::cout << "Value: " << value << " " << std::endl;

    //the if catches the solution
    //the two elses measure the distance from the solution to calculate fitness
    if(fit_value > value)
    {
        fitness = (1000 - (fitness_group));
    }
    else
    {
        fitness = (1000 + fitness_group);
    }

    //If fitness gets too far away then restart the values


    //std::cout << "Fitness: " << fitness << " ";
}

Individual& Individual::calculateElite(Individual prev_individual)
{
    if(fitness > prev_individual.fitness)
    {
        return *this;
    }
    else
    {
        return prev_individual;
    }
}
