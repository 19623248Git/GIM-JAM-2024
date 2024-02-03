using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckAttack : MonoBehaviour
{
    
    public float min_distance;
    public Transform player;
    public GameObject sword;

    public float timebtwatk;
    public float Starttimebtwatk;
    public Transform attackpos;
    public LayerMask enemydetect;
    public float attackrange;
    public int damage;
    public bool stop;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (timebtwatk <= 0)
        {
            if ((Vector2.Distance(transform.position, player.position) < min_distance))
            {
                stop = false;
                sword.SetActive(false);

                if (!stop)
                {
                    sword.SetActive(true);
                    Collider2D[] enemiestohurt = Physics2D.OverlapCircleAll(attackpos.position, attackrange, enemydetect);
                    for (int i = 0; i < enemiestohurt.Length; i++)
                    {
                        enemiestohurt[i].GetComponent<PlayerController>().TakeDamage(damage);
                        
                    }
                    stop = true;
                    timebtwatk = Starttimebtwatk;
                }
                
            }

        }
        else
        {
            timebtwatk -= Time.deltaTime;
        }

    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackpos.position, attackrange);
    }
}
