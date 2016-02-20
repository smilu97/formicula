using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class DebugInvenMenuScript : MonoBehaviour {
    public GameObject InvenMenu;
    public InputField nameField;
    public InputField costField;
    public InputField hpField;
    public InputField mpField;
    public InputField typeField;
    public InputField attackspeedField;
    public InputField jumpspeedField;
    public InputField runspeedField;
    public InputField atkField;
    public InputField armortypeField;
	void Submit()
    {
        Item item = new Item();
        item.name = nameField.text;
        if (costField.text == "") item.cost = 0;
        else item.cost = Convert.ToInt32(costField.text);

        if (hpField.text == "") item.hp = 0;
        else item.hp = Convert.ToInt32(hpField.text);

        if (mpField.text == "") item.mp = 0;
        else item.mp = Convert.ToInt32(mpField.text);

        if (typeField.text == "") item.type = 0;
        else item.type = Convert.ToInt32(typeField.text);

        if (attackspeedField.text == "") item.attackspeed = 0;
        else item.attackspeed = Convert.ToSingle(attackspeedField.text);

        if (jumpspeedField.text == "") item.jumpspeed = 0;
        else item.jumpspeed = Convert.ToSingle(jumpspeedField.text);

        if (runspeedField.text == "") item.runspeed = 0;
        else item.runspeed = Convert.ToSingle(runspeedField.text);

        if (atkField.text == "") item.atk = 0;
        else item.atk = Convert.ToInt32(atkField.text);

        if (armortypeField.text == "") item.armortype = -1;
        else item.armortype = Convert.ToInt32(armortypeField.text);

        WorldVar.player.inven.AddItem(item);
        InvenMenu.SendMessage("InvenSetting", SendMessageOptions.DontRequireReceiver);
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
