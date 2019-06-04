using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

    BallManager ball;
    PaddleController p1, p2;
	
	void Start ()
    {
        //The only way that I find out to access to the components is by tags or GameObject.Find...
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallManager>();
        p1 = GameObject.FindGameObjectWithTag("Left").GetComponent<PaddleController>();
        p2 = GameObject.FindGameObjectWithTag("Right").GetComponent<PaddleController>();
	}
	
    
	void Update ()
    {
        //Check the Y Axis/ vertical ones
        if (Vertical(ball.transform))
        {
            ball.ChangeY();
        }
        //Check the X axis / horizontal ones
        if (Horizontal(ball.transform))
        {
            if (ball.transform.position.x < 0)
            {
                GameManager.instance.AddPointsToP2();
            }
            else
            {
                GameManager.instance.AddPointsToP1();
            }
            ball.Reset();
            ball.SetSpeed();

        }
        //Check between paddles and ball
        if (AABBCollision(p1.transform, ball.transform)|| AABBCollision(p2.transform, ball.transform))
        {
            ball.ChangeX();
        }
        

    }

    //Bools of positions between the limits of the world or the paddles

    /// <summary>
    /// The collision behind the paddles
    /// </summary>
    /// <param name="t"> ball transform</param>
    /// <returns> if the ball is behind the paddle</returns>

    public bool Horizontal(Transform t)
        {
            if (t.position.x - (t.localScale.x / 2) >= GameManager.ANCHOMUNDO / 2 || t.position.x -( t.localScale.x / 2) <= -GameManager.ANCHOMUNDO / 2)
                return true;
            else
                return false;
        }

    /// <summary>
    /// Check the collision between up and down of the game screen(3 or -3)
    /// </summary>
    /// <param name="t"> transform of the ball</param>
    /// <returns></returns>

    public bool Vertical(Transform t)
    {
        return (t.position.y - t.localScale.y / 2 >= GameManager.ALTOMUNDO / 2 || t.position.y - t.localScale.y / 2 <= -GameManager.ALTOMUNDO / 2); 
    }

    /// <summary>
    /// Check the collisions between a transform A and a transform ball
    /// </summary>
    /// <param name="A"> is the transform of any of the paddles</param>
    /// <param name="Ball"> transform of the ball</param>
    /// <returns></returns>

    public bool AABBCollision(Transform A, Transform Ball)
        {
            return ((Ball.position.x + (Ball.localScale.x / 2)) >= (A.position.x - (A.localScale.x / 2)) &&
                  (Ball.position.x - (Ball.localScale.x / 2)) <= (A.position.x + (A.localScale.x / 2)) &&
                  (Ball.position.y - (Ball.localScale.y / 2)) <= (A.position.y + (A.localScale.y / 2)) &&
                  (Ball.position.y + (Ball.localScale.y / 2)) >= (A.position.y - (A.localScale.y / 2)));

        }
    }

