using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class King : MonoBehaviour
{
    KingCheck kings = new KingCheck();
    public int checkCounter = 0;
    Knight knight = new Knight();
    CheckOcc get = new CheckOcc();
    GetCords cords = new GetCords();
    Piece cordss = new Piece();
    public GameObject[] squared;
    
   
    public King()
    {
        squared = cordss.square;
    }

    public bool hasMoved = false;
    public (bool, bool) CanMove(double position, GameObject piece)
    {
        //Vector2 positionsd = piece.transform.position;
        
        
        var (x, y) = cords.GetCord(position);
        x = Math.Floor(x);
        y = Math.Floor(y);
        //Debug.Log(Math.Abs(piece.GetComponent<Piece>().x - x));
        
            if (Math.Abs(piece.GetComponent<Piece>().x - x) <= 1 && Math.Abs(piece.GetComponent<Piece>().y - y) <= 1 )// Checks if it is a legal normal move 
            {

                Debug.Log(" ");
                var (canMove, oppColor) = get.isOccupied(x, y, piece);
                if (canMove && oppColor)
                {
                    
                    double tx = get.d.des.GetComponent<Piece>().x;
                    double ty = get.d.des.GetComponent<Piece>().y;
                    get.d.des.GetComponent<Piece>().x = -1;
                    get.d.des.GetComponent<Piece>().y = -1;
                    if (!kings.inCheck(x, y, piece)){
                         Destroy(get.d.des);
                         return (true, false);
                    }
                    else{
                        get.d.des.GetComponent<Piece>().x = tx;
                        get.d.des.GetComponent<Piece>().y = ty;
                         return (false, false);
                    }
                }
                else if (canMove && !kings.inCheck(x, y, piece))
                {
                   
                    return (true, false);
                }

            }
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
           
        
        return (false, false);
    }
   /* public bool inChecks(GameObject piece)
    {
        piece.GetComponent<King>().checkCounter = 1;
        double x = piece.GetComponent<Piece>().x;
        double y = piece.GetComponent<Piece>().y;
        double[,] combinations = { { x - 1, y + 2 }, { x + 1, y + 2 }, { x - 2, y + 1 }, { x + 2, y + 1 }, { x - 2, y - 1 }, { x + 2, y - 1 }, { x - 1, y - 2 }, { x + 1, y - 2 } };
        
        for (int i = 0; i < combinations.GetLength(0); i++)
        {
            var (c, g) = get.isOccupied(combinations[i, 0], combinations[i, 1], piece);
            Debug.Log(c + " : " + g);
            if (!c)
            {
                Debug.Log("222222222222222222" + i);
                piece.GetComponent<King>().checkCounter = 0;
                return true;
            }
        }

        piece.GetComponent<King>().checkCounter = 0;
        return false;
    }*/
}
