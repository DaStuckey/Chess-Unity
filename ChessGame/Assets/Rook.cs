using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Rook : MonoBehaviour
{
    public bool hasMoved = false;
    GetPosition get = new GetPosition();
    GetCords cords = new GetCords();
   public bool CanMove(double position, GameObject piece)
    {
        var (x, y) = cords.GetCord(position);
        x = Math.Floor(x);
        y = Math.Floor(y);
        if (piece.GetComponent<Piece>().x == x) // Rook Moves up or down
        {
          
           // Debug.Log("here");
            if (piece.GetComponent<Piece>().y - y > 0) // Checks below
            {
                Debug.Log("hi");
                for (double i = piece.GetComponent<Piece>().y - 1 ; i > y - 1; i--)
                {
                    
                    //Debug.Log(get.isOccupied(x, i, piece) + " : " + i + " : "+ piece.GetComponent<Piece>().x + " : " +piece);
                    var(canMove, oppColor) = get.isOccupied(x, i, piece);
                    
                    if (canMove && oppColor)
                    {
                        if (i == y)
                        {
                            Destroy(get.d.des);
                            return true;
                        }
                        else return false;

                    }
                    if (!canMove)
                    {
                        return false;
                    }
                    else if (i == y)
                    {
                        return true;
                    }
                }
            }
            else if (piece.GetComponent<Piece>().y - y < 0) //Checks above
            {
                for (double i = piece.GetComponent<Piece>().y + 1; i < y + 1; i++)
                {
                    var(canMove, oppColor) = get.isOccupied(x, i, piece);
                    if (canMove && oppColor)
                    {
                        if (i == y)
                        {
                            Destroy(get.d.des);
                            return true;
                        }
                        else return false;

                    }
                    if (!canMove)
                    {
                        return false;
                    }
                     
                    else if (i == y)
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
            // ---------------------------------------------------------------------
        }
        else if (piece.GetComponent<Piece>().y == y) // Rook moves to the left or right
        {
            if (piece.GetComponent<Piece>().x - x > 0) //Checks to the Left
            {
                for (double i = piece.GetComponent<Piece>().x - 1; i > x - 1; i--)
                {
                    Debug.Log(get.isOccupied(x, i, piece) + " : " + i + " : " + y);
                    var (canMove, oppColor) = get.isOccupied(i, y, piece);
                    
                    if (canMove && oppColor)
                    {
                        if (i == x)
                        {
                            Destroy(get.d.des);
                            return true;
                        }
                        else return false;

                    }
                    if (!canMove)
                    {
                        return false;
                    }
                    else if (i == x)
                    {
                        return true;
                    }
                }
            }
            else if (piece.GetComponent<Piece>().x - x < 0) // checks to the right
                // x = 0 2x = 2 y = 1
            {
                for (double i = piece.GetComponent<Piece>().x + 1; i < x + 1; i++)
                {
                    var(canMove, oppColor) = get.isOccupied(i, y, piece);
                    Debug.Log(canMove + " : " + oppColor + " : " + i + " : " + y);
                    if (canMove && oppColor)
                    {
                        if (i == x)
                        {
                            Destroy(get.d.des);
                            return true;
                        }
                        else return false;

                    }
                    if (!canMove)
                    {
                        return false;
                    }
                    else if (i == x)
                    {
                        return true;
                    }
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
