using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float arahV;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 7 ||transform.position.y < -7){
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        transform.position = transform.position + Vector3.up * arahV * speed * Time.fixedDeltaTime;
    }
}
