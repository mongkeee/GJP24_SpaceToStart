using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private AudioManager aud;
    [SerializeField] private GameSettings gs;
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private EnemyPackMovement packMusuh;
    [SerializeField] private BallBehavior ball;
    [SerializeField] private GameObject pelor;
    [SerializeField] private GameObject pickupAmmo;
    [SerializeField] private GameObject meledak;
    [SerializeField] private int maxHealth;
    [SerializeField] private bool isShootyType = false;
    private int health;
    private float shootTimer = 0;
    [SerializeField] private int scoreValue = 20;
    // Start is called before the first frame update
    void Start()
    {
        aud = GameObject.Find("Music").GetComponent<AudioManager>();
        gs = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        rend = GetComponent<SpriteRenderer>();
        packMusuh = GameObject.Find("objEnemyPack").GetComponent<EnemyPackMovement>();
        ball = GameObject.Find("objBall").GetComponent<BallBehavior>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            aud.PlayExplode();
            GameObject.Instantiate(meledak, this.transform);
            Destroy(gameObject);
            gs.addScore(scoreValue);
            packMusuh.musuhMati();
            int rng = Random.Range(0,10);
            if(rng < 3){
                GameObject.Instantiate(pickupAmmo, this.transform);
            }
        } else{
            rend.color = new Color(1f,1f,1f,(float)health/(float)maxHealth);
        }

        if(isShootyType && !ball.onHold){
            if(shootTimer > 2f){
                int rng = Random.Range(1, 100);
                if(rng < 10){
                    GameObject.Instantiate(pelor, this.transform);
                    aud.PlayLaserEnemy();
                }
                shootTimer = 0;
            }else{
                shootTimer += Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ball")){
            health -= 1;
            aud.PlayBall();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player Bullet")){
            health -= 2;
            Destroy(other.gameObject);
        }
    }
}
