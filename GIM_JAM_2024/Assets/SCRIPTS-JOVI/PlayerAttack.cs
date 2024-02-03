using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    
    //code dewa pls
    public float timebtwatk;
    public float Starttimebtwatk;
    public Transform attackpos;
    public LayerMask enemydetect;
    public float attackrange;
    public int damage;
    public bool stop;
    public GameObject sword;

    // Update is called once per frame
    void Update()
    {
        
        if (timebtwatk <= 0)
        {
            stop = false;
            sword.SetActive(false);
            if (Input.GetKey(KeyCode.Space) && !stop) {
                sword.SetActive(true);
                Collider2D[] enemiestohurt = Physics2D.OverlapCircleAll(attackpos.position, attackrange, enemydetect);
                for (int i = 0; i < enemiestohurt.Length; i++)
                {
                    enemiestohurt[i].GetComponent<EnemyController>().TakeDamage(damage);
                }
                stop = true;
                timebtwatk = Starttimebtwatk;
            }
            
        }
        else
        {
            timebtwatk -= Time.deltaTime;
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpos.position, attackrange);
    }
}
