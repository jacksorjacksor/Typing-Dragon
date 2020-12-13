using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public Word word;

    public WordSpawner wordSpawner;
    public ScoreManager scoreManager;
    public GameManager gameManager;
    public WordManager wordManager;
    public WordGenerator wordGenerator;

    public HitAxis hitAxis;

    private bool hasActiveWord; // Checks if an active word is set
    public static bool gameover = false;

    public bool discoDragon = true; // Variable to state if we're doing the disco version (move this to GameManager)
    public bool letterCanBeTyped = true;
    public bool unlimitedWordsCheck = GameVariables.endlessDragonCheck;

    // Runs on game load
    private void Start() {
        AddWord();

        if (discoDragon){
            letterCanBeTyped = false;
        }
    }

    // Function to add words to the start list (called in Start())
    public void AddWord() {
        // Creates a word AND creates the prefab
        word = new Word(wordGenerator.GetRandomWord(unlimitedWordsCheck), wordSpawner.SpawnWord() );
        hasActiveWord = true;
    }

    // Function that is called when the player types a letter
    public void TypeLetter (char letter){
        if (gameover) {
            if (Input.GetKeyDown("space")){
                gameManager.RestartScene();
            }
        }
        
        // Define active word (in our case it'll just be the first letter) -> will instead do this IN ORDER of the list
        else if (hasActiveWord && letterCanBeTyped){
            if ( word.GetNextLetter() == letter ){
                word.TypeLetter();
                scoreManager.CorrectLetter();
            } else {
                word.WrongLetter();
                scoreManager.IncorrectLetter();
            }
        } else {
            // What happens if you should be able to type a letter but can't
            scoreManager.DiscoFail();
        }

        if (hasActiveWord && word.WordTyped() && letterCanBeTyped){   // When the word has been finished
            scoreManager.CompletedWord(word.word);
            if (gameover == false){
                hasActiveWord = false;
                Add();
            }
        }
    }
    void Add(){
        AddWord();   
    }

    
}

