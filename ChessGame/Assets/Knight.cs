using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Knight : MonoBehaviour
{

    GetPosition get = new GetPosition();
    GetCords cords = new GetCords();




    public bool CanMove(double position, GameObject piece) // This method checks if the move a knight is trying to make is a legal move
    {

        var (a, b) = cords.GetCord(position); // Sets the number of the square I am going to into cords

        double c = Math.Floor(a); //Rounds it down to avoid errors 
        double d = Math.Floor(b);

        if ((Math.Abs(Math.Floor(a) - piece.GetComponent<Piece>().x) == 1 || Math.Abs(Math.Floor(a) - piece.GetComponent<Piece>().x) == 2) && (Math.Abs(Math.Floor(b) - piece.GetComponent<Piece>().y) ==
            1 || Math.Abs(Math.Floor(b) - piece.GetComponent<Piece>().y) == 2) && (Math.Abs(Math.Floor(a) - piece.GetComponent<Piece>().x) != Math.Abs(Math.Floor(b) - piece.GetComponent<Piece>().y)))
        // Uses the X and Y value of the piece I am currently holding and checks it with the place I am trying to go and continues if it is valid 
        {
            var (canMove, onePiece) = get.isOccupied(c, d, piece);
            if (canMove && onePiece) //Checks to see if the square if occipied with a same colored piece
            {
                Destroy(get.d.des);
                return true; // Returns false because that means it can't move
            }
            else if (canMove)
            {
                return true; // Returns True because it is a legal move!
            }
            else  {
                return false;
            }

        }


        else return false;
    }
}