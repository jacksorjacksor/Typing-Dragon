using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    string ulTagStart = "<u>";
    string ulTagEnd = "</u>";


    public TextMeshProUGUI text;

    public void SetWord (string word){
        text.text = ulTagStart + word[0] + ulTagEnd + new string('-',word.Length-1);
    }

    public void WrongLetter (){
        text.color=new Color32(255, 0, 0, 255);
    }

    public void AddLetter (string word, int typeIndex){
        // AWFUL code but it works
        text.color=new Color32(255, 255, 255, 255);
        if (typeIndex<word.Length){
            string focusLetter = ulTagStart+word.Substring(typeIndex,1)+ulTagEnd;
            text.text = word.Substring(0,typeIndex)+focusLetter+ new string('-',word.Length-typeIndex-1);
        }
    }

    public void RemoveWord (string word){
        Destroy(gameObject); 
    }

}
