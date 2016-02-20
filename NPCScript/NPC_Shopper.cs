using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class NPC_Shopper : MonoBehaviour {
    static public int menuNum = 2;
    public Vector2 scrollPosition = Vector2.zero;
    public string ItemlistPath;
    private List<Item> itemList;
    private int itemFocus = -1;
    private string itemExplain = "";
    private bool isPlayerIn = false;
    private bool[] bMenu;
    void LoadItemlist()
    {
        itemList.Clear();
        if (File.Exists(ItemlistPath))
        {
            print("Loaded : " + ItemlistPath);
            StreamReader sr = new StreamReader(new FileStream(ItemlistPath, FileMode.Open, FileAccess.Read), Encoding.UTF8);
            XmlSerializer xs = new XmlSerializer(itemList.GetType());
            itemList = (List<Item>)xs.Deserialize(sr);
            sr.Close();
            print(itemList.ToString());
        }
        else {
            print("There isn't file : " + ItemlistPath);
        }
    }
	void Start () {
        bMenu = new bool[menuNum];
        for (int i = 0; i < menuNum; ++i)
        {
            bMenu[i] = false;
        }
        itemList = new List<Item>();
        LoadItemlist();
	}
    void CloseAll()
    {
        for(int i=0;i<menuNum; ++i)
        {
            bMenu[i] = false;
        }
    }	
	void Update () {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            scrollPosition.y += 3;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            scrollPosition.y -= 3;
        }
	}
    void OnGUI()
    {
        if(isPlayerIn)
        {
            GUI.Box(new Rect(10, 100, 200, 150), "NPC Shopper");
            if (GUI.Button(new Rect(20, 130, 180, 50), "Buy"))
            {
                CloseAll();
                bMenu[0] = true;
            }
            if(GUI.Button(new Rect(20, 190, 180, 50), "Sell"))
            {
                CloseAll();
                bMenu[1] = true;
            }
            if (bMenu[0]) // Buy GUI
            {
                GUI.Box(new Rect(220, 100, 200, 200), "List");
                scrollPosition = GUI.BeginScrollView(new Rect(220, 100, 200, 200), scrollPosition, new Rect(0, 0, 200, 400));
                for (int i = 0; i < itemList.Count; ++i)
                {
                    if(GUI.Button(new Rect(0,i*50,200,50), itemList[i].name+" : "+itemList[i].cost.ToString()))
                    {
                        itemFocus = i;
                        itemExplain = itemList[i].Explain();
                    }
                }
                GUI.EndScrollView();
            }
            else if (bMenu[1]) // Sell GUI
            {

            }

            if(itemFocus != -1)
            {
                GUI.Box(new Rect(420, 100, 200, 200), "Property");
                GUI.TextArea(new Rect(420, 100, 200, 170), itemExplain);
                if(GUI.Button(new Rect(420, 270, 100, 30), "Buy"))
                {

                }
                if (GUI.Button(new Rect(520, 270, 100, 30),"Exit"))
                {
                    itemFocus = -1;
                }
            }
        }
    }    
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        { isPlayerIn = true; }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        { isPlayerIn = false; }
    }
}
