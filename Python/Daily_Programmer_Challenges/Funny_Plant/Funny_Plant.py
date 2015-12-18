def calcFruit(population, fruit):
    rec_fruit = 0
    plants = fruit
    weeks = 1
    while rec_fruit < population:
        rec_fruit += plants
        plants += rec_fruit
        weeks += 1
        
    print('\nIt will take ' + str(weeks) + 
          ' weeks to support a population of ' + str(population) + '.\n')

population, fruit = input('Please input your population, and ' +
                          'the number of fruit you have seperated by a  space.\n').split()

population = int(population)
fruit = int(fruit)

calcFruit(population, fruit)
