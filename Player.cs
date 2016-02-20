using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class Player : Unit
{
    public string map;
    public Inventory inven;
    public int[] equip;
    public Item equipBonus;
    public Player()
    {
        equip = new int[6];
        for (int i = 0; i < 6; ++i)
        {
            equip[i] = -1;
        }
        map = WorldVar.FirstMap;
        inven = new Inventory();

        Item item = new Item();
        item.name = "WoodSword";
        item.type = 1;
        item.armortype = 5;
        item.atk = 10;
        inven.AddItem(item);

        item = new Item();
        item.name = "WoodArmor";
        item.type = 2;
        item.armortype = 1;
        item.hp = 100;
        inven.AddItem(item);

        for(int i=0;i<20; ++i)
        {
            item = new Item();
            item.name = "Potion";
            item.type = 3;
            item.hp = 100;
            inven.AddItem(item);
        }

        item = new Item();
        item.name = "AAA";
        item.type = 0;
        inven.AddItem(item);
        updateEquipBonus();        
    }
    public void updateEquipBonus()
    {
        Item[] items = new Item[6];
        int n = 0;
        for(int i=0;i<6; ++i)
        {
            if (equip[i] != -1)
            {
                items[n] = inven.items[equip[i]];
                ++n;
            }            
        }
        equipBonus = Item.AllBonusSum(items, n);
    }
    public void Save()
    {
        string filepath = "save/" + name+ ".sav";
        StreamWriter sw = new StreamWriter(filepath);
        sw.WriteLine(name);
        sw.WriteLine(level);
        sw.WriteLine(position.x);
        sw.WriteLine(position.y);
        sw.WriteLine(position.z);
        sw.WriteLine(hp.ToString());
        sw.WriteLine(maxhp.ToString());
        sw.WriteLine(mp.ToString());
        sw.WriteLine(maxmp.ToString());
        sw.WriteLine(attackspeed.ToString());
        sw.WriteLine(runspeed.ToString());
        sw.WriteLine(jumpspeed.ToString());
        sw.WriteLine(dmg.ToString());
        sw.WriteLine(def.ToString());

        sw.WriteLine(inven.storeSize.ToString());
        for (int i = 0; i < inven.storeSize; ++i)
        {
            if(inven.items[i] != null)
            {
                sw.WriteLine(i.ToString());
                sw.WriteLine(inven.items[i].cost);
                sw.WriteLine(inven.items[i].type);
                sw.WriteLine(inven.items[i].hp);
                sw.WriteLine(inven.items[i].mp);
                sw.WriteLine(inven.items[i].attackspeed);
                sw.WriteLine(inven.items[i].runspeed);
                sw.WriteLine(inven.items[i].jumpspeed);
                sw.WriteLine(inven.items[i].armortype);
                sw.WriteLine(inven.items[i].atk);
                sw.WriteLine(inven.items[i].name);
            }
        }
        sw.WriteLine("ItemEnd");
        sw.Close();
    } 
    public void Load()
    {
        string filepath = "save/" + name + ".sav";
        StreamReader sr = new StreamReader(filepath);
        name = sr.ReadLine();
        level = Convert.ToInt32(sr.ReadLine());
        position.x = Convert.ToSingle(sr.ReadLine());
        position.y = Convert.ToSingle(sr.ReadLine());
        position.z = Convert.ToSingle(sr.ReadLine());
        hp = Convert.ToInt32(sr.ReadLine());
        maxhp = Convert.ToInt32(sr.ReadLine());
        mp = Convert.ToInt32(sr.ReadLine());
        maxmp = Convert.ToInt32(sr.ReadLine());
        attackspeed = Convert.ToSingle(sr.ReadLine());
        runspeed = Convert.ToSingle(sr.ReadLine());
        jumpspeed = Convert.ToSingle(sr.ReadLine());
        dmg = Convert.ToInt32(sr.ReadLine());
        def = Convert.ToInt32(sr.ReadLine());
        inven.storeSize = Convert.ToInt32(sr.ReadLine());
        inven.items = new Item[inven.storeSize];
        string str;
        str = sr.ReadLine();
        while(str != "ItemEnd")
        {
            int i = Convert.ToInt32(str);
            inven.items[i].cost = Convert.ToInt32(sr.ReadLine());
            inven.items[i].type = Convert.ToInt32(sr.ReadLine());
            inven.items[i].hp = Convert.ToInt32(sr.ReadLine());
            inven.items[i].mp = Convert.ToInt32(sr.ReadLine());
            inven.items[i].attackspeed = Convert.ToSingle(sr.ReadLine());
            inven.items[i].runspeed = Convert.ToSingle(sr.ReadLine());
            inven.items[i].jumpspeed = Convert.ToSingle(sr.ReadLine());
            inven.items[i].armortype = Convert.ToInt32(sr.ReadLine());
            inven.items[i].atk = Convert.ToInt32(sr.ReadLine());
            inven.items[i].name = sr.ReadLine();
            str = sr.ReadLine();
        }
        sr.Close();
    }
}