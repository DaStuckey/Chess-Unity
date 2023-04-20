using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class King : MonoBehaviour
{
    
    
    KingCheck kings = new KingCheck();
    Castling castle = new Castling();
    public int checkCounter = 0;
    //Knight knight = new Knight();
    CheckOcc get = new CheckOcc();
    GetCords cords = new GetCords();
    Piece cordss;
    public GameObject[] squared;
    
   private void Awake(){
    
    GameObject gameObject = new GameObject("Piece");
    cordss = gameObject.AddComponent<Piece>();
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
            if (piece.GetComponent<Piece>().isBlack && x == 6 && y == 7 || piece.GetComponent<Piece>().isBlack && x == 2 && y == 7 
                || !piece.GetComponent<Piece>().isBlack && x == 6 && y == 0 || !piece.GetComponent<Piece>().isBlack && x == 2 && y == 0 ){
                    castle.CanCastle(x, y, piece);
                }
            
           
        
        return (false, false);
    }
   
}
