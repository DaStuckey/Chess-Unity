using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCheck 
{
    double x;
    double y;
    GameObject[] kingObjects;
    GameObject[] piece;
    public static bool hasRun = false;
     public void Stat()
    {
        
            King[] kings = Resources.FindObjectsOfTypeAll<King>();
            kingObjects = new GameObject[kings.Length];
            

            for (int i = 0; i < kings.Length; i++)
            {
                kingObjects[i] = kings[i].gameObject;
                Debug.Log(kingObjects[i].GetComponent<Piece>().isBlack + " : " + 1 + i);
            }
            GameObject[] prefabInstances = GameObject.FindGameObjectsWithTag("Piece");
            piece = new GameObject[prefabInstances.Length];
            for (int i = 0; i < prefabInstances.Length; i++){
                piece[i] = prefabInstances[i].gameObject;
            }

            hasRun = true;
        
    }
   
   public bool inCheck(double a, double b, GameObject p){
                double tempX = p.GetComponent<Piece>().x;
                double tempY = p.GetComponent<Piece>().y;
                
                p.GetComponent<Piece>().x = a;
                p.GetComponent<Piece>().y = b;
        Stat();
        x = 0;
        y = 0;
        ////////////////////////////////////////////////////////////////////////////////////////
        bool isBlack = p.GetComponent<Piece>().isBlack;
        if (p.GetComponent<King>() != null){
            x = a;
            y = b;
        }
        else{
            if (isBlack)
            {
                 x = kingObjects[0].GetComponent<Piece>().x;
                 y = kingObjects[0].GetComponent<Piece>().y;
            }
        
            else
            {
                Debug.Log("Piece: " +kingObjects[1].GetComponent<Piece>().x);
                x = kingObjects[1].GetComponent<Piece>().x;
                y = kingObjects[1].GetComponent<Piece>().y;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////

         double[,] combinations = { { x - 1, y + 2 }, { x + 1, y + 2 }, { x - 2, y + 1 }, { x + 2, y + 1 }, { x - 2, y - 1 }, { x + 2, y - 1 }, 
         { x - 1, y - 2 }, { x + 1, y - 2 } };

         for (int i = 0; i < combinations.GetLength(0); i++)
        {
            foreach (GameObject prefab in piece)
        {
            if (prefab.GetComponent<Knight>() != null){
            Piece script = prefab.GetComponent<Piece>();
            if (p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack)
            {
                if (script.x == combinations[i, 0] && script.y == combinations[i, 1])
                {
                    p.GetComponent<Piece>().x = tempX;
                    p.GetComponent<Piece>().y = tempY;
                    return true;
                }
            }
            }
        }
        }
        ////////////////////////////////////////////////////////////////////////////////////////
        for (double i = x + 1; i < 9; i++){
            foreach (GameObject prefab in piece)
        {
            
            Piece script = prefab.GetComponent<Piece>();
            
            
                if (script.x == i && script.y == y && prefab != p && prefab.GetComponent<King>() != null || script.x == i && script.y == y)
                {
                    if (prefab.GetComponent<Rook>() != null && p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack || prefab.GetComponent<Queen>() 
                    != null && p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack){
                        
                            Debug.Log("Check0");
                            p.GetComponent<Piece>().x = tempX;
                            p.GetComponent<Piece>().y = tempY;
                            return true;
                        
                    }

                    else i = 8;
            
                    
                }
            
            
        }
}
         for (double k = x - 1; k > -2; k--){
            foreach (GameObject prefab in piece)
        {
            
            Piece script = prefab.GetComponent<Piece>();
            
                if (script.x == k && script.y == y && prefab != p && prefab.GetComponent<King>() != null || script.x == k && script.y == y)
                {
                    if (prefab.GetComponent<Rook>() != null && p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack || prefab.GetComponent<Queen>() != null &&
                    p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack){
                        if (p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack ){
                            Debug.Log("Check");
                            p.GetComponent<Piece>().x = tempX;
                            p.GetComponent<Piece>().y = tempY;
                            return true;
                        }
                        
                    }

                    else k = -2;
            
                    
                }
            
            
        }
}
        for (double l = y + 1; l < 8; l++){
            foreach (GameObject prefab in piece)
        {
            Piece script = prefab.GetComponent<Piece>();
            
            
                if (script.x == x && script.y == l && prefab != p && prefab.GetComponent<King>() != null || script.x == x && script.y == l)
                {
                    if (prefab.GetComponent<Rook>() != null && p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack || prefab.GetComponent<Queen>() != null &&
                    p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack ){
                        
                            
                            Debug.Log("Check1");
                            p.GetComponent<Piece>().x = tempX;
                            p.GetComponent<Piece>().y = tempY;
                            return true;
                        
                    }

                    else l = 8;
            
                    
                }
        }
        }

        for (double j = y - 1; j > -1; j--){
            foreach (GameObject prefab in piece)
        {
            Piece script = prefab.GetComponent<Piece>();
            
                if (script.x == x && script.y == j && prefab != p && prefab.GetComponent<King>() != null || script.x == x && script.y == j)
                {
                    Debug.Log("Check2");
                    if (prefab.GetComponent<Rook>() != null && p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack || prefab.GetComponent<Queen>() != null &&
                    p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack ){
                        
                            
                            Debug.Log("Check2");
                            p.GetComponent<Piece>().x = tempX;
                            p.GetComponent<Piece>().y = tempY;
                            return true;
                        
                    }

                    else j = -2;
            
                    
                }
        }
        }
       
   
     ////////////////////////////////////////////////////////////////
     double iy = y + 1;
for (double i = x + 1; i < 9; i++){
    
    Debug.Log(i + " : " + iy + ";");
            foreach (GameObject prefab in piece)
        {
            
            Piece script = prefab.GetComponent<Piece>();
            
            
                if (script.x == i && script.y == iy && prefab != p && prefab.GetComponent<King>() != null || script.x == i && script.y == iy)
                {
                    if (prefab.GetComponent<Bishop>() != null && p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack || prefab.GetComponent<Queen>() 
                    != null && p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack){
                        
                            Debug.Log("Check0");
                            p.GetComponent<Piece>().x = tempX;
                            p.GetComponent<Piece>().y = tempY;
                            return true;
                        
                    }

                    else i = 8;
            
                    
                }
            
            
        }
        iy++;
}
double ky = y - 1;
         for (double k = x - 1; k > -2; k--){
            
            foreach (GameObject prefab in piece)
        {
            
            Piece script = prefab.GetComponent<Piece>();
            
                if (script.x == k && script.y == ky && prefab != p && prefab.GetComponent<King>() != null || script.x == k && script.y == ky)
                {
                    if (prefab.GetComponent<Bishop>() != null && p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack || prefab.GetComponent<Queen>() != null &&
                    p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack){
                        if (p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack ){
                            Debug.Log("Check");
                            p.GetComponent<Piece>().x = tempX;
                            p.GetComponent<Piece>().y = tempY;
                            return true;
                        }
                        
                    }

                    else k = -2;
            
                    
                }
            
            
        }
        ky--;
}
double lx = x - 1;
        for (double l = y + 1; l < 8; l++){
            
            foreach (GameObject prefab in piece)
        {
            Piece script = prefab.GetComponent<Piece>();
            
            
                if (script.x == lx && script.y == l && prefab != p && prefab.GetComponent<King>() != null || script.x == lx && script.y == l)
                {
                    if (prefab.GetComponent<Bishop>() != null && p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack || prefab.GetComponent<Queen>() != null &&
                    p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack ){
                        
                            
                            Debug.Log("Check1");
                            p.GetComponent<Piece>().x = tempX;
                            p.GetComponent<Piece>().y = tempY;
                            return true;
                        
                    }

                    else l = 8;
            
                    
                }
        }
        lx--;
        }
 double jx = x + 1;
        for (double j = y - 1; j > -1; j--){
           
            foreach (GameObject prefab in piece)
        {
            Piece script = prefab.GetComponent<Piece>();
            
                if (script.x == jx && script.y == j && prefab != p && prefab.GetComponent<King>() != null || script.x == jx && script.y == j)
                {
                    Debug.Log("Check2");
                    if (prefab.GetComponent<Bishop>() != null && p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack || prefab.GetComponent<Queen>() != null &&
                    p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack ){
                        
                            
                            Debug.Log("Check2");
                            p.GetComponent<Piece>().x = tempX;
                            p.GetComponent<Piece>().y = tempY;
                            return true;
                        
                    }

                    else j = -2;
            
                    
                }

        }
        jx++;
        }
//////////////////////////////////////////////////////////////////
    if (!p.GetComponent<Piece>().isBlack){
        foreach (GameObject prefab in piece)
        {
            Piece script = prefab.GetComponent<Piece>();
            
            if (prefab.GetComponent<Pawn>() != null && p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack){
                if (script.x == x + 1 || script.x == x - 1){
                    if (script.y == y + 1){
                         p.GetComponent<Piece>().x = tempX;
                            p.GetComponent<Piece>().y = tempY;
                        return true;
                    }
                }
            }
        }
    }

    if (p.GetComponent<Piece>().isBlack){
        foreach (GameObject prefab in piece)
        {
            Piece script = prefab.GetComponent<Piece>();
            if (prefab.GetComponent<Pawn>() != null && p.GetComponent<Piece>().isBlack != prefab.GetComponent<Piece>().isBlack){
                if (script.x == x + 1 || script.x == x - 1){
                    if (script.y == y - 1){
                         p.GetComponent<Piece>().x = tempX;
                            p.GetComponent<Piece>().y = tempY;
                        return true;
                    }
                }
            }
        }
    }
    //////////////////////////////////////////////////
                p.GetComponent<Piece>().x = tempX;
                p.GetComponent<Piece>().y = tempY;
return false;
}
}