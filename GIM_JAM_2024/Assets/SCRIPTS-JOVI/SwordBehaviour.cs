using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    // Start is called before the first frame update



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

}
