using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetPosition : MonoBehaviour
{
    
    Piece newPiece;
    public double x , y;
    public GameObject objects;
    public  Vector2 position2;
    Vector2[] list;
    
    public bool hasRun = false;
    public GameObject[] pieces;
   
   
    public List<Vector2> prefabPositions = new List<Vector2>();
    
   
    public void Test()
    {
        
        if (!hasRun){
    //   GameObject gameObject = new GameObject("Piece");
    // newPiece = gameObject.AddComponent<Piece>();
            
    //         GameObject[] prefabInstance = GameObject.FindGameObjectsWithTag("Square");
    //         //pieces = prefabInstance;
    //         int i = 0;
    //         foreach (GameObject prefab in prefabInstance)
    //         {

    //             //Debug.Log(prefab.transform.position);
    //             prefabPositions.Add(prefab.transform.position);
    //             i++;
                
                
    //         }
            // Get the parent object that contains the squares
    Transform squaresParent = GameObject.FindWithTag("Finish").transform;

    // Loop through the children of the parent object in order
    for (int i = 0; i < squaresParent.childCount; i++)
    {
        Transform child = squaresParent.GetChild(i);
        // Add the position of the square to the list
        prefabPositions.Add(child.position);
    }
           
        
    }

  
    
    hasRun = true;
    
}

}
