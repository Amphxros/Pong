using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {


    public KeyCode up, down; 
    private float speed = 333f;

    private Vector3 size;
   //Get the size to the scale of the GO
    void Start()
    {
        size = transform.localScale;
    }

    //the movement is limited by the const of the GM "ALTOMUNDO"/2 and the component y of the size/2
    void Update()
    {
        
        if ((transform.position.y + (size.y / 2) < GameManager.ALTOMUNDO / 2))
        {
            if (Input.GetKey(up))
            {
                transform.Translate(0, speed* Time.deltaTime, 0);

            }
        }

        if (transform.position.y - (size.y / 2) > -GameManager.ALTOMUNDO / 2)
        {
            if (Input.GetKey(down))
            {

                transform.Translate(0, -speed*Time.deltaTime, 0);

            }

        }
    }
}

