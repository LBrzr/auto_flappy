using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScrip : MonoBehaviour
{

    public Rigidbody2D body;
    public float flapStrength = 7.5f;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.isAlive && Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }

    public void jump()
    {
        body.velocity = Vector2.up * flapStrength;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
    }

    private void OnBecameInvisible()
    {
        logic.gameOver();
    }
}
