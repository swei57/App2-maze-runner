using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    public GameObject doorUI;
    private CharacterController controller;
    public float speed = 6.0f;
	public float dirSpeed = 60.0f;
	private Vector3 moveDir = Vector3.zero;
	public float gravity = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void OnTriggerStay(Collider col) {
        if(col.tag == "Doors"){
        doorUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col){
        if(col.tag == "Doors"){
        doorUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w") || Input.GetKey("s") 
        || Input.GetKey("a") || Input.GetKey("d")){
            //walk animation
            animator.SetInteger("AniParam", 1);
            speed = 5;
        }
        //running animation trigger
        if((Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w")) ||
         (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("s")) ||
          (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("a")) ||
           (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("d"))){
            animator.SetInteger("AniParam", 2);
            speed = 8;
        }
        if(!Input.anyKey){
            animator.SetInteger("AniParam", 0);
        }

        if(controller.isGrounded){
			moveDir = transform.forward * Input.GetAxis("Vertical") * speed;
		}
    	float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * dirSpeed * Time.deltaTime, 0);
		controller.Move(moveDir * Time.deltaTime);
		moveDir.y -= gravity * Time.deltaTime;
    }
}
