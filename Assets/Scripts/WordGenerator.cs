using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// The way we'll be establishing the random string to eventually populate a Word object

public class WordGenerator : MonoBehaviour
{     
    private List<string> wordListNew = new List<string>(){
        "basilisk",
        "bite",
        "blood",
        "burn",
        "cave",
        "claw", 
        "crispy",
        "crush",  
        "darkness",
        "delicious",
        "destroy",
        "dragon", 
        "draig",
        "dratini",
        "farosh",
        "fire",
        "flameo",
        "flying",
        "growl",
        "gold",
        "hydra",
        "incinerate",
        "lair",
        "marshmallow",
        "mountain",
        "night",
        "norbert",
        "puff",
        "rend",
        "roar",
        "scales",
        "slash",
        "smaug",
        "spikes",
        "teeth",
        "trogdor",
        "toothless",
        "wings",
        "yum",
        "zoom",
        };
        

    public string GetRandomWord (bool unlimitedWordsCheck)
    {
        Debug.Log("Word list count: " + wordListNew.Count);
        if (wordListNew.Count==0){
            // If the game list is exhausted:
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().PlayerWins();
            string randomWord = "";
            return randomWord;
        } else {
            int randomIndex = Random.Range(0, wordListNew.Count);
            string randomWord = wordListNew[randomIndex];
            // Removes word from list
            if (!unlimitedWordsCheck) {
                wordListNew.Remove(randomWord);
                }
            return randomWord;
        }
    }
}
