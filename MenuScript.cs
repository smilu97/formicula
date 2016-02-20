using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Back()
    {
        WorldVar.player.Save();
        Application.LoadLevel("000FirstScene");
    }    
}
