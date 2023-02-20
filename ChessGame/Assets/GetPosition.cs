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

  
    

    


}
