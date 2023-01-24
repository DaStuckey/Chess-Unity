using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    Bishop bishop = new Bishop();
    Rook rook = new Rook();
    public bool CanMove(double position, GameObject piece)
    {
        if (rook.CanMove(position, piece))
        {
            return true;
        }
        else if (bishop.CanMove(position, piece))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
