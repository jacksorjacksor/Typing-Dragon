using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;
using TMPro;


// Based on this "Turbo Makes Games" tutorial: https://www.youtube.com/watch?v=qc7J0iei3BU
public class timeManager : MonoBehaviour
{
    // Makes it a Singleton
    public static timeManager instance;

    public TextMeshProUGUI timeCounter;
    public GameManager gameManager;
    public ScoreManager scoreManager;
    public AudioManager audioManager;

    private TimeSpan timePlaying;
    private bool timerGoing = true;

    private float elapsedTime; 
    private float startTime; 

    public float timeDeadline = 30f;
    public float timeWarning = 25f;

    public bool timeAttack;
    private bool timpPlaying;


    // Start is called before the first frame update
    void Awake()
    {  
        instance = this;
        Time.timeScale=1f;
        timpPlaying=false;
    }

    private void Start() {
        timeCounter.text = "Time: 00:00.00";
        BeginTimer();
    }

    public void BeginTimer(){
        timerGoing = true;
        elapsedTime = 0f;
        if(timeAttack){            
            StartCoroutine(UpdateTimerTimeAttack());
        } else {
            StartCoroutine(UpdateTimer());
        }
    }

    public void EndTimer(){
        timerGoing=false;
        Time.timeScale=0;   // Stops time!
    }

    private IEnumerator UpdateTimer(){
        while (timerGoing){
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("m':'ss'.'f");
            timeCounter.text = timePlayingStr;
            if(timeAttack){
                if(elapsedTime<=5f){
                    timeCounter.color=new Color32(255, 0, 0, 255);
                    if(elapsedTime>=10f){
                        scoreManager.GameOver();
                    }
                }
            }
            yield return null; 
        }
    }

    private IEnumerator UpdateTimerTimeAttack(){
        while (timerGoing){
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("m':'ss'.'f") + " / 00:30.00";
            timeCounter.text = timePlayingStr;
            if(timeAttack){
                if(elapsedTime>=timeWarning){
                    // Play a five second timp swell
                    timeCounter.color=new Color32(255, 0, 0, 255);
                    if(!timpPlaying){
                        audioManager.PlayOneShot("timeCountDownTimp");
                        InvokeRepeating("PlayTimeAttackCountdown",0f,1f);
                        timpPlaying=true;
                    }
                    if(elapsedTime>=timeDeadline){
                        scoreManager.GameOver();
                    }
                }
            }
            yield return null; 
        }
    }

    public void PlayTimeAttackCountdown(){
        audioManager.PlayTimeAttackCountdown();
    }

}
