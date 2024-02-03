using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("ENEMY HIT!");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
