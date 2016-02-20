using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EquipMenuScript : MonoBehaviour {
    public Text[] ArmorTexts;
	// Use this for initialization
	void Start () {
	}
    public void UpdateTexts()
    {
        if (ArmorTexts.Length == 6)
        {
            for (int i = 0; i < 6; ++i)
            {
                ArmorTexts[i].text = "A";
                if (WorldVar.player.equip[i] != -1)
                {
                    ArmorTexts[i].text = WorldVar.player.inven.items[WorldVar.player.equip[i]].name;
                }
                else ArmorTexts[i].text = "Unequipped";
            }
        }
    }
	void Update () {
        UpdateTexts();
	}
    void HelmetButtonClick()
    {
        WorldVar.player.equip[Item.NameArmorTypeDic["Helmet"]] = -1;
    }
    void BodyarmorButtonClick()
    {
        WorldVar.player.equip[Item.NameArmorTypeDic["Bodyarmor"]] = -1;
    }
    void LegarmorButtonClick()
    {
        WorldVar.player.equip[Item.NameArmorTypeDic["Legarmor"]] = -1;
    }
    void GloveButtonClick()
    {
        WorldVar.player.equip[Item.NameArmorTypeDic["Glove"]] = -1;
    }
    void BootsButtonClick()
    {
        WorldVar.player.equip[Item.NameArmorTypeDic["Boots"]] = -1;
    }
    void WeaponButtonClick()
    {
        WorldVar.player.equip[Item.NameArmorTypeDic["Weapon"]] = -1;
    }
}
