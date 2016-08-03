#ifndef SPHERE_H
#define SPHERE_H


class Sphere
{
    public:
        Sphere();
        virtual ~Sphere();

        float Getx() { return x; }
        void Setx(float val) { x = val; }

        float Gety() { return y; }
        void Sety(float val) { y = val; }

        float Getz() { return z; }
        void Setz(float val) { z = val; }

        float Getradius() { return radius; }
        void Setradius(float val) { radius = val; }

    private:
        float x;
        float y;
        float z;
        float radius;
};

#endif // SPHERE_H
