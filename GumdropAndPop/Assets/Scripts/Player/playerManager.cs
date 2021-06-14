using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public bool isDead = false;
    public scoreManager sm;
    
    void Start() {
        isDead = false;
    }
    
    public void Kill() {
        isDead = true;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Collectible") {
            // Increase score count by 100
            sm.AddScore(100);
            Destroy(col.gameObject);
        }
    }
}
