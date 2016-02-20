using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    private Animator anim;
    private GameObject cam;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float camrot = 0;
    public float turnspeed = 1.0f;
    public float MouseSensitivityX = 5;
    public float MouseSensitivityY = 2;
    public float AngleLimitMin = -70;
    public float AngleLimitMax = 20;
    public bool LockYAngle = true;

	// Use this for initialization
    void Attack()
    {
        if(WorldVar.cursorShow == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetFloat("attackspeed", WorldVar.player.attackspeed);
                anim.SetBool("attack", true);
            }
        }        
        if(Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("attack", false);
        }
    }
	void Start () {
        WorldVar.cursorShow = false;
        if(WorldVar.player == null)
        {
            WorldVar.player = new Player();
        }
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        transform.position = WorldVar.player.position;
	}
    void Moving()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= WorldVar.player.runspeed;
            if (Input.GetKey(KeyCode.LeftShift)) moveDirection *= 2; // Run with Shift
            if (Input.GetButton("Jump"))
                moveDirection.y = WorldVar.player.jumpspeed;
        }
        moveDirection.y -= WorldVar.gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
    void AnimationUpdate()
    {
        if(Mathf.Abs(controller.velocity.x) > 0.1f || Mathf.Abs(controller.velocity.z) > 0.1f)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }
    void Turning()
    {
        if(!(WorldVar.cursorShow))
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivityX, 0));
            if (!LockYAngle)
            {
                float lastcamrot = camrot;
                camrot += Input.GetAxis("Mouse Y") * MouseSensitivityY;
                if (AngleLimitMin <= camrot && camrot <= AngleLimitMax)
                {
                    cam.transform.RotateAround(transform.position, -transform.right, Input.GetAxis("Mouse Y") * MouseSensitivityY);
                }
                else
                {
                    camrot = lastcamrot;
                }
            }   
        }            
    }
	// Update is called once per frame
	void Update () {
        Moving();
        Turning();
        Attack();
        AnimationUpdate();
        if(Input.GetKey(KeyCode.F))
        {
            WorldVar.player.hp -= 1;
        }
        if(Input.GetKey(KeyCode.R))
        {
            WorldVar.player.hp = WorldVar.player.maxhp;
        }
	}
    void OnApplicationQuit()
    {
        WorldVar.player.position = transform.position;
        WorldVar.player.Save();
    }
}
