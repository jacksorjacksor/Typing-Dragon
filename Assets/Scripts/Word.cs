using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The main Word class for the Word objects

[System.Serializable] // Allows all variables to show up in the Inspector
public class Word
{
    public string word;
    private int typeIndex; // The index of the letter of the word we're on
    public int lengthOfWord;

    WordDisplay display;

    // Constructor - what happens when a new Word object is made ("set-up stuff")
    public Word (string _word, WordDisplay _display) {
        word = _word;
        typeIndex = 0;
        lengthOfWord = _word.Length;
        display = _display;
        display.SetWord(word);
    }

    // Sets the letter of the word based on the index
    public char GetNextLetter(){
        return word[typeIndex];
    }
    
    // When the correct letter is typed
    public void TypeLetter(){
        typeIndex++;    // Adds one to the index of the letter of the word
        display.AddLetter(word, typeIndex);
    }


    // Wrong letter
    public void WrongLetter(){
        display.WrongLetter();
    }

    // When the full word has been typed
    public bool WordTyped(){
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped){
            display.RemoveWord(word);
        }
        return wordTyped;
    }
}
