using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castling : MonoBehaviour
{
    Rook rook;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject gameObjects = new GameObject("Rook");
        rook = gameObject.AddComponent<Rook>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CanCastle (double a, double b, GameObject piece){
        Debug.Log("Ping");
        //if (position)
            // if (!piece.GetComponent<King>().hasMoved)
            // {
            //     GameObject[] pieces = GameObject.FindGameObjectsWithTag("Piece"); //GameObject piecer in pieces

            //     for (int i = 0; i < pieces.Length; i++)
            //     {
            //         if (!pieces[i].GetComponent<Rook>().hasMoved)
            //         {
            //             if (piece.GetComponent<Piece>().x == 4 && piece.GetComponent<Piece>().y == 7)
            //             {
            //                 if (pieces[i].GetComponent<Rook>() != null && pieces[i].GetComponent<Piece>().isBlack)
            //                 {
            //                     if (pieces[i].GetComponent<Piece>().x == 7 && pieces[i].GetComponent<Piece>().y == 7)
            //                     {
            //                         GameObject temp = pieces[i];
            //                         Debug.Log("Workesdfsdfsdfsfsddfsd");
            //                         Debug.Log(pieces[i].GetComponent<Rook>() != null);
            //                         Vector2 p = new Vector2(3.4f, -0.39f);
            //                         Vector2 p1 = new Vector2(4f, -0.39f);
            //                         temp.GetComponent<Piece>().isBlack = false;
            //                         temp.transform.position = p;
            //                         piece.transform.position = p1;
            //                         cordss.SetCords();
            //                         temp.GetComponent<Dragger>().position = p;
            //                         temp = null;
            //                         return (false, true);
            //                     }

            //                 }
            //             }
            //         }
            //     }

            // }
        return false;
    }
}
