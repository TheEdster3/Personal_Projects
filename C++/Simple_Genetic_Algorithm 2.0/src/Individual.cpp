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

Individual& Individual::initializePop()
{
    //initialize the value of the individual to a random
    //value between 0 and 1000
    srand(time(NULL));
    int seed_value = rand() % 1000;

    value = seed_value;
}

Individual& Individual::breedPop(int seed_value)
{
    //Aims to initialize the next generation of individuals
    if((rand() % 30) < 25) //Mutation
    {
        value = seed_value + rand() % 20 - (rand() % 10);
    }
    else
    {
        value = seed_value + rand() % 30 - (rand() % 30);
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
