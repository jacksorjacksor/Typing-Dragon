// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// using System;
// using UnityEngine.UI;
// using TMPro;


// // Based on this "Turbo Makes Games" tutorial: https://www.youtube.com/watch?v=qc7J0iei3BU
// public class timerController : MonoBehaviour
// {
//     // Makes it a Singleton
//     // public static timerController instance;

//     public TextMeshProUGUI timeCounter;

//     private TimeSpan timePlaying;
//     private bool timerGoing = true;

//     private float elapsedTime;   

//     // Start is called before the first frame update
//     void Awake()
//     {  
//         instance = this;
//         Time.timeScale=1f;
//     }

//     private void Start() {
//         timeCounter.text = "Time: 00:00.00";
//         BeginTimer();
//     }

//     public void BeginTimer(){
//         timerGoing = true;
//         elapsedTime = 0f;

//         StartCoroutine(UpdateTimer());
//     }

//     public void EndTimer(){
//         timerGoing=false;
//         Time.timeScale=0;
//     }

//     private IEnumerator UpdateTimer(){
//         while (timerGoing){
//             elapsedTime += Time.deltaTime;
//             timePlaying = TimeSpan.FromSeconds(elapsedTime);
//             string timePlayingStr = "Time: " + timePlaying.ToString("m':'ss'.'f");
//             timeCounter.text = timePlayingStr;

//             yield return null;

//         }
//     }
// }
