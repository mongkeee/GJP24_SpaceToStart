using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float launchSpeed = 5;
    [SerializeField] private float speedMax = 5;
    public bool onHold = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("objPlayer").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        //launchBall(270);
    }

    // Update is called once per frame
    void Update()
    {
        if(onHold == true){
            rb.velocity = new Vector2(0,0);
            rb.position = new Vector2(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 1);
        }

        if(rb.position.y < -5){
            player.loseHealth();
        }
    }

    private void FixedUpdate() {
        rb.velocity = rb.velocity * speedMax;
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, speedMax);
    }

    public void launchBall(float degree){
        rb.velocity = new Vector2(0,0);
        onHold = false;
        //degree to vector2
        float rad = degree*MathF.PI/180;
        Vector2 arah = new Vector2(MathF.Cos(rad), MathF.Sin(rad));
        rb.AddForce(arah * launchSpeed);
    }
}
