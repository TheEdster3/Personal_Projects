#ifndef POPULATION_H
#define POPULATION_H
#include "Individual.h"

class Population
{
    public:
        Population();
        virtual ~Population();

        Population& initializePop(int firstGenSeed);
        Population& calculateFitness(int fitValue);
        void setElite(Individual newElite);
        Population& printGeneration();
        Population& printFitnessAndValue();
        Population& getBestFitness(int& eliteFitness);
        Population& getBestValue(int& eliteValue);
        Population& increasePopValue(int seedValue);
        Population& decreasePopValue(int seedValue);

    private:
        Individual individual[20];
        Individual elite;
        int generation;

};

#endif // POPULATION_H
