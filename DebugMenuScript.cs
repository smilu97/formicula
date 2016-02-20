using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class DebugMenuScript : MonoBehaviour {
    private InputField HPField;
    private InputField MaxHPField;
    private InputField MPField;
    private InputField MaxMPField;
    private InputField AttackSpeedField;
    private InputField RunSpeed;
	// Use this for initialization
	void Start ()
    {
        HPField = GameObject.Find("HPField").GetComponent<InputField>();
        MaxHPField = GameObject.Find("MaxHPField").GetComponent<InputField>();
        MPField = GameObject.Find("MPField").GetComponent<InputField>();
        MaxMPField = GameObject.Find("MaxMPField").GetComponent<InputField>();
        AttackSpeedField = GameObject.Find("AttackSpeedField").GetComponent<InputField>();
        RunSpeed = GameObject.Find("RunSpeedField").GetComponent<InputField>();
        HPField.text = WorldVar.player.hp.ToString();
        MaxHPField.text = WorldVar.player.maxhp.ToString();
        MPField.text = WorldVar.player.mp.ToString();
        MaxMPField.text = WorldVar.player.maxmp.ToString();
        AttackSpeedField.text = WorldVar.player.attackspeed.ToString();
        RunSpeed.text = WorldVar.player.runspeed.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        WorldVar.player.hp = Convert.ToInt32(HPField.text);
        WorldVar.player.maxhp = Convert.ToInt32(MaxHPField.text);
        WorldVar.player.mp = Convert.ToInt32(MPField.text);
        WorldVar.player.maxmp = Convert.ToInt32(MaxMPField.text);
        WorldVar.player.attackspeed = Convert.ToSingle(AttackSpeedField.text);
        WorldVar.player.runspeed = Convert.ToSingle(RunSpeed.text);
	}
}
