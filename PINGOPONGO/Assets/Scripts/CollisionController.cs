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

        if (Vertical(ball.transform))
        {
            ball.ChangeY();
        }
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
        if (AABBCollision(p1.transform, ball.transform)|| AABBCollision(p2.transform, ball.transform))
        {
            ball.ChangeX();
        }
        

    }
   
   //Bools of positions between the limits of the world or the paddles

        //if the cllision is on the left or right
        public bool Horizontal(Transform t)
        {
            if (t.position.x - (t.localScale.x / 2) >= GameManager.ANCHOMUNDO / 2 || t.position.x -( t.localScale.x / 2) <= -GameManager.ANCHOMUNDO / 2)
                return true;
            else
                return false;
        }
    
    // if is up or down
        public bool Vertical(Transform t)
        {
            return (t.position.y - t.localScale.y / 2 >= GameManager.ALTOMUNDO / 2 || t.position.y - t.localScale.y / 2 <= -GameManager.ALTOMUNDO / 2); //me limito a de -AltoMundo a Altomundo-->(-3,3)
        }
    
    //between the paddles
        public bool AABBCollision(Transform A, Transform Ball)
        {
            return ((Ball.position.x + (Ball.localScale.x / 2)) >= (A.position.x - (A.localScale.x / 2)) &&
                  (Ball.position.x - (Ball.localScale.x / 2)) <= (A.position.x + (A.localScale.x / 2)) &&
                  (Ball.position.y - (Ball.localScale.y / 2)) <= (A.position.y + (A.localScale.y / 2)) &&
                  (Ball.position.y + (Ball.localScale.y / 2)) >= (A.position.y - (A.localScale.y / 2)));

        }
    }

