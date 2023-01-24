using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetCords 
{
    public (double, double) GetCord(double inputValue)
    {

        CoordinateMapper mapper = new CoordinateMapper();
        Coordinate result = mapper.cords(inputValue);
        //Debug.Log("The x cord is: " + Math.Floor(result.x));
       // Debug.Log("The y cord is: " + Math.Floor(result.y));
        return (result.x, result.y);
    }
}
