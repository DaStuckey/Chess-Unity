using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOcc 
{
   
   
    
    
   
    public Destroy d = new Destroy();
    public (bool, bool) isOccupied(double a, double b, GameObject piece)
    {
         Debug.Log("3");
        GameObject[] prefabInstances = GameObject.FindGameObjectsWithTag("Piece");

        int i = 0;
        foreach (GameObject prefab in prefabInstances)
        {
            
            Piece script = prefab.GetComponent<Piece>();
            
            if (script.x == a && script.y == b)
            {

                if (piece.GetComponent<Piece>().isBlack == script.GetComponent<Piece>().isBlack)
                {
                    Debug.Log("Hit");
                      return (false, false);
                }
                else
                {
                            Destroy be = new Destroy();
                            be.des = prefabInstances[i];
                            this.d = be;
                            return (true, true);
                }
            }
            i++;
        }
        return (true, false);
    }
}
