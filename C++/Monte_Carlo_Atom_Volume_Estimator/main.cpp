#include <iostream>
#include <vector>
#include <stdlib.h>
#include <fstream>
#include <random>
#include <chrono>
#include <algorithm>
#include <time.h>
#include <math.h>
#include "Sphere.h"

using namespace std;

bool sort_spheres(Sphere i, Sphere j)
{
    return (i.Getradius() > j.Getradius());
} //sort spheres

void getFile(vector<Sphere>& spheres, vector<Sphere>& min_max_sphere)
{
    //Various strings for manipulation of the file
    string entries;
    string line_buffer;
    string temp_string;

    int sphere_count;
    float max_radius;
    Sphere temp_sphere;
    Sphere max_sphere;
    //for our needs this ensures proper sorting
    max_sphere.Setx(-2147483647);
    max_sphere.Sety(-2147483647);
    max_sphere.Setz(-2147483647);
    Sphere min_sphere;
    fstream sphere_file;
    sphere_file.open("Volume.txt"); //Open the file
    if (sphere_file.is_open())
    {
            sphere_file >> temp_string;
            sphere_count = atoi(temp_string.c_str()); //assign the first line of the file as the count

            sphere_file >> temp_string; // Get the count out of the stream
            for(int i = 0; i < sphere_count; i++)
            {

                //All of the below if statements are attempts at sorting the input
                temp_sphere.Setx(atof(temp_string.c_str()));

                if(atof(temp_string.c_str()) > max_sphere.Getx())
                    max_sphere.Setx(atof(temp_string.c_str()));

                if(atof(temp_string.c_str()) < min_sphere.Getx())
                    min_sphere.Setx(atof(temp_string.c_str()));

                sphere_file >> temp_string; //get

                temp_sphere.Sety(atof(temp_string.c_str()));

                if(atof(temp_string.c_str()) > max_sphere.Gety())
                    max_sphere.Sety(atof(temp_string.c_str()));

                if(atof(temp_string.c_str()) < min_sphere.Gety())
                    min_sphere.Sety(atof(temp_string.c_str()));

                sphere_file >> temp_string; //get

                temp_sphere.Setz(atof(temp_string.c_str()));
                if(atof(temp_string.c_str()) > max_sphere.Getz())
                    max_sphere.Setz(atof(temp_string.c_str()));

                if(atof(temp_string.c_str()) < min_sphere.Getz())
                    min_sphere.Setz(atof(temp_string.c_str()));

                sphere_file >> temp_string; //get

                temp_sphere.Setradius(atof(temp_string.c_str()));
                if(atof(temp_string.c_str()) > max_radius)
                    min_max_sphere.at(1).Setradius(atof(temp_string.c_str())); //Record the maximum radius of the sphere

                sphere_file >> temp_string; //get

                //Assigns the values of the minimum and maximum sphere
                //helps in determining box dimensions
                min_max_sphere.at(1).Setx(max_sphere.Getx());
                min_max_sphere.at(0).Setx(min_sphere.Getx());
                min_max_sphere.at(1).Sety(max_sphere.Gety());
                min_max_sphere.at(0).Sety(min_sphere.Getx());
                min_max_sphere.at(1).Setz(max_sphere.Getz());
                min_max_sphere.at(0).Setz(min_sphere.Getx());

                spheres.push_back(temp_sphere); //Push to the vector
            } //Assign values to each sphere and then push  it to the vector
        }
                //cout << line_buffer << " ";

            //cout << line_buffer << " ";
        sphere_file.close();
        sort(spheres.begin() + 4, spheres.end(), sort_spheres); //sort'em
} //load the file into memory

void throwDart(vector<Sphere>& spheres, vector<Sphere>& min_max_sphere,
               int& volume, int& random_throws, float side_multiplier,
               bool do_surface, bool do_volume, int trial_number, int trials)
{

    float max_radius = min_max_sphere.at(1).Getradius();

    //Assign the minimums and maximums times a multiplier as the box dimensions
    //Different box sizes are not implemented so far, and as of now the box
    //is twice the minimum size needed
    float min_x = side_multiplier * (min_max_sphere.at(0).Getx() - (2*max_radius));
    float min_y = side_multiplier * (min_max_sphere.at(0).Gety() - (2*max_radius));
    float min_z = side_multiplier * (min_max_sphere.at(0).Getz() - (2*max_radius));

    float max_x = side_multiplier * (min_max_sphere.at(1).Getx() + (2*max_radius));
    float max_y = side_multiplier * (min_max_sphere.at(1).Gety() + (2*max_radius));
    float max_z = side_multiplier * (min_max_sphere.at(1).Getz() + (2*max_radius));

    srand(time(NULL)); //seed the randomness for later use
    unsigned seed = std::chrono::system_clock::now().time_since_epoch().count(); //This ensures a unique seed
    default_random_engine generator(seed); //seed it

    //All random points will fall into a uniform distribution within
    //Inside of the box determined earlier
    uniform_real_distribution<float> rand_x(min_x, max_x);
    uniform_real_distribution<float> rand_y(min_y, max_y);
    uniform_real_distribution<float> rand_z(min_z, max_z);

    int j = 0;
    ofstream points;
    points.open("points.csv"); //Open the file which records the points that hit the structure
    Sphere temp_sphere;
    for(int i = 0; i < random_throws; i++)
    {
        //Generate three random points
        float x = rand_x(generator);
        float y = rand_y(generator);
        float z = rand_z(generator);

        for(int j = 0; j < spheres.size(); j++)
        {
            temp_sphere = spheres[j]; //temp sphere for comparison

            //Calculates the distance from the point to the origin of the temporary sphere
            double distance = sqrt((pow(temp_sphere.Getx() - x , 2.0)
                                    + pow(temp_sphere.Gety() - y, 2.0)
                                    + pow(temp_sphere.Getz() - z, 2.0)));

            //the below if statement compares the point to all spheres to see where it falls

            if(do_volume) { //If they user chose volume
                if(distance <= (temp_sphere.Getradius()))
                {

                    points << x << "," << y << "," << z;
                    points << ",IN\n";
                    volume++;
                    break;
                } //If it's a hit!

                //else {
                //    points << x << "," << y << "," << z;
                //    points << ",OUT\n";
                //} //If you would like to record points that aren't in the structure uncomment this
            }

            else if (do_surface) { //If the user chose surface area
                if(distance > (temp_sphere.Getradius() - .01) && distance < (temp_sphere.Getradius() + .01)) //tolerance of .05
                {
                    points << x << "," << y << "," << z;
                    points << ",IN\n";
                    volume++;
                    break;
                } //If the point falls within the structure
            } //calculates if it's a hit
        }

    }
    points.close(); //close file

    //cout << volume;
}

void calcVolume(int& volume, int random_throws, vector<Sphere> spheres,
                vector<Sphere>& min_max_sphere, float side_multiplier, float& vol_average, ofstream& volumes,
                bool do_surface, bool do_volume)
{
    float max_radius = min_max_sphere.at(1).Getradius(); //Get the maximum radius
    float x_side = abs((min_max_sphere.at(1).Getx() + 2*max_radius) - (min_max_sphere.at(0).Getx() - (2*max_radius))); //Get the length
    float y_side = abs((min_max_sphere.at(1).Gety() + 2*max_radius) - (min_max_sphere.at(0).Gety() - (2*max_radius))); //Get the width
    float z_side = abs((min_max_sphere.at(1).Getz() + 2*max_radius) - (min_max_sphere.at(0).Getz() - (2*max_radius))); //Get the height

    float cube_volume = ((side_multiplier * x_side) * (side_multiplier * y_side) * (side_multiplier * z_side)); //Volume of the cube

    cout << volume << "/" << random_throws << " * " << cube_volume << endl; //Print the equation
    float vol_estimate = 0;
    vol_estimate = ((float)volume/(float)random_throws) * cube_volume; //Final value for the volume of all spheres

    if(do_volume){
        cout << "Volume Estimate: " << vol_estimate << endl;
    }
    else if(do_surface){
        cout << "Surface Area Estimate: " << vol_estimate << endl;
    }
    volumes << vol_estimate << "," << "Trial" << "\n";
    //outputToCSV
    vol_average += vol_estimate; //Add to average

}

/* For bug testing!
void print(vector<Sphere> spheres)
{
    Sphere temp_sphere;
    for(int i = 0; i < spheres.size(); i++)
    {
        temp_sphere = (spheres[i]);
    }
}
*/

void initializeMinMax(vector<Sphere>& min_max_sphere)
{
    //Push minimum and maximum spheres for later assignment
    Sphere generic_sphere;
    min_max_sphere.push_back(generic_sphere);
    min_max_sphere.push_back(generic_sphere);
} //Initialize minimum and maximum sphere values

void getUserInput(bool &do_surface, bool &do_volume, int &trials, int &random_throws)
{
    string user_in;
    int user_throws;
    int user_trials;
    cout << "Would you like to estimate the surface area or volume? (surface/volume/exit)" << endl; //Ask user
    cin >> user_in;

    while(true) {
        if(user_in == "surface") {
            do_surface = true;
            break;
        } //If surface then save that
        else if(user_in == "volume") {
            do_volume = true;
            break;
        } //If volume then save that
        else if(user_in == "exit") //If exit then exit
            exit(0);
        else {
            cout << "Your input is not correct, please check your spelling." << endl;
            cin >> user_in;
        } //Tell the user their input is incorrect
    }

    cout << "How many randomly distributed points would you like to place?" << endl;
    cin >> user_throws;
    while(true) {
        if(user_throws > 2147483647 || user_throws < -2147483647) {
            cout << "Your input is too large or too small, please adjust within the bounds of signed 32 bit integer" << endl;
            cin >> user_throws;
        } //Check for too large or too small a number
        else {
            random_throws = user_throws;
            break;
        } //Save the number of points placed around the structure
    }

    cout << "How many times would you like to run the program consecutively?" << endl;
    cin >> user_trials;
    while(true) {
        if(user_trials > 2147483647 || user_trials < -2147483647) {
            cout << "Your input is too large or too small, please adjust within the bounds of signed 32 bit integer" << endl;
            cin >> user_trials;
        } //check for too large or too small a number
        else {
            trials = user_trials;
            break;
        } //save the number of trials the user wants to run
    }
    //Get user input here
} //Determine control flow of the problem

void run(vector<Sphere> spheres, vector<Sphere>& min_max_sphere ,float& vol_average)
{
    //Make these user chosen
    float side_multiplier = 1; //Could eventually increase size of the box in which the points fall. Control not implemented
    int random_throws = 0; //Number of points generated
    int volume = 0; //for the later volume calculation
    bool do_surface = false; //Are we doing surface?
    bool do_volume = false; //Are we doing volume?
    int trials = 1; //How many times are we running the whole program
    int trial_number = 1; //What trial are we? For continuously adding to csv
    clock_t t1, t2; //For later time comparison

    getUserInput(do_surface, do_volume, trials, random_throws);
    initializeMinMax(min_max_sphere); //determines min and max sphere
    getFile(spheres, min_max_sphere); //insert the spheres into the array of sphere objects
    ofstream volumes;
    volumes.open("volume_estimates.csv"); //Open the file to write volumes to
    t1 = clock();
    for(int i = 0; i < trials; i++)
    {
        int volume = 0;
        //Generates the points and tests if they are in an existing sphere.
        throwDart(spheres, min_max_sphere, volume,
                  random_throws, side_multiplier,
                  do_surface, do_volume, trial_number, trials);

        //calculates the volume that is eventually outputted
        //Volume the hits that land in the structure divided by the total points placed
        calcVolume(volume, random_throws, spheres,
                   min_max_sphere, side_multiplier,
                   vol_average, volumes,do_surface, do_volume);

        trial_number++;
    }
    //Output values to excel file eventually
    if(trials != 1) {
        cout << endl;
        if(do_volume)
            cout << "Volume Average: "<< vol_average/trials;
        else
            cout << "Surface Area Average: "<< vol_average/trials;

        cout << endl;
    } //If there was more than one trial then print the average
    t2 = clock();
    //Run time of the hard calculations
    //Does not include loading the spheres into the program
    float seconds = (t2 - t1) / CLOCKS_PER_SEC;
    cout << "Executed in " << seconds << " seconds." << endl;

    volumes << (vol_average/trials) << "," <<"Average"; //send volume average to volumes file
    volumes.close();
}

int main()
{
    vector<Sphere> spheres;
    vector<Sphere> min_max_sphere; //Sphere 0 is min, sphere 1 is max;
    float vol_average = 0;
    run(spheres, min_max_sphere, vol_average);
}
