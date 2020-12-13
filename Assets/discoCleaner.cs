using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class discoCleaner : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -8f || (transform.position.x > 8f && WordManager.gameover)){
            Destroy(gameObject);
        }
    }

}
