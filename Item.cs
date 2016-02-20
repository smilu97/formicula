using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

[Serializable]
public class Item
{
    public static Dictionary<string, int> NameTypeDic;
    public static Dictionary<int, string> TypeNameDic;
    public static Dictionary<int, string> ArmorTypeNameDic;
    public static Dictionary<string, int> NameArmorTypeDic;
    public static bool TypeDictionarySet = false;

    public int cost;
    public int type;
    public int hp;
    public int mp;
    public float attackspeed;
    public float runspeed;
    public float jumpspeed;
    public int atk;
    public string name;
    public int armortype;
    public Item()
    {
        if(!TypeDictionarySet)
        {
            NameTypeDic = new Dictionary<string, int>();
            TypeNameDic = new Dictionary<int, string>();
            ArmorTypeNameDic = new Dictionary<int, string>();
            NameArmorTypeDic = new Dictionary<string, int>();

            TypeNameDic.Add(0, "Etc");
            TypeNameDic.Add(1, "Weapon");
            TypeNameDic.Add(2, "Armor");
            TypeNameDic.Add(3, "Consumable");

            for (int i = 0; i < 4; ++i)
            {
                NameTypeDic.Add(TypeNameDic[i], i);
            }

            ArmorTypeNameDic.Add(0, "Helmet");
            ArmorTypeNameDic.Add(1, "Bodyarmor");
            ArmorTypeNameDic.Add(2, "Legarmor");
            ArmorTypeNameDic.Add(3, "Glove");
            ArmorTypeNameDic.Add(4, "Boots");
            ArmorTypeNameDic.Add(5, "Weapon");

            for (int i = 0; i < 5;++i)
            {
                NameArmorTypeDic.Add(ArmorTypeNameDic[i], i);
            }
            
            TypeDictionarySet = true;
        }
        Clear();        
    }
    public void Clear()
    {
        cost = 0;
        type = 0;
        hp = 0;
        mp = 0;
        attackspeed = 0;
        runspeed = 0;
        jumpspeed = 0;
        atk = 0;
        armortype = -1;
        name = "unnameditem";
    }
    public string Explain()
    {
        string str = "Name : " + name + '\n';
        str += "Cost : " + cost.ToString() + '\n';
        str += "Type : " + GetTypeName(type) + '\n';
        if(hp != 0)
        {
            str += "HP Bonus : " + hp.ToString() + '\n';
        }
        if(mp != 0)
        {
            str += "MP Bonus : " + mp.ToString() + '\n'; 
        }
        if(attackspeed != 0)
        {
            str += "AttackSpeed Bonus : " + attackspeed.ToString() + '\n';
        }
        if (runspeed != 0)
        {
            str += "RunSpeed Bonus : " + runspeed.ToString() + '\n';
        }
        if (jumpspeed != 0)
        {
            str += "JumpSpeed Bonus : " + jumpspeed.ToString() + '\n';
        }
        if (atk != 0)
        {
            str += "AttackDamage Bonus : " + atk.ToString() + '\n';
        }
        if(armortype != -1)
        {
            str += "Armortype : " + GetArmorTypeName(armortype) + '\n';
        }

        return str;
    }
    public string ExplainBonus()
    {
        string str = "";
        if (hp != 0)
        {
            str += "HP Bonus : " + hp.ToString() + '\n';            
        }
        if (mp != 0)
        {
            str += "MP Bonus : " + mp.ToString() + '\n';
        }
        if (attackspeed != 0)
        {
            str += "AttackSpeed Bonus : " + attackspeed.ToString() + '\n';
        }
        if (runspeed != 0)
        {
            str += "RunSpeed Bonus : " + runspeed.ToString() + '\n';
        }
        if (jumpspeed != 0)
        {
            str += "JumpSpeed Bonus : " + jumpspeed.ToString() + '\n';
        }
        if (atk != 0)
        {
            str += "AttackDamage Bonus : " + atk.ToString() + '\n';
        }
        if(str == "")
        {
            str = "None";
        }
        return str;
    }
    public string GetTypeName(int n)
    {
        return TypeNameDic[n];
    }
    public string GetArmorTypeName(int n)
    {
        return ArmorTypeNameDic[n];
    }
    static public Item AllBonusSum(Item[] its, int n)
    {
        Item it = new Item();
        for(int i=0;i< n; ++i)
        {
            it.hp += its[i].hp;
            it.mp += its[i].mp;
            it.attackspeed += its[i].attackspeed;
            it.runspeed += its[i].runspeed;
            it.jumpspeed += its[i].jumpspeed;
            it.atk += its[i].atk;
        }
        return it;
    }
}
