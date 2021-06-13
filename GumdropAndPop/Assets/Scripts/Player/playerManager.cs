using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public bool isDead = false;
    
    void Start() {
        isDead = false;
    }
    
    void Kill() {
        isDead = true;
        Destroy(gameObject);
    }
}
