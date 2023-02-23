using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Pawn : MonoBehaviour
{
    CheckOcc get = new CheckOcc();
    GetCords cords = new GetCords();
    KingCheck kings = new KingCheck();
    
    public bool CanMove(double position, GameObject piece) // This method checks if the move a knight is trying to make is a legal move
    {
        Debug.Log("1");
        var (a, b) = cords.GetCord(position); // Sets the number of the square I am going to into cords
        
        Debug.Log("howdy");
        double x = Math.Floor(a); //Rounds it down to avoid errors 
        double y = Math.Floor(b);

        if (piece.GetComponent<Piece>().isBlack){
            if (x == piece.GetComponent<Piece>().x && y == piece.GetComponent<Piece>().y - 1){
                var(canMove, oppColor) = get.isOccupied(x, y, piece);
                if (oppColor){
                    return false;
                }
                if(canMove && !kings.inCheck(x, y, piece)){
                    return true;
                }
            }
            if (x == piece.GetComponent<Piece>().x && y == piece.GetComponent<Piece>().y - 2 && piece.GetComponent<Piece>().y == 6){
                var(canMove, oppColor) = get.isOccupied(x, y, piece);
                if (oppColor){
                    return false;
                }
                if(canMove && !kings.inCheck(x, y, piece)){
                    return true;
                }
            }
            if (x == piece.GetComponent<Piece>().x + 1 || x == piece.GetComponent<Piece>().x - 1){
                if (y == piece.GetComponent<Piece>().y - 1){
                    var(canMove, oppColor) = get.isOccupied(x, y, piece);
                if (canMove && oppColor ){
                    double tx = get.d.des.GetComponent<Piece>().x;
                double ty = get.d.des.GetComponent<Piece>().y;
                get.d.des.GetComponent<Piece>().x = -1;
                get.d.des.GetComponent<Piece>().y = -1;
                if (!kings.inCheck(x, y, piece)){
                    Destroy(get.d.des);
                    return true; // Returns false because that means it can't move
                }
                else{
                    get.d.des.GetComponent<Piece>().x = tx;
                    get.d.des.GetComponent<Piece>().y = ty;
                    
                    return false;
                }
                }
                
                }
            }
}
            if (!piece.GetComponent<Piece>().isBlack){
                Debug.Log("2");
                Debug.Log(x == piece.GetComponent<Piece>().x && y == piece.GetComponent<Piece>().y + 1);
                Debug.Log(x + " = " + piece.GetComponent<Piece>().x + " and " +  y + " = " + piece.GetComponent<Piece>().y);
            if (x == piece.GetComponent<Piece>().x && y == piece.GetComponent<Piece>().y + 1){
                Debug.Log("4");
                var(canMove, oppColor) = get.isOccupied(x, y, piece);
                if (oppColor){
                    return false;
                }
                if(canMove && !kings.inCheck(x, y, piece)){
                    Debug.Log("howdy2");
                    return true;
                }
            }
            if (x == piece.GetComponent<Piece>().x && y == piece.GetComponent<Piece>().y + 2 && piece.GetComponent<Piece>().y == 1){
                var(canMove, oppColor) = get.isOccupied(x, y, piece);
                if (oppColor){
                    return false;
                }
                if(canMove && !kings.inCheck(x, y, piece)){
                    return true;
                }
            }

            if (x == piece.GetComponent<Piece>().x + 1 || x == piece.GetComponent<Piece>().x - 1){
                if (y == piece.GetComponent<Piece>().y + 1){
                    var(canMove, oppColor) = get.isOccupied(x, y, piece);
                if (canMove && oppColor){
                    double tx = get.d.des.GetComponent<Piece>().x;
                double ty = get.d.des.GetComponent<Piece>().y;
                get.d.des.GetComponent<Piece>().x = -1;
                get.d.des.GetComponent<Piece>().y = -1;
                if (!kings.inCheck(x, y, piece)){
                    Destroy(get.d.des);
                    return true; // Returns false because that means it can't move
                }
                else{
                    get.d.des.GetComponent<Piece>().x = tx;
                    get.d.des.GetComponent<Piece>().y = ty;
                    
                    return false;
                }
                }
                
                }
            }
        }
    
    return false;
}
}