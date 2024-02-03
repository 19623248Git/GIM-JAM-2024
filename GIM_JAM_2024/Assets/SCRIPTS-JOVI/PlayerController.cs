using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public KeyCode key_up;
    public KeyCode key_down;
    public KeyCode key_left;
    public KeyCode key_right;
    public KeyCode key_attack;
    public int keyU;
    public int keyD;
    public int keyL;
    public int keyR;
    public int keyAtk;
    public float verticalinput;
    public float horizontalinput;
    public GameObject player;
    public GameObject sword;
    public float swingtime;

    public float iframes_time;
    public Animator anim;
    public int health;
    public SpriteRenderer sprite_hero;


    // Start is called before the first frame update
    void Start()
    {
        //controls
        keyU = PlayerPrefs.GetInt("keyU", (int)KeyCode.W);
        keyD = PlayerPrefs.GetInt("keyD", (int)KeyCode.S);
        keyL = PlayerPrefs.GetInt("keyL", (int)KeyCode.A);
        keyR = PlayerPrefs.GetInt("keyR", (int)KeyCode.D);
        keyAtk = PlayerPrefs.GetInt("KeyAtk", (int)KeyCode.Space);
        key_up = (KeyCode)keyU;
        key_down = (KeyCode)keyD;
        key_left = (KeyCode)keyL;
        key_right = (KeyCode)keyR;
        key_attack = (KeyCode)keyAtk;

        //player stats
        health = 3;
        speed = 7;
        verticalinput = 0;
        horizontalinput = 0;
        iframes_time = -1; //at the begining of the game
        sprite_hero = GetComponent<SpriteRenderer>();
        anim.SetBool("IsHurt", false);
    }

    // Update is called once per frame
    void Update()
    {

        //controls
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
            sprite_hero.flipX = false;
        }
        if (Input.GetKey(key_left))
        {
            horizontalinput = -1;
            sprite_hero.flipX = true;
            
        }

        if (!Input.GetKey(key_up) & !Input.GetKey(key_down))
        {
            verticalinput = 0;
        }

        if (!Input.GetKey(key_right) & !Input.GetKey(key_left))
        {
            horizontalinput = 0;
        }



        //stats
        if (iframes_time > 0)
        {
            iframes_time -= Time.deltaTime;
        }

        if (iframes_time <= 0)
        {
            GetComponent<Collider2D>().enabled = true;
            anim.SetBool("IsHurt", false);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    void FixedUpdate()
    {
        //player.transform.position = player.transform.position + new Vector3(horizontalinput * speed * Time.deltaTime, verticalinput * speed * Time.deltaTime);
        rb2d.velocity = new Vector2(horizontalinput*speed, verticalinput*speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health--;
            GetComponent<Collider2D>().enabled = false;
            iframes_time = 2f;
            anim.SetBool("IsHurt", true);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        iframes_time = 2f;
        anim.SetBool("IsHurt", true);
    }

}
