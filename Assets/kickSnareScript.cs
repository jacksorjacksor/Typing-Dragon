using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kickSnareScript : MonoBehaviour
{
    public float beatTempoOriginal = 120f;
    public float beatTempo;

    void Start()
    {
        beatTempo = beatTempoOriginal/60f; // How fast it should move per second
        
    }

    void Update()
    {
        transform.position -= new Vector3(beatTempo*Time.deltaTime ,0f , 0f);
        // If the transform position is OOB then destroy
        if (transform.position.x <= -10f){
            Destroy(gameObject);
        }
    }
}
