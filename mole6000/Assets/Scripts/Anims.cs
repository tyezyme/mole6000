using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anims : MonoBehaviour
{
    public Animator anim;
    public float attackRange = 0.5f;
    public Transform hammerPoint;
    public LayerMask enemyLayer;

    void Start() {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            StartCoroutine(Whack());
        }
    }

    void OnDrawGizmosSelected() {

        if (hammerPoint == null) {
            return;
        }
        Gizmos.DrawWireSphere(hammerPoint.position, attackRange);
    }


    
    private IEnumerator Whack() {
        anim.SetTrigger("Attack");

        yield return new WaitForSeconds(3);

        Collider[] hitEnemies = Physics.OverlapSphere(hammerPoint.position, attackRange, enemyLayer);
        foreach(Collider enemy in  hitEnemies) {
            Debug.Log("We hit" + enemy.name);
            Destroy(enemy);
        }

        UnityEngine.Debug.Log("WHACK!");
        
    }
}
