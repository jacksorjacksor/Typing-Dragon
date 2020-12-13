using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAxis : MonoBehaviour
{
    public WordManager wordManager;
    public AudioManager audioManager;

    // When the hit axis enters a trigger
    private void OnTriggerEnter2D(Collider2D other) {
        // If it's "MusicTag" play the downbeat
        if(other.tag == "MusicTag"){
            audioManager.PlayDownbeatDrums();
        // If it's "MusicTagOffbeat" play the offbeat
        } else if (other.tag == "MusicTagOffbeat") {
            audioManager.PlayOffbeatDrums();
        // If it's a circle then you typed notes are successess
        } else if (other.tag == "Circle"){
            wordManager.letterCanBeTyped = true;
        }
    }

    // When the hit axis leaves a trigger
    private void OnTriggerExit2D(Collider2D other) {
        // If it's a circle (and ONLY a circle) then you typed notes are errors
        if(other.tag == "Circle"){
            wordManager.letterCanBeTyped = false;
        }
    }
}
