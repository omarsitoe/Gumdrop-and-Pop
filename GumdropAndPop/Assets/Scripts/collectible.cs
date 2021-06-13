using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Collectible") {
            //Avoid duplicates
            Destroy(gameObject);
        }
    }
}
