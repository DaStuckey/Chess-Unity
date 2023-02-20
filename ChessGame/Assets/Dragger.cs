using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager {
    public static bool bTurn = false;
}

public class Dragger : MonoBehaviour
{
    //bool bTurn = false;
    CheckOcc get = new CheckOcc();
    public GameObject piece; // This GameObject is used to let me know what Piece I am currently trying to move 
    //Rook rook = new Rook();
    //Queen queen = new Queen();
    bool canMove = false; // These bools help me with my drag and drop 
    bool isDraggable; 
    bool isDragging; 
    Pawn pawn = new Pawn();
    KingCheck c = new KingCheck();
   Piece newPiece = new Piece(); // To help me call my classes 
    
    //Bishop bishop = new Bishop();

    Collider2D objectCollider; 

    public Vector2 position; // This is used to store the last know position so that way if a move is not valid 
    bool worked = false;

    bool SomeMethod(bool changing) {
        // Access and modify the bTurn variable
        bool currentTurn = GameManager.bTurn;
        if(changing){
        GameManager.bTurn = !currentTurn;
        }
        return currentTurn;
    }
    void Start()
    {
        
        objectCollider = GetComponent<Collider2D>();
        isDraggable = false;
        isDragging = false;
        newPiece.SetCords();
        

    }
    
    void Awake()
    {
        position = transform.position; // This sets the position to start
        
    }

    // Update is called once per frame
    void Update()
    {
        DragAndDrop();
    }
   

   
    void DragAndDrop() // This Method creates the drag and drop functinality of my game
    {
        
        worked = false; // this is how I know if my move was legal or if I should send it back to it's default position 
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) //Checks if my mouse button is down pressed and then checks if it is grabbing a draggable object
        {
            if (objectCollider == Physics2D.OverlapPoint(mousePosition))
            {
                Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
                if (targetObject)
                {
                    piece = targetObject.GetComponent<Collider2D>().gameObject;
                    isDraggable = true;
                    
                }
                
            }
            else
            {
                isDraggable = false;
            }

            if (isDraggable)
            {
                isDragging = true;
            }
        }
        if (isDragging)
        {
            this.transform.position = mousePosition; // Sets position to the mouse positoin
            
        }

        if (Input.GetMouseButtonUp(0)) // When I let go of the piece
        {
            
            if (isDragging) //Makes sure I was dragging a piece as to not run the code every time I click my mouse
            {
                
            for (int i = 0; i < GetPosition.prefabPositions.Count; i++) // Checks squares positoin (from my board) 
                {
                    
                    
                        GameObject[] knightInstances = GameObject.FindGameObjectsWithTag("Piece"); // Puts all my pieces into a list


                    Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);// sets a Collider then checks if I am colliding with anything when I let go
                    if (targetObject)
                    {
                        bool changing = false;
                        bool changings = true;
                        
                        if (objectCollider == Physics2D.OverlapPoint(GetPosition.prefabPositions[i]))
                        {
                            Debug.Log(piece.GetComponent<Piece>().isBlack == SomeMethod(changing));
                            if(piece.GetComponent<Piece>().isBlack == SomeMethod(changing)){
                            double b = Convert.ToDouble(i);
                            
                            Knight knightScript = targetObject.GetComponent<Knight>();
                            if (knightScript != null)
                            {
                                canMove = knightScript.CanMove(b, piece);
                            }
                            Rook rookScript = targetObject.GetComponent<Rook>();
                             if (rookScript != null)
                            {
                                canMove = rookScript.CanMove(b, piece);
                                if (canMove)
                                {
                                    Debug.Log("Hiioioioioi");
                                    piece.GetComponent<Rook>().hasMoved = true;
                                }
                            }
                            Pawn pawnScript = targetObject.GetComponent<Pawn>();
                             if (pawnScript != null)
                            {
                                canMove = pawnScript.CanMove(b, piece);
                                
                            }
                            King kingScript = targetObject.GetComponent<King>();
                            if (kingScript != null)
                            {
                                
                                var(canMove, castle) = kingScript.CanMove(b, piece);
                                this.canMove= canMove;  
                                if (canMove)
                                {
                                    piece.GetComponent<King>().hasMoved = true;
                                }
                                else if (castle)
                                {
                                    
                                    piece = null;
                                    position = transform.position;
                                    isDraggable = false;
                                    isDragging = false;
                                    worked = true;
                                    break;
                                }
                            } 
                            Queen queenScript = targetObject.GetComponent<Queen>();
                            if (queenScript != null)
                            {
                                canMove = queenScript.CanMove(b, piece);
                            }
                            Bishop bishopScript = targetObject.GetComponent<Bishop>();
                            if (bishopScript != null)
                            {
                                canMove = bishopScript.CanMove(b, piece);
                            }
                            if (canMove)
                            {
                                bool l = SomeMethod(changings);
                                newPiece.SetInfo(b, piece);
                                piece = null;
                                Vector2 dropPosition = GetPosition.prefabPositions[i];
                                isDraggable = false;
                                isDragging = false;
                                //Debug.Log(i);
                                this.transform.position = dropPosition;
                                position = transform.position;
                                worked = true;
                               
                                
                                
                            

                            }
                            }
                        }

                    }

                    
                }
            }
            if(!worked) 
            {
                isDraggable = false;
                isDragging = false;
                
                this.transform.position = position;
                position = transform.position;
                piece = null;
            }
            
        }
    }
}
