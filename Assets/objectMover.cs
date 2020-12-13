using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMover : MonoBehaviour
{
    public float beatTempoOriginal;
    public float beatTempo;

    void Start()
    {
        beatTempoOriginal = 120f;
        SetAndIncreaseTempo();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform){
            child.transform.position -= new Vector3(beatTempo*Time.deltaTime ,0f , 0f);
        }
    }

    // This needs to now be called on completed word!
    public void SetAndIncreaseTempo(){
        beatTempo = beatTempoOriginal/60f; // How fast it should move per second
        beatTempoOriginal = beatTempoOriginal*1.1f;
    }
}
