using UnityEngine;
using System.Collections;

public class EnemyFocaAI : MonoBehaviour {
    private GameObject playerObject;
    private NavMeshAgent navAgent;
    private Vector3 moveDirection;
    private CharacterController controller;
    private Animator anim;
    private bool DetectedPlayer = false;
    private Unit property;
    
    //void Moving(int Horizontal, int Vertical, bool bRun, bool bJump)
    //{
    //    if (controller.isGrounded)
    //    {
    //        moveDirection = new Vector3(Horizontal, 0, Vertical);
    //        moveDirection = transform.TransformDirection(moveDirection);
    //        moveDirection *= property.runspeed;
    //        if (bRun) moveDirection *= 2; // Run with Shift
    //        if (bJump)
    //            moveDirection.y = property.jumpspeed;
    //    }
    //    moveDirection.y -= WorldVar.gravity * Time.deltaTime;
    //    controller.Move(moveDirection * Time.deltaTime);

    //} // Horizontal = Right, Left   //Vertical = Front, Back
    
	void Start () {
        playerObject = GameObject.Find("Player");
        //controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        property = new Unit();
        property.name = "Foca";
	}
	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            DetectedPlayer = true;            
        }
    }
	void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Player")
        {
            WorldVar.player.hp -= property.dmg;
        }
    }
    void AnimationUpdate()
    {
        if (Mathf.Abs(navAgent.velocity.x) > 1 || Mathf.Abs(navAgent.velocity.z) > 1)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }
	void Update () {       
        // Moving(0, 0, false, false);
        AnimationUpdate();
        if(DetectedPlayer)
        {
            navAgent.destination = playerObject.transform.position;
        }       
	}
    void OnGUI()
    {
        //if(true)
        //{
        //    Vector3 scPos = Camera.main.WorldToScreenPoint(transform.position);
        //    scPos.y -= 50;
        //    GUI.HorizontalSlider(new Rect(0,0,100,100), property.hp * 100 / property.maxhp, 0, 100);
        //}
    }
}
