using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private Animator animator;
    private bool doorOpen;

    void Start(){
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider col){
        if(col.gameObject.tag=="Player" && Input.GetKeyDown(KeyCode.E)){
            doorOpen = true;
            DoorControl("Open");
        }
    }

    void OnTriggerExit(Collider col){
        if(doorOpen){
            doorOpen = false;
            DoorControl("Close");
        };
    }

    void DoorControl(string direction){
        animator.SetTrigger(direction);
    }
}
