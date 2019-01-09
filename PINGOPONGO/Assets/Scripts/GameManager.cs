using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public const int ALTOMUNDO = 6, ANCHOMUNDO = 8;     //CONSTANT (capital letters because the nomenclature)
    
    private enum Estado { Start, Serve, play, Done };
    private enum Player { Left, Right };

    private int p1score, p2score;
    private int inicio = 0;

    private Estado est;
    private Player ServingPlayer;

    private System.Random rnd = new System.Random();

    //BASIC ESTRUCTURE OF A GAMEMANAGER
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    //metodos publicos que devuelven cosas privadas
    void Start()
    {
        
        while (inicio == 0)
        {
            inicio = rnd.Next(-1, 2);
        }
        //decide el jugador

        if (inicio == -1)
        {
            ServingPlayer = Player.Left;
        }
        else if (inicio == 1)
        {
            ServingPlayer = Player.Right;
        }

        p1score = 0;
        p2score = 0;

        est = new Estado();
        est = Estado.Start;
    }

    void Update() {
        //main part of the States Machine

        if (Input.GetKey(KeyCode.Return) && est == Estado.Start) {
            est = Estado.Serve;
        }

        else if (Input.GetKey(KeyCode.Return) && est == Estado.Serve)
        {
            est = Estado.play;
        }
        if(Input.GetKey(KeyCode.Return) && est == Estado.Done) //with this you can replay the game
        {
            est = Estado.Start;
            p1score = 0;
            p2score = 0;
        }

    }

    public void AddPointsToP1()
    {
        p1score++;
        print("P1 points: " + p1score);
        print("P2 points: " + p2score);
        if(ServingPlayer==Player.Right)
            ChangePlayer(ref ServingPlayer);
        if (p1score < 10 && p2score < 10)
        {
            est = Estado.Serve;
        }
        else
        {
            est = Estado.Done;
            p1score = 0;
            p2score = 0;
        }
    }
    public void AddPointsToP2()
    {
        p2score++;

        if (ServingPlayer == Player.Left)
            ChangePlayer(ref ServingPlayer);

        print("P1 points: " + p1score);
        print("P2 points: " + p2score);

        if (p1score < 10 && p2score < 10)
        {
            est = Estado.Serve;
        }
        else
        {
            est = Estado.Done;
            if (p1score == 10)
            {
                print("enhorabuena P1");
            }
            else
            {
                 print("enhorabuena P2");
            }
            
            
        }
    }
    //devuelve que el jugador sea Left o !Left(Right) para que en ballmanager se cambie la velocidad
    public bool LeftPlayer()
    {
        return ServingPlayer == Player.Left;
    }
    //comprueba el estado de juego que sea Play 
    public bool PlayState()
    {
        return est == Estado.play;
    }
    //Los conjuntos de estados ChangeStateTo... cambian el enum referente
    private void ChangePlayer(ref Player p) //pasa por referencia porque no se cambia en ningun metodo tipo update
    {
        if (p == Player.Left)
        {
            p = Player.Right;
        }

       else if (p == Player.Right)
        {
            p = Player.Left;
        }
    }
}
