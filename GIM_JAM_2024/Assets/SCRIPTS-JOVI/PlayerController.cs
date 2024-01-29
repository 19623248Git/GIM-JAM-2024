using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public KeyCode key_up;
    public KeyCode key_down;
    public KeyCode key_left;
    public KeyCode key_right;
    public int keyU;
    public int keyD;
    public int keyL;
    public int keyR;
    public float verticalinput;
    public float horizontalinput;
    //public bool inputvert;
    //public bool inputhorz;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        keyU = PlayerPrefs.GetInt("keyU", (int)KeyCode.W);
        keyD = PlayerPrefs.GetInt("keyD", (int)KeyCode.S);
        keyL = PlayerPrefs.GetInt("keyL", (int)KeyCode.A);
        keyR = PlayerPrefs.GetInt("keyR", (int)KeyCode.D);
        key_up = (KeyCode)keyU;
        key_down = (KeyCode)keyD;
        key_left = (KeyCode)keyL;
        key_right = (KeyCode)keyR;
        speed = 12;
        verticalinput = 0;
        horizontalinput = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key_up))
        {
            verticalinput = 1;
        }
        if (Input.GetKey(key_down))
        {
            verticalinput = -1;
        }
        if (Input.GetKey(key_right))
        {
            horizontalinput = 1;
        }
        if (Input.GetKey(key_left))
        {
            horizontalinput = -1;
        }

        if (!Input.GetKey(key_up) & !Input.GetKey(key_down))
        {
            verticalinput = 0;
        }

        if (!Input.GetKey(key_right) & !Input.GetKey(key_left))
        {
            horizontalinput = 0;
        }
    }

    void FixedUpdate()
    {
        player.transform.position = player.transform.position + new Vector3(horizontalinput * speed * Time.deltaTime, verticalinput * speed * Time.deltaTime);
    }
}