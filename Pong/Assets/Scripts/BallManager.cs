using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    public float min = 1.5f, max = 3f;

    private Vector3 size;
    private float DeltaX = 0, DeltaY = 0;

    void Start ()
    {
        size = this.transform.localScale;

        SetSpeed(); 

	}
    //Set speed between min & max or -max & max

    public void SetSpeed()
    {
        DeltaX = Random.Range(min, max);

        DeltaY = Random.Range(-max, max);

        if (GameManager.instance.LeftPlayer()) //check which player is
        {
            DeltaX = -DeltaX; 
    
        }
      

    }

    void FixedUpdate () {
       
        if ( GameManager.instance.PlayState())
        {
            transform.Translate(new Vector2(DeltaX, DeltaY) * Time.deltaTime);
        }
    }

    //Change X component
    public void ChangeX()
    {
        Transform t = this.transform;
        DeltaX = -DeltaX;
        if (this.transform.position.x < 0)
        {
            transform.position = t.position + new Vector3(size.x / 2, 0, 0);
        }
        else
        {
            transform.position = t.position - new Vector3(size.x / 2, 0, 0);
        }
    }

    //Change Y component
    public void ChangeY()
    {
        DeltaY = -DeltaY;
        Transform t = this.transform;

        if (this.transform.position.y < 0)
        {
            transform.position = t.position + new Vector3(0, size.y/2, 0);
        }
        else
        {
            transform.position = t.position - new Vector3(0, size.y / 2, 0);
        }
    }
    //Move the ball in her initial position (0,0,0)
    public void Reset()
    {
        DeltaX = 0;
        DeltaY = 0;
        transform.position = new Vector3(0, 0, 0);
        
    }

}