using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class CharacterCreator : MonoBehaviour {
    private Text NameText;
    private Text SystemText;
    private float SystemMessageTimeCounter = 0;
	// Use this for initialization
    void Submit()
    {
        string name = NameText.text;
        if(File.Exists("save/" + name + ".sav") || name.Equals("")) // If already there is the character having same name || name is ""
        {
            SystemText.text = "Unproper Name!!";
            SystemMessageTimeCounter = 3;
        }
        else // name is OK
        {
            WorldVar.player = new Player();
            WorldVar.player.name = name;
            WorldVar.player.map = WorldVar.FirstMap;
            WorldVar.player.Save();
            Application.LoadLevel(WorldVar.player.map);
        }        
    }
    void Back()
    {
        Application.LoadLevel("000FirstScene");
    }
	void Start () {
        NameText = GameObject.Find("NameInputText").GetComponent<Text>();
        SystemText = GameObject.Find("SystemText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(SystemMessageTimeCounter > 0)
        {
            SystemMessageTimeCounter -= Time.deltaTime;
        }
        else
        {
            SystemText.text = "";
        }
	}
}
