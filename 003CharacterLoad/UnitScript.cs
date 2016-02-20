using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitScript : MonoBehaviour {
    private GameObject CharacterLoadScript;
    public GameObject StatusTextObject;
    public GameObject NameTextObject;
    private int index = -1;

    void SetContext(string path)
    {
        string name = path;
        name = name.Substring(name.LastIndexOf('\\') + 1, name.LastIndexOf('.') - name.LastIndexOf('\\') - 1);
        Player pl = new Player();
        pl.name = name;
        pl.Load();
        Text StatusText = StatusTextObject.GetComponent<Text>();
        Text NameText = NameTextObject.GetComponent<Text>();
        StatusText.text = "HP : " + pl.hp + '/' + pl.maxhp + "  MP : " + pl.mp + '/' + pl.maxmp + "  Map : " + pl.map.Substring(3);
        NameText.text = name;
    }
    void Click()
    {
        CharacterLoadScript.SendMessage("Click", index, SendMessageOptions.DontRequireReceiver);
    }
	// Use this for initialization
	void Start () {
	    CharacterLoadScript = GameObject.Find("CharacterLoadScript");
	}
	void ReceiveIndex(int lindex)
    {
        index = lindex;
    }
    void Delete()
    {
        CharacterLoadScript.SendMessage("Delete", index, SendMessageOptions.DontRequireReceiver);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
