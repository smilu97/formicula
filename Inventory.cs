using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class Inventory{
    public Item[] items;
    public int storeSize = 30;
    public Inventory()
    {
        items = new Item[30];
        storeSize = 30;
    }
    public Item FindItem(int type, int num)
    {
        int count = 0;
        for(int i=0;i<storeSize; ++i)
        {
            if(items[i].type == type)
            {
                if(count == num)
                {
                    return items[i];
                }
                ++count;
            }
        }
        Item failureItem = new Item();
        failureItem.type = -1;
        return failureItem;
    }
    public int FindItemIndex(int type, int num)
    {
        int count = 0;
        for(int i=0;i<storeSize; ++i)
        {
            if (items[i].type == type)
            {
                if (count == num)
                {
                    return i;
                }
                ++count;
            }
        }
        return -1;
    }
    public void AddItem(Item item)
    {
        for(int i=0;i<storeSize; ++i)
        {
            if(items[i]== null)
            {
                items[i] = item;
                break;
            }
        }
    }
    public List<Item> GetTypeList(int t)
    {
        List<Item> list = new List<Item>();
        for(int i=0;i<storeSize; ++i)
        {
            if(items[i] != null)
            {
                if(items[i].type == t)
                {
                    list.Add(items[i]);
                }
            }
        }
        return list;
    }
    public int GetIndexofItem(Item item)
    {
        for(int i=0;i<storeSize; ++i)
        {
            if(items[i] != null)
            {
                if(items[i] == item)
                {
                    return i;
                }
            }
        }
        return -1;
    }    
}
