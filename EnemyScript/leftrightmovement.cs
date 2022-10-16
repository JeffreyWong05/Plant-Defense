using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftrightmovement : MonoBehaviour 
{
    public float speed = 2f;
    private Rigidbody2D rb;
    private Transform player;

    void Start(){
        player = GameObject.FindWithTag("Player").transform; 
        rb = this.GetComponent<Rigidbody2D>(); 
    }
    
    private void FixedUpdate() {
        
        if(player == null) {
            return;
        }

        if(transform.position.x > player.position.x)
        {
            transform.localScale = new Vector3(2f, 2f, 1f);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        
        if(transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(-2f, 2f, 1f);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }
}

    

