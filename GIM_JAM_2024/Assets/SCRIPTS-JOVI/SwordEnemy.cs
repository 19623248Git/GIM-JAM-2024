using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemy : MonoBehaviour
{

    // Start is called before the first frame update
    public int health;
    void Start()
    {
        health = PlayerPrefs.GetInt("health", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HIT");
            health -= 1;
            PlayerPrefs.SetInt("health", health);
            Debug.Log(PlayerPrefs.GetInt("health"));
        }
    }
}
