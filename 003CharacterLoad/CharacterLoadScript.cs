using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class CharacterLoadScript : MonoBehaviour {
    private GameObject Canvas;
    public GameObject LoadUnit;
    private string[] SaveFiles;
	// Use this for initialization
	void Start () {
        Canvas = GameObject.Find("Canvas");
        SaveFiles = Directory.GetFiles("save");
        for(int i=0;i<SaveFiles.Length; ++i)
        {
            float x = -540.0f;
            float y = 240 - 120*i;
            if(i>2)
            {
                x = 0;
                y += 240;
            }
            GameObject go = Instantiate(LoadUnit, new Vector3(671.5f,296.5f,0) + new Vector3(x,y,0), Quaternion.identity) as GameObject;
            go.transform.parent = Canvas.transform;
            go.SendMessage("ReceiveIndex", i, SendMessageOptions.DontRequireReceiver);
            go.SendMessage("SetContext", SaveFiles[i], SendMessageOptions.DontRequireReceiver);
        }
	}
	void Click(int lindex)
    {
        string name = SaveFiles[lindex];
        name = name.Substring(name.LastIndexOf('\\') + 1, name.LastIndexOf('.') - name.LastIndexOf('\\') - 1);
        WorldVar.player = new Player();
        WorldVar.player.name = name;
        WorldVar.player.Load();
        Application.LoadLevel(WorldVar.player.map);
    }
    void Delete(int lindex)
    {
        string name = SaveFiles[lindex];
        File.Delete(name);
        GameObject[] LoadUnits = GameObject.FindGameObjectsWithTag("LoadUnit");
        foreach(GameObject lu in LoadUnits)
        {
            Destroy(lu);
        }
        Start();
    }
    void Back()
    {
        Application.LoadLevel("000FirstScene");
    }
	// Update is called once per frame
	void Update () {
	
	}
}
