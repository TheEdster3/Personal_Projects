#ifndef POPULATION_H
#define POPULATION_H
#include <vector>
#include "Individual.h"

class Population
{
    public:
        Population();
        virtual ~Population();

        Population& initializePop();
        Population& calculateFitness(int fitValue);
        void setElite(Individual newElite);
        Population& setSize(int size);
        Population& allocateIndividuals();
        Population& printGeneration();
        Population& printFitnessAndValue();
        Population& getBestFitness(int& eliteFitness);
        Population& getBestValue(int& eliteValue);
        Population& breedPop(int seedValue);
        Population& decrementGen();

    private:
        std::vector<Individual> individual;
        Individual elite;
        int pop_size;
        int generation;

};

#endif // POPULATION_H
