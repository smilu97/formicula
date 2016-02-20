using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class InGameUI2 : MonoBehaviour {
    public Slider HealthBar;
    public Slider ManaBar;
    public Text HealthText;
    public Text ManaText;

    private bool isMenuOn = false;    
    public Rect MenuRect = new Rect(0, 70, 100, 100);

    private bool isInvenOn = false;
    public Rect InvenRect = new Rect(100, 70, 600, 300);
    private int invenMenunum = 0;
    private Vector2 itemScrollPos = Vector2.zero;
    private List<Item>[] itemLists;
    private Item FocusItem;
    private string invenExplain = "";

    private bool isEquipOn = false;
    public Rect EquipRect = new Rect(100, 370, 600, 210);
    private string equipExplain = "";

    // Use this for initialization
    void Start () {
        itemLists = new List<Item>[Item.TypeNameDic.Count];
        UpdateItemlists(0);
        WorldVar.cursorShow = false;
        Cursor.visible = false;
        equipExplain = WorldVar.player.equipBonus.ExplainBonus();
        print("A");
	}
	void UpdateItemlists(int t)
    {
        itemLists[t] = WorldVar.player.inven.GetTypeList(t);
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOn = !isMenuOn;
            WorldVar.cursorShow = !(WorldVar.cursorShow);
            Cursor.visible = !(Cursor.visible);
        }
        // Bar Update
        HealthBar.value = WorldVar.player.hp * 100 / WorldVar.player.maxhp;
        HealthText.text = WorldVar.player.hp.ToString() + '/' + WorldVar.player.maxhp.ToString();
        ManaBar.value = WorldVar.player.mp * 100 / WorldVar.player.maxmp;
        ManaText.text = WorldVar.player.mp.ToString() + '/' + WorldVar.player.maxmp.ToString();
        //
    }

    void OnGUI()
    {
        if (isMenuOn)
        {
            MenuRect = GUI.Window(0, MenuRect, MenuFunc, "Menu");
            if (isInvenOn)
            {
                InvenRect = GUI.Window(1, InvenRect, InvenFunc, "Inventory");
            }
            if (isEquipOn)
            {
                EquipRect = GUI.Window(2, EquipRect, EquipFunc, "Equipment");
            }
        }
    }
    void MenuFunc(int winID)
    {
        if(GUI.Button(new Rect(0, 0, 100, 30), "Inventory"))
        {
            isInvenOn = !isInvenOn;
        }
        if(GUI.Button(new Rect(0, 30, 100, 30), "Equipment"))
        {
            isEquipOn = !isEquipOn;
        }
        GUI.DragWindow();
    }
    void InvenFunc(int winID)
    {
        int typenum = Item.TypeNameDic.Count;
        for(int i=0;i<typenum; ++i)
        {
            if(GUI.Button(new Rect(150*(i%2), 30*(i/2+1), 150, 30), Item.TypeNameDic[i]))
            {
                invenMenunum = i;
                UpdateItemlists(i);
            }
        }
        int ay = 30 * (typenum / 2 + 1);
        itemScrollPos = GUI.BeginScrollView(new Rect(0, ay, 300, 300 - ay), itemScrollPos, new Rect(0, 0, 300, 30 * ((itemLists[invenMenunum].Count+1) / 2 + 1)));
        for(int i=0;i<itemLists[invenMenunum].Count;++i)
        {
            if(GUI.Button(new Rect(150 * (i % 2), 30 * (i / 2 + 1), 150, 30), itemLists[invenMenunum][i].name))
            {
                FocusItem = itemLists[invenMenunum][i];
                invenExplain = FocusItem.Explain();
            }
        }        
        GUI.EndScrollView();        
        if(FocusItem != null)
        {            
            GUI.TextArea(new Rect(300, 30, 300, 240), invenExplain);
            if (FocusItem.type == 1 || FocusItem.type == 2) // Weapon or Armor
            {
                if (GUI.Button(new Rect(300, 270, 150, 30), "Equip"))
                {
                    int ioi = WorldVar.player.inven.GetIndexofItem(FocusItem);
                    if (ioi == -1)
                    {

                    }
                    else
                    {
                        WorldVar.player.equip[FocusItem.armortype] = ioi;
                        WorldVar.player.updateEquipBonus();
                        equipExplain = WorldVar.player.equipBonus.ExplainBonus();
                    }
                }
            }
            if (FocusItem.type == 3) // Consumable
            {
                if (GUI.Button(new Rect(300, 270, 150, 30), "Use"))
                {
                    int ioi = WorldVar.player.inven.GetIndexofItem(FocusItem);
                    if (ioi == -1)
                    {

                    }
                    else
                    {
                        // TODO:Item Using
                        WorldVar.player.AddHP(FocusItem.hp);
                        WorldVar.player.AddMP(FocusItem.mp);
                        WorldVar.player.inven.items[ioi] = null;
                        FocusItem = null;
                        // invenExplain = "";
                        UpdateItemlists(Item.NameTypeDic["Consumable"]);
                    }
                }
            }
        }        
        GUI.DragWindow();
    } // 600 x 300
    void EquipFunc(int winID) // 300 x 150
    {
        string str = "";
        int[] eq = WorldVar.player.equip;
        for(int i=0;i<6; ++i)
        {
            str = Item.ArmorTypeNameDic[i] + " : ";
            if(eq[i] == -1)
            {
                str += "None\n";
            }
            else
            {
                str += WorldVar.player.inven.items[eq[i]].name;                
            }
            GUI.TextArea(new Rect(0, 30+30 * i, 250, 30), str);
            if (GUI.Button(new Rect(250, 30+30 * i, 80, 30), "Unequip"))
            {
                eq[i] = -1;
                WorldVar.player.updateEquipBonus();
                equipExplain = WorldVar.player.equipBonus.ExplainBonus();
            }
        }
        GUI.TextArea(new Rect(330, 30, 270, 180), equipExplain);
        GUI.DragWindow();
    }
}
