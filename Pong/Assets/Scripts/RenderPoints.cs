using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderPoints : MonoBehaviour {
    
    public Text p1,p2;
	// Use this for initialization
	void Start () {
        p1.text = " ";
        p2.text = " ";
	}
	
	// Update is called once per frame
	void Update () {
        p1.text = GameManager.instance.p1score.ToString();
        p2.text= GameManager.instance.p2score.ToString();
    }
}
