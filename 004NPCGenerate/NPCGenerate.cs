using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

public class NPCGenerate : MonoBehaviour {
    private string str;
    private int num = 0;
    private List<Item> itemList;
    public InputField pathField;
    public InputField costField;
    public InputField typeField;
    public InputField hpField;
    public InputField mpField;
    public InputField attackspeedField;
    public InputField runspeedField;
    public InputField jumpspeedField;
    public InputField atkField;
    public InputField nameField;
    public InputField armortypeField;
    public Text ExplainText;
    void Submit()
    {
        string pa = pathField.text;
        if(pa == "")
        {
            pa = "Output/AAA.txt";
        }
        StreamWriter sw = new StreamWriter(new FileStream(pa, FileMode.Create, FileAccess.Write), Encoding.UTF8);
        XmlSerializer bf = new XmlSerializer(itemList.GetType());
        bf.Serialize(sw, itemList);
        sw.Close();
    }
    void Add()
    {
        str += costField.text + '\n';
        str += typeField.text + '\n';
        str += hpField.text + '\n';
        str += mpField.text + '\n';
        str += attackspeedField.text + '\n';
        str += runspeedField.text + '\n';
        str += jumpspeedField.text + '\n';
        str += atkField.text + '\n';
        str += nameField.text + '\n';
        str += armortypeField.text + '\n';

        Item item = new Item();
        item.cost = Convert.ToInt32(costField.text);
        item.type = Convert.ToInt32(typeField.text);
        item.hp = Convert.ToInt32(hpField.text);
        item.mp = Convert.ToInt32(mpField.text);
        item.attackspeed = Convert.ToSingle(attackspeedField.text);
        item.runspeed = Convert.ToSingle(runspeedField.text);
        item.jumpspeed = Convert.ToSingle(jumpspeedField.text);
        item.atk = Convert.ToInt32(atkField.text);
        item.name = nameField.text;
        item.armortype = Convert.ToInt32(armortypeField.text);
        itemList.Add(item);

        ++num;
        ClearInputfield();
        UpdateText();
    }
    void Delete()
    {        
        if(num==1)
        {
            itemList.RemoveAt(num - 1);
            str = "";
            --num;
        }
        else if(num>1)
        {
            itemList.RemoveAt(num - 1);
            int count = 0;
            for (int i = str.Length - 1; i >= 0; --i)
            {
                if (str[i] == '\n')
                {
                    ++count;
                }
                if (count == 11)
                {
                    str = str.Substring(0, i + 1);
                    break;
                }
            }
            --num;
        }        
        UpdateText();
    }
    void Clear()
    {
        str = "";
        num = 0;
        ClearInputfield();
        UpdateText();  
    }
    void ClearInputfield()
    {
        costField.text = "0";
        typeField.text = "0";
        hpField.text = "0";
        mpField.text = "0";
        attackspeedField.text = "0";
        runspeedField.text = "0";
        jumpspeedField.text = "0";
        atkField.text = "0";
        nameField.text = "unnamed";
        armortypeField.text = "-1";
    }
    void Start () {
        itemList = new List<Item>();
        str = "";
        num = 0;
        ClearInputfield();
	}
	void Update () {        
	}
    void UpdateText()
    {
        string ex = "num : " + num + "\n\n";
        for (int i = 0; i < num; ++i)
        {
            ex += itemList[i].Explain();
            ex += '\n';
        }
        ExplainText.text = ex;
    }
}
