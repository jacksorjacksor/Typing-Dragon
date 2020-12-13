using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circle;
    public GameObject lineKick;
    public GameObject lineSnare;

    public GameObject circleParent;
    public GameObject kickSnareParent;

    private float timePlayingThisScene;
    private float scale = 0.15f;

    public float beatTempoOriginal = 60f; // how fast the 

    public bool started = true;

    private float instantiationIntervals;
    private float nextActionTime; // Starts when the first

    // Start is called before the first frame update
    void Start()
    {   
        AudioManager.manager.PlayDownbeatDrums();
        instantiationIntervals = 1f;
        nextActionTime = instantiationIntervals;
        timePlayingThisScene = Time.time;
        Debug.Log("Time Playing: "+ timePlayingThisScene);
    }

    void Update () {
        // Debug.Log("Time:" + Time.time);
        if ((Time.time - timePlayingThisScene) > nextActionTime && WordManager.gameover != true) {
            SpriteGenerator();
            nextActionTime += instantiationIntervals;
            Debug.Log("Are you still making?");
        }
    }
             
    public void SpriteGenerator() {
        Debug.Log("Sprite Generator!");
        Invoke("MakeCircle",0f);
        Invoke("MakeLineKick",0f);
        Invoke("MakeLineSnare",instantiationIntervals/2);   // This has to start half way 
    }

    public void MakeCircle() {  
        GameObject newCircle = Instantiate(circle, new Vector3(0, 0, 0), Quaternion.identity);
        newCircle.transform.position = new Vector3(7.95f,-3f,0);
        newCircle.transform.localScale = (new Vector3(newCircle.transform.localScale.x * scale,newCircle.transform.localScale.y * scale,newCircle.transform.localScale.z * scale));
        newCircle.transform.parent = circleParent.transform;
    }

    public void MakeLineKick() {
        GameObject newLineKick = Instantiate(lineKick, new Vector3(0, 0, 0), Quaternion.identity);
        newLineKick.transform.position = new Vector3(7.95f,-3f,0);
        newLineKick.transform.localScale = (new Vector3(newLineKick.transform.localScale.x * scale,newLineKick.transform.localScale.y * scale,newLineKick.transform.localScale.z * scale));
        newLineKick.transform.parent = kickSnareParent.transform;
    }
    public void MakeLineSnare() {
        GameObject newLineSnare = Instantiate(lineSnare, new Vector3(0, 0, 0), Quaternion.identity);
        newLineSnare.transform.position = new Vector3(7.95f,-3f,0);
        newLineSnare.transform.localScale = (new Vector3(newLineSnare.transform.localScale.x * scale,newLineSnare.transform.localScale.y * scale,newLineSnare.transform.localScale.z * scale));
        newLineSnare.transform.parent = kickSnareParent.transform;
    }

    public void UpdateInstantiationIntervals(){
        instantiationIntervals=instantiationIntervals/1.1f;
    }
}
