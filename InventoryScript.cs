using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryScript : MonoBehaviour {
    public Dropdown InvenEtcDropdown;
    public Dropdown InvenWeaponDropdown;
    public Dropdown InvenArmorDropdown;
    public Dropdown InvenConsumableDropdown;
    public Text ExplainText;

    private int Focus;
    private int FocusNum;
	
	void Start () {
	
	}	
	void Update () {
	
	}
    void WeaponEquipClick()
    {
        int num = InvenWeaponDropdown.value;
        int itemindex = WorldVar.player.inven.FindItemIndex(Item.NameTypeDic["Weapon"], num);
        WorldVar.player.equip[5] = itemindex;
    }
    void ArmorEquipClick()
    {
        int num = InvenArmorDropdown.value;
        int itemindex = WorldVar.player.inven.FindItemIndex(Item.NameTypeDic["Armor"], num);
        int itemtype = WorldVar.player.inven.items[itemindex].armortype;
        WorldVar.player.equip[itemtype] = itemindex;
    }
    void InvenSetting()
    {
        InvenEtcDropdown.options.Clear();
        InvenWeaponDropdown.options.Clear();
        InvenArmorDropdown.options.Clear();
        InvenConsumableDropdown.options.Clear();
        Inventory inv = WorldVar.player.inven;
        for (int i = 0; i < inv.storeSize; ++i)
        {
            if (inv.items[i] != null)
            {
                Dropdown.OptionData od = new Dropdown.OptionData();
                print("Adding" + inv.items[i].name);
                od.text = inv.items[i].name;
                switch (inv.items[i].type)
                {
                    case 0: // Etc
                        InvenEtcDropdown.options.Add(od);
                        break;
                    case 1: // Weapon
                        InvenWeaponDropdown.options.Add(od);
                        break;
                    case 2: // Armor
                        InvenArmorDropdown.options.Add(od);
                        break;
                    case 3: // Consumable
                        InvenConsumableDropdown.options.Add(od);
                        break;
                }
            }
        }
    }    
    void EtcChange()
    {
        int num = InvenEtcDropdown.value;
        Item item = WorldVar.player.inven.FindItem(Item.NameTypeDic["Etc"], num);
        Focus = Item.NameTypeDic["Etc"];
        if(item.type != -1) // Couldn't Find proper item
        {
            ExplainText.text = item.Explain();
            FocusNum = num;
        }
        else
        {
            ExplainText.text = "Couldn't proper Item";
        }
    }
    void WeaponChange()
    {
        int num = InvenWeaponDropdown.value;
        Item item = WorldVar.player.inven.FindItem(Item.NameTypeDic["Weapon"], num);
        Focus = Item.NameTypeDic["Weapon"];
        if (item.type != -1) // Couldn't Find proper item
        {
            ExplainText.text = item.Explain();
            FocusNum = num;
        }
        else
        {
            ExplainText.text = "Couldn't proper Item";
        }
    }
    void ArmorChange()
    {
        int num = InvenArmorDropdown.value;
        Item item = WorldVar.player.inven.FindItem(Item.NameTypeDic["Armor"], num);
        Focus = Item.NameTypeDic["Armor"];
        if (item.type != -1) // Couldn't Find proper item
        {
            ExplainText.text = item.Explain();
            FocusNum = num;
        }
        else
        {
            ExplainText.text = "Couldn't proper Item";
        }
    }
    void ConsumableChange()
    {
        int num = InvenConsumableDropdown.value;
        Item item = WorldVar.player.inven.FindItem(Item.NameTypeDic["Consumable"], num);
        Focus = Item.NameTypeDic["Consumable"];
        if (item.type != -1) // Couldn't Find proper item
        {
            ExplainText.text = item.Explain();
            FocusNum = num;
        }
        else
        {
            ExplainText.text = "Couldn't proper Item";
        }
    }
}
