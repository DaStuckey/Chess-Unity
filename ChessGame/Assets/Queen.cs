using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    Bishop bishop;
    Rook rook;

    private void Awake()
{
    GameObject gameObject = new GameObject("Bishop");
    bishop = gameObject.AddComponent<Bishop>();

    GameObject gameObjects = new GameObject("Rook");
    rook = gameObject.AddComponent<Rook>();
}

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
