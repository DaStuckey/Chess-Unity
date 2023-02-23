using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bishop : MonoBehaviour
{
    CheckOcc get = new CheckOcc();
    KingCheck kings = new KingCheck();
    GetCords cords = new GetCords(); 

   
    public bool CanMove(double position, GameObject piece)
    {
        
        var (x, y) = cords.GetCord(position);
        x = Math.Floor(x);
        y = Math.Floor(y);
        if (Math.Abs(piece.GetComponent<Piece>().x - x) == Math.Abs(piece.GetComponent<Piece>().y - y)) //Checks if move is a diagnal 
        {
            
            if (piece.GetComponent<Piece>().x < x && piece.GetComponent<Piece>().y < y)// Checks Upper Right
             {
                
                double e = piece.GetComponent<Piece>().y + 1;


                for(double i = piece.GetComponent<Piece>().x + 1; i < x + 1; i++)
                {
                    
                    var (canMove, oppColor) = get.isOccupied(i, e, piece);
                    if (canMove && oppColor)
                    {
                        if (i == x)
                        {
                            double tx = get.d.des.GetComponent<Piece>().x;
                double ty = get.d.des.GetComponent<Piece>().y;
                get.d.des.GetComponent<Piece>().x = -1;
                get.d.des.GetComponent<Piece>().y = -1;
                if (!kings.inCheck(i, e, piece)){
                    Destroy(get.d.des);
                    return true; // Returns false because that means it can't move
                }
                else{
                    get.d.des.GetComponent<Piece>().x = tx;
                    get.d.des.GetComponent<Piece>().y = ty;
                    
                    return false;
                }
                        }
                        else return false;

                    }
                    else if (!canMove)
                    {
                        return false;
                    }
                   if (i == x && !kings.inCheck(i, e, piece))
                    {
                        return true;
                    }
                    e++;
                }


             }
            else if (piece.GetComponent<Piece>().x > x && piece.GetComponent<Piece>().y < y)// Checks Upper Left
            { // (()4,()3) --> (x2,y5)
                double e = piece.GetComponent<Piece>().y + 1;
                for (double i = piece.GetComponent<Piece>().x - 1; i > x - 1; i--)
                {
                    
                    var (canMove, oppColor) = get.isOccupied(i, e, piece);
                    if (canMove && oppColor)
                    {
                        if (i == x)
                        {
                            double tx = get.d.des.GetComponent<Piece>().x;
                double ty = get.d.des.GetComponent<Piece>().y;
                get.d.des.GetComponent<Piece>().x = -1;
                get.d.des.GetComponent<Piece>().y = -1;
                if (!kings.inCheck(i, e, piece)){
                    Destroy(get.d.des);
                    return true; // Returns false because that means it can't move
                }
                else{
                    get.d.des.GetComponent<Piece>().x = tx;
                    get.d.des.GetComponent<Piece>().y = ty;
                    
                    return false;
                }
                        }
                        else return false;

                    }
                    else if (!canMove)
                    {
                        return false;
                    }
                    else if (i == x && !kings.inCheck(i, e, piece))
                    {
                        return true;
                    }
                    e++;
                }

            }
            else if (piece.GetComponent<Piece>().x > x && piece.GetComponent<Piece>().y > y)// Checks Bottom Left
            {
                double e = piece.GetComponent<Piece>().y - 1;
                for (double i = piece.GetComponent<Piece>().x - 1; i > x - 1; i--)
                {
                    var (canMove, oppColor) = get.isOccupied(i, e, piece);
                    if (canMove && oppColor)
                    {
                        if (i == x)
                        {
                            double tx = get.d.des.GetComponent<Piece>().x;
                double ty = get.d.des.GetComponent<Piece>().y;
                get.d.des.GetComponent<Piece>().x = -1;
                get.d.des.GetComponent<Piece>().y = -1;
                if (!kings.inCheck(i, e, piece)){
                    Destroy(get.d.des);
                    return true; // Returns false because that means it can't move
                }
                else{
                    get.d.des.GetComponent<Piece>().x = tx;
                    get.d.des.GetComponent<Piece>().y = ty;
                    
                    return false;
                }
                        }
                        else return false;

                    }
                    else if (!canMove)
                    {
                        return false;
                    }
                    else if (i == x && !kings.inCheck(i, e, piece))
                    {
                        return true;
                    }
                    e--;
                }
            }
            else if (piece.GetComponent<Piece>().x < x && piece.GetComponent<Piece>().y > y)// Checks Bottom Right
            {
                Debug.Log("Hi");
                double e = piece.GetComponent<Piece>().y - 1;
                // x(3) y(3) x.4 y.2
                for (double i = piece.GetComponent<Piece>().x + 1; i < x + 1; i++)
                {
                    Debug.Log(get.isOccupied(i, e, piece) + " : " + i + " : " + e);
                    var (canMove, oppColor) = get.isOccupied(i, e, piece);
                    if (canMove && oppColor)
                    {
                        if (i == x)
                        {
                             double tx = get.d.des.GetComponent<Piece>().x;
                double ty = get.d.des.GetComponent<Piece>().y;
                get.d.des.GetComponent<Piece>().x = -1;
                get.d.des.GetComponent<Piece>().y = -1;
                if (!kings.inCheck(i, e, piece)){
                    Destroy(get.d.des);
                    return true; // Returns false because that means it can't move
                }
                else{
                    get.d.des.GetComponent<Piece>().x = tx;
                    get.d.des.GetComponent<Piece>().y = ty;
                    
                    return false;
                }
                        }
                        else return false;

                    }
                    else if (!canMove)
                    {
                        return false;
                    }
                    else if (i == x && !kings.inCheck(i, e, piece))
                    {
                        return true;
                    }
                    e--;
                }
                
            }
            else
            {
                return false;
            }
        }
        
            return false;
        
    }
}

