using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardColor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public bool isBlack;
    Color customColor = new Color(0.9333334f, 0.9333334f, 0.8352942f, 1f);
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Renderer>().material.color = customColor;
        if (!isBlack)
        {
           // spriteRenderer.color = customColor;
        }





    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
