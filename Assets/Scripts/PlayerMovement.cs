using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioManager aud;
    [SerializeField] private GameSettings gs;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject bullet;
    [SerializeField] private BallBehavior ball;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public int ammo = 0;
    [SerializeField] public int health = 3;
    [SerializeField] private float moveSpeed;

    private bool explode = false;

    private float hoMove;

    // Start is called before the first frame update
    void Start()
    {
        aud = GameObject.Find("Music").GetComponent<AudioManager>();
        gs = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        anim = GetComponent<Animator>();
        ball = GameObject.Find("objBall").GetComponent<BallBehavior>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hoMove = Input.GetAxis("Horizontal") * moveSpeed;
        if(Input.GetButtonDown("Jump")){
            if(ball.onHold){
                ball.launchBall(Random.Range(45, 135));
            }else if(ammo > 0){
                ammo--;
                GameObject.Instantiate(bullet, this.transform);
                aud.PlayPlayerLaser();
                //shoot
            }
        }

        if(health < 0){
            //SceneManager.LoadScene("TheGame");
            gs.lose();
        }
        anim.SetInteger("ammo", ammo);
    }

    private void FixedUpdate() {
        if(!ball.onHold && !explode){
            rb.MovePosition(new Vector2(rb.position.x + hoMove *Time.fixedDeltaTime, rb.velocity.y));
        }
    }

    public void loseHealth(){
        aud.PlayExplode();
        anim.Play("playerExploded");
        ball.onHold = true;
        rb.velocity = Vector2.zero;
        //rb.position = new Vector2(0f, rb.position.y);
        health -= 1;
        explode = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy Bullet")){
            Destroy(other.gameObject);
            loseHealth();
        } else if(other.gameObject.CompareTag("Ammo")){
            aud.PlayPickup();
            ammo += 1;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            gs.lose();
        }
        if(other.gameObject.CompareTag("Ball")){
            aud.PlayBall();
        }
    }

    public void continueGame(){
        explode = false;
        rb.position = new Vector2(0f, rb.position.y);
        anim.Play("playerPaddle");
    }
}
