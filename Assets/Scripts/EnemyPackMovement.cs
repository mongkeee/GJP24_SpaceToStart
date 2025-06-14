using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPackMovement : MonoBehaviour
{
    [SerializeField] private GameSettings gs;
    [SerializeField] private BallBehavior ball;
    [SerializeField] private int maxJumlahMusuh; 
    [SerializeField] private int jumlahMusuhMati = 0;
    [SerializeField] private float arah = 1;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        ball = GameObject.Find("objBall").GetComponent<BallBehavior>();

        maxJumlahMusuh = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ball.onHold){
            if(transform.position.x > 1.5f){
                arah = -1;
                transform.position = new Vector3(transform.position.x, transform.position.y - 5 * Time.deltaTime, 0);
            }else if(transform.position.x < -1.5f){
                arah = 1;
                transform.position = new Vector3(transform.position.x, transform.position.y - 5 * Time.deltaTime, 0);
            }
        }

        if(jumlahMusuhMati >= maxJumlahMusuh){
            gs.win();
        }

        if(transform.position.y < -7.3){
            gs.lose();
        }
    }

    private void FixedUpdate() {
        if(!ball.onHold){
            float moveX = (float)(maxJumlahMusuh + jumlahMusuhMati)/(float)maxJumlahMusuh * arah;
            transform.position = new Vector3(transform.position.x + moveX * Time.fixedDeltaTime, transform.position.y, 0);
        }
        
    }

    public void musuhMati(){
        jumlahMusuhMati += 1;
    }
}
