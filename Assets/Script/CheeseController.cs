using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseController : MonoBehaviour
{
    public SpriteRenderer SP;
    public Sprite[] hurt;

    public float[] xSize;
    public float[] ySize;
    public float[] xOffset;
    public float[] yOffset;

    BoxCollider2D BC;

    private int hurtTimes;

    // Start is called before the first frame update
    void Start()
    {
        SP = gameObject.GetComponent<SpriteRenderer>();
        hurtTimes = 0;

        BC = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SP.sprite = hurt[hurtTimes];
        BC.size = new Vector2(xSize[hurtTimes], ySize[hurtTimes]);
        BC.offset = new Vector2(xOffset[hurtTimes], yOffset[hurtTimes]);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (hurtTimes < hurt.Length - 1)
            {
                hurtTimes++;
            }
        }

    }
}
