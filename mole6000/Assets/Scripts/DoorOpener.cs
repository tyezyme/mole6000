using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public float openRadius;
    public GameObject player;
    public Animator anim;
    int first = 0;

    void Update() {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (player.transform.position.z <= -0.9) {

        
        if (distance <= openRadius) {
            anim.SetTrigger("open");
            first = 1;
        }
        }
        if (player.transform.position.z >= 0 && first == 1) {
            anim.SetTrigger("close");
        }
    }
    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, openRadius);
    }
}
