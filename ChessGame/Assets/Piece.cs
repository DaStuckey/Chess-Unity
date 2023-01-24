using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Piece : MonoBehaviour
{
    GetCords cords = new GetCords();
    public bool isBlack;

    public double x, y;
    public GameObject[] square;
    public bool SetInfo(double position, GameObject piece) // Updates the cords of the piece that just moved
    {
        var (a, b) = cords.GetCord(position);
        piece.GetComponent<Piece>().x = Math.Floor(a);
        piece.GetComponent<Piece>().y = Math.Floor(b);


        return true;
    }
    public void SetCords()
    {
        GameObject[] squares = GameObject.FindGameObjectsWithTag("Square");
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("Piece");
        this.square = squares;
        foreach (GameObject square in squares)
        {
            foreach (GameObject piece in pieces)
            {
                
                if (Vector2.Distance(piece.transform.position, square.transform.position) < 0.2f)
                {
                    
                    Piece knightScript = piece.GetComponent<Piece>();
                    if (knightScript != null)
                    {
                        knightScript.x = square.GetComponent<GetPosition>().x;
                        knightScript.y = square.GetComponent<GetPosition>().y;
                    }

                }
            }
        }
    }

   
}
