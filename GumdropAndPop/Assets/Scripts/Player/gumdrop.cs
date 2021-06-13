using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gumdrop : MonoBehaviour
{
    public GameObject pop;
    public float strength = 0.5f;
    public float minLength = 1.0f;
    public float maxLength = 3.0f;
    public float moveSpeed = 5.0f;
    public bool pulling = false;

    public scoreManager sm;

    bool justReleased = false;
    Rigidbody2D rb;
    Rigidbody2D rbPop;
    private Vector2 pullIn;
    private Vector2 attraction;

    // Start is called before the first frame update
    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        rbPop = pop.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float dist;
        Vector2 moveTo, dropDrag, popDrag;
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector2 dropPos = transform.position;
        Vector2 popPos = pop.transform.position;
        
        moveTo = dropPos + new Vector2(hor, ver);

        // Is player trying to pull
        if(Vector2.Distance(dropPos, moveTo) > 0.0f)
            pulling = true;
        else
            pulling = false;


        // Drag vectors meant to stop chars from moving during certain actions
        float xVel = Mathf.Lerp(rb.velocity.x, 0.0f, Time.deltaTime * strength*5.0f);
        float yVel = Mathf.Lerp(rb.velocity.y, 0.0f, Time.deltaTime * strength*5.0f);
        dropDrag = new Vector2(xVel, yVel);

        float xVelPop = Mathf.Lerp(rbPop.velocity.x, 0.0f, Time.deltaTime * strength*5.0f);
        float yVelPop = Mathf.Lerp(rbPop.velocity.y, 0.0f, Time.deltaTime * strength*5.0f);
        popDrag = new Vector2(xVelPop, yVelPop);


        dist = Vector2.Distance(dropPos, popPos);
        if(pulling) {

            // Stop to make it easier to aim
            rb.velocity = dropDrag;
            //rbPop.velocity = popDrag;

            // Give control of Drop
            if(Vector2.Distance(popPos, moveTo) < maxLength) {
                transform.position = Vector3.MoveTowards(dropPos, moveTo, moveSpeed * Time.deltaTime);
            }

            justReleased = true;

        } else if(!pulling) {
            if(justReleased) {
                rb.AddForce( (popPos - dropPos) * dist, ForceMode2D.Impulse);
                justReleased = false;
            }
            
            //Don't pull if player tries to move
            if(dist > minLength) {
                // Attraction between Drop and Pop when too far from each other
                rb.AddForce( (popPos - dropPos) * dist * strength);
                rbPop.AddForce( (dropPos - popPos) * dist * strength * 0.25f);
            } else {
                // Stop if they are close enough
                rb.velocity = dropDrag;
                rbPop.velocity = popDrag;
            }
        }   
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Collectible") {
            // Increase score count by 100
            sm.AddScore(100);
        }
    }
}
