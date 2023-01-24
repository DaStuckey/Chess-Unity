using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bishop : MonoBehaviour
{
    GetPosition get = new GetPosition();
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
                            Destroy(get.d.des);
                            return true;
                        }
                        else return false;

                    }
                    else if (!canMove)
                    {
                        return false;
                    }
                   if (i == x)
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
                            Destroy(get.d.des);
                            return true;
                        }
                        else return false;

                    }
                    else if (!canMove)
                    {
                        return false;
                    }
                    else if (i == x)
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
                            Destroy(get.d.des);
                            return true;
                        }
                        else return false;

                    }
                    else if (!canMove)
                    {
                        return false;
                    }
                    else if (i == x)
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
                            Destroy(get.d.des);
                            return true;
                        }
                        else return false;

                    }
                    else if (!canMove)
                    {
                        return false;
                    }
                    else if (i == x)
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

