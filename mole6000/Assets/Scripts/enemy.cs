using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy : MonoBehaviour
{
    public int maxhealth =1;
    public int currentHealth;
    public GameObject player;
    public float AttackRadius = 10f;
    public float lookRadius = 25;
    bool enemyDead;
    private Animator anim;
    NavMeshAgent agent;
  
    
    

    void Start() {
        currentHealth = maxhealth;
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
       
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
    }

    void Update(){
        float distance = Vector3.Distance(player.transform.position, transform.position);

            if (currentHealth <=0) {
            anim.SetTrigger("Die");
            enemyDead = true;
        }

        if (distance <= AttackRadius && !enemyDead) {
            goToTarget();
            Attack();
            Debug.Log("i see yo bitchass");
        }

        if (distance <= lookRadius) {
            agent.SetDestination(player.transform.position);
            anim.SetFloat("Blend", 1, 0.1f, Time.deltaTime);
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

        Gizmos.DrawWireSphere(transform.position, AttackRadius);
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
