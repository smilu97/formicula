using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameUI : MonoBehaviour {
    public GameObject canvas;
    private bool menuison = false;
    private bool InvenMenuIson = false;
    private bool equipmenuison = false;
    private float deltaTime = 0;
    public Slider HealthBar;
    public Text HealthText;
    public Slider ManaBar;
    public Text ManaText;
    public Text AText;
    public GameObject MenuObject;
    public GameObject DebugMenuObject;
    public GameObject InvenMenuObject;
    public GameObject DebugInvenMenuObject;
    public GameObject EquipmenuObject;

    private CharacterController cc;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        cc = GameObject.Find("Player").GetComponent<CharacterController>();
        //HealthBar = GameObject.Find("HPBar").GetComponent<Slider>();
        //HealthText = GameObject.Find("HPText").GetComponent<Text>();
        //ManaBar = GameObject.Find("MPBar").GetComponent<Slider>();
        //ManaText = GameObject.Find("MPText").GetComponent<Text>();
        //AText = GameObject.Find("AText").GetComponent<Text>();
        //canvas = GameObject.Find("InGameCanvas");
        //MenuObject = GameObject.Find("Menu");
        //DebugMenuObject = GameObject.Find("DebugMenu");
        //InvenMenuObject = GameObject.Find("InvenMenu");

        //InvenEtcDropdown = GameObject.Find("EtcItemlistDropdown").GetComponent<Dropdown>();
        //InvenWeaponDropdown = GameObject.Find("WeaponItemlistDropdown").GetComponent<Dropdown>();
        //InvenArmorDropdown = GameObject.Find("ArmorItemlistDropdown").GetComponent<Dropdown>();
        //InvenConsumableDropdown = GameObject.Find("ConsumableItemlistDropdown").GetComponent<Dropdown>();

        MenuObject.SetActive(false);
        DebugMenuObject.SetActive(false);
        InvenMenuObject.SetActive(false);
        DebugInvenMenuObject.SetActive(false);
        EquipmenuObject.SetActive(false);
	}
	
	// Update is called once per frame
    void MenuUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
        }
    }
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)) // Activate Menu and Mouse Cursor with ESC
        {
            if(menuison) // Already Menu is on the View
            {
                WorldVar.cursorShow = false;
                Cursor.visible = false;
                MenuObject.SetActive(false);
                if(WorldVar.IsDebugMode) // in Debug Mode, DebugMenu Appears
                {
                    DebugMenuObject.SetActive(false);
                }                
                if(InvenMenuIson)
                {
                    InvenMenuObject.SetActive(false);
                    InvenMenuIson = false;
                    if(WorldVar.IsDebugMode)
                    {
                        DebugInvenMenuObject.SetActive(false);
                    }
                }
                if(equipmenuison)
                {
                    EquipmenuObject.SetActive(false);
                    equipmenuison = false;
                }
            }
            else
            {
                WorldVar.cursorShow = true;
                Cursor.visible = true;
                MenuObject.SetActive(true);                          
                if(WorldVar.IsDebugMode)
                {
                    DebugMenuObject.SetActive(true);
                }                
            }
            menuison = !menuison;
        }
	    if(Input.GetKeyDown(KeyCode.LeftAlt) && !menuison) // Activate Mouse Cursor with LeftAlt
        {
            WorldVar.cursorShow = true;
            Cursor.visible = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftAlt) && !menuison)
        {
            WorldVar.cursorShow = false;
            Cursor.visible = false;
        }
        HealthBar.value = WorldVar.player.hp * 100 / WorldVar.player.maxhp;
        HealthText.text = WorldVar.player.hp.ToString() + '/' + WorldVar.player.maxhp.ToString();
        ManaBar.value = WorldVar.player.mp * 100 / WorldVar.player.maxmp;
        ManaText.text = WorldVar.player.mp.ToString() + '/' + WorldVar.player.maxmp.ToString();
        if(WorldVar.IsDebugMode)
        {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
            AText.text = "Velocity(X : " + cc.velocity.x.ToString() + "/ Y : " + cc.velocity.z.ToString() + ")\nFrame : " + 1.0f/deltaTime;
            
        }
        
	}
    void Back()
    {
        Application.LoadLevel("000FirstScene");
    }        
    void InventoryButtonClick()
    {
        if(InvenMenuIson)
        {
            CloseInventory();
        }
        else
        {
            OpenInventory();
        }
    }
    void CloseInventory()
    {
        InvenMenuObject.SetActive(false);
        InvenMenuIson = false;
        if(WorldVar.IsDebugMode)
        {
            DebugInvenMenuObject.SetActive(false);
        }
    }
    void OpenInventory()
    {
        InvenMenuObject.SendMessage("InvenSetting", SendMessageOptions.DontRequireReceiver);
        InvenMenuObject.SetActive(true);
        InvenMenuIson = true;
        if(WorldVar.IsDebugMode)
        {
            DebugInvenMenuObject.SetActive(true);
        }
    }
    void EquipButtonClick()
    {
        if(equipmenuison)
        {
            CloseEquipmenu();
        }
        else
        {
            OpenEquipmenu();
        }
    }
    void CloseEquipmenu()
    {
        EquipmenuObject.SetActive(false);
        equipmenuison = false;
    }
    void OpenEquipmenu()
    {       
        EquipmenuObject.SetActive(true);
        equipmenuison = true;
        EquipmenuObject.SendMessage("UpdateTexts", SendMessageOptions.DontRequireReceiver);
    }
}
