using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class Coordinate
{
    
    public double x;
    public double y;


    public Coordinate(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
}

class CoordinateMapper
{
    public Coordinate cords(double num)
    {
        double invertedNum = 63 - num;
        double x, y;
        x = invertedNum % 8;
        y = invertedNum / 8;
        
        return new Coordinate(x, y);
    }
}

