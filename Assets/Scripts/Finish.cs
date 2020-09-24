using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider col){
        GameObject.Find("Rin 3D").SendMessage("Finished");
    }
}
