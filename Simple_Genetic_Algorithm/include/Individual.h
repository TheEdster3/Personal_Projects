#ifndef INDIVIDUAL_H
#define INDIVIDUAL_H

class Individual
{
    public:
        Individual();
        virtual ~Individual();

        Individual& initializePop(int seedValue);
        Individual& increasePopValue(int seedValue);
        Individual& decreasePopValue(int seedValue);
        Individual& calculateFitness(int fitValue);
        Individual& setEliteParameters(Individual& newElite);
        Individual& calculateElite(Individual lastIndividual);
        Individual& getFitness(int& eliteFitness);
        Individual& getValue(int& eliteValue);
        Individual& printFitnessAndValue();

    private:
        int value;
        int fitness;
};

#endif // INDIVIDUAL_H
