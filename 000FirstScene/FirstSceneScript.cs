using UnityEngine;
using System.Collections;

public class FirstSceneScript : MonoBehaviour {

    void StartClick()
    {
        Application.LoadLevel("002CharacterCreate");
    }
    void LoadClick()
    {
        Application.LoadLevel("003CharacterLoad");
    }
    void ExitClick()
    {
        Application.Quit();
    }
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
