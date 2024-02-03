using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePulse : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public Color color1;
    public Color color2;
    public Color lerp;
    
    void Start()
    {
        health = PlayerPrefs.GetInt("health", 3);
        color1 = Color.white;
        color2 = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > PlayerPrefs.GetInt("health", 3))
        {
            health = PlayerPrefs.GetInt("health", 3);
            lerp = Color.Lerp(GetComponent<SpriteRenderer>().color, color2, 1);
            GetComponent<SpriteRenderer>().color = lerp;
        }
            
    }
}
