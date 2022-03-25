using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int maxhealth = 2;
    public int currentHealth;
    public GameObject player;

    public float enemyRadius = 10f;

    private Animator anim;

    void Start() {
        currentHealth = maxhealth;
        anim = GetComponentInChildren<Animator>();
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
    }

    void Update(){
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= enemyRadius) {
            goToTarget();
            Attack();
            Debug.Log("i see yo bitchass");
        }

        if (currentHealth <=0) {
            anim.SetTrigger("Die");
            Debug.Log("enemy died.");
        }
    }

    void Attack() {
      anim.SetTrigger("Attack");
    }

        void goToTarget() {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }



    void die() {
        anim.SetTrigger("Die");
    }

    void OnDrawGizmosSelected() {

        Gizmos.DrawWireSphere(transform.position, enemyRadius);
    }
}
