using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Unit
{
    public string name;
    public Vector3 position;
    public int hp;
    public int maxhp;
    public int mp;
    public int maxmp;
    public float attackspeed;
    public int level;
    public float runspeed;
    public float jumpspeed;
    public int dmg;
    public int def;
    public Unit()
    {
        position = new Vector3(0, 0, 0);
        name = "unnamed";
        hp = 100;
        maxhp = 100;
        mp = 1;
        maxmp = 1;
        attackspeed = 1.0f;
        level = 1;
        runspeed = 14;
        jumpspeed = 16;
        dmg = 1;
        def = 0;
    }
    public void GetDamage(int dam)
    {
        hp -= dam;
    }
    public void AddHP(int val)
    {
        hp += val;
        if (hp > maxhp)
        {
            hp = maxhp;
        }
    }
    public void AddMP(int val)
    {
        mp += val;
        if(mp > maxmp)
        {
            mp = maxmp;
        }
    }
}