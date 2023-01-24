using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetPosition : MonoBehaviour
{
    void Start()
    {
        Test();
    }
    Piece newPiece = new Piece();
    public Destroy d = new Destroy();
    public double x , y;
    public GameObject objects;
    public  Vector2 position2;
    Vector2[] list;
    public static List<Vector2> prefabPositions = new List<Vector2>();
    public static bool hasRun = false;
    public GameObject[] pieces;

    public static void Test()
    {
      if (!hasRun)
        {
            
            GameObject[] prefabInstance = GameObject.FindGameObjectsWithTag("Square");
            //pieces = prefabInstance;
            int i = 0;
            foreach (GameObject prefab in prefabInstance)
            {

                //Debug.Log(prefabInstance[i].GetComponent<GetPosition>().x);
                prefabPositions.Add(prefab.transform.position);
                i++;
                
                
            }
            
            hasRun = true;
        }
        
    }

  
    public (bool, bool) isOccupied(double a, double b, GameObject piece)
    {
        GameObject[] prefabInstances = GameObject.FindGameObjectsWithTag("Piece");
        
        int i = 0;
        foreach (GameObject prefab in prefabInstances)
        {
            //Debug.Log("Array Contains: " + prefab.name);
            Piece script = prefab.GetComponent<Piece>();
            //Debug.Log(script.x + " : " + a + " : " + script.y + " : " + b);
            if (script.x == a && script.y == b)
            {
                 
               
                if (piece.GetComponent<Piece>().isBlack == script.GetComponent<Piece>().isBlack)
                {
                    King kingScript = piece.GetComponent<King>();
                    if (kingScript != null)
                    {

                        if (piece.GetComponent<King>().checkCounter == 0)
                        {

                            return (false, false);
                        }
                        else return (true, false);
                    }
                    else return (false, false);
                }
                else
                {
                    King kingScript = piece.GetComponent<King>();
                    if (kingScript != null)
                    {

                        if (piece.GetComponent<King>().checkCounter == 0)
                        {
                            Destroy be = new Destroy();
                            be.des = prefabInstances[i];
                            this.d = be;
                            return (true, true);
                        }
                        else if (piece.GetComponent<King>().checkCounter == 1)
                        {
                            Knight knightScript = prefab.GetComponent<Knight>();
                            if (knightScript != null)
                            {
                                return (false, false);
                            }
                        }
                    }
                    else
                    {
                        Destroy be = new Destroy();
                        be.des = prefabInstances[i];
                        this.d = be;
                        return (true, true);
                    }
                }
            }
            i++;
        }
        return (true, false);
    }

    


}
