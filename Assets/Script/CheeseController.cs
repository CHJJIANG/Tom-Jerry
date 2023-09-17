using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseController : MonoBehaviour
{
    public SpriteRenderer SP;
    public Sprite[] hurt;

    private int hurtTimes;

    // Start is called before the first frame update
    void Start()
    {
        SP = gameObject.GetComponent<SpriteRenderer>();
        hurtTimes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        SP.sprite = hurt[hurtTimes];

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (hurtTimes < hurt.Length)
            {
                hurtTimes++;
            }
        }

    }
}
