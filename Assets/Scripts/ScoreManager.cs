using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public int letters;
    public int words;
    public int errors;
   
    public string text;
    
    public int letterCap;
    public int wordCap;
    public int errorCap;
    
    public bool unlimitedWordsCheck;
    public bool onlyOneError;
    public bool letterCheck;
    public bool typeAllWordsCheck;
    public bool NoError;
    
    public string previousWord;

    public TextMeshProUGUI letterScoreDisplay;
    public TextMeshProUGUI wordScoreDisplay;
    public TextMeshProUGUI errorScoreDisplay;
    public TextMeshProUGUI messageScoreDisplay;
    public TextMeshProUGUI completedWord;
    public TextMeshProUGUI dragonMessageDisplay;

    public WordManager wordManager;
    public AudioManager audioManager;
    public timeManager timeManager;
    public objectMover objectMover;
    public CircleSpawner circleSpawner;

    private Color32 red = new Color(255,0,0,255);
    private Color32 white = new Color(255,255,255,0);
    private Color32 green = new Color(0,255,0,255);

    // Add something if we see the same name twice?*

    // Start is called before the first frame update
    void Start()
    {
        letters = 0;
        errors = 0;
        words = 0;
        
        previousWord = "";
        audioManager.PlayOneShot("startTyping");

        if(onlyOneError){
            errorCap = 1;
        } else {
            errorCap=3;
        }

        if(letterCheck){
            letterCap = 100;
        }
        
        if(!unlimitedWordsCheck){
            wordCap = 10;
        }

        if(typeAllWordsCheck){
            wordCap = 40;
        }

        UpdateAllScores();
        messageScoreDisplay.color=new Color32(255, 255, 255, 255);
        messageScoreDisplay.text = "Start typing!";
        completedWord.text = "";
        dragonMessageDisplay.text = "";

        GameVariables.firstTimeLoading = false;
    }

    public void UpdateAllScores() {
        if(letterCheck){
            letterScoreDisplay.text = letters.ToString() + "/100";
        } else {
        letterScoreDisplay.text = letters.ToString();

        }
        if(onlyOneError){
            errorScoreDisplay.text = errors.ToString() + "/1";
        } else if (NoError){
            errorScoreDisplay.text = "-";
        } else {
            errorScoreDisplay.text = errors.ToString() + "/3";
        }
        
        if(unlimitedWordsCheck){
            wordScoreDisplay.text = words.ToString() + "";
        } else if (typeAllWordsCheck) {
            wordScoreDisplay.text = words.ToString() + "/40";
        } else{
            wordScoreDisplay.text = words.ToString() + "/10";
        }
        
    }

    public void CorrectLetter() {
        letters++;
        UpdateAllScores();
        messageScoreDisplay.text = "";
        completedWord.text = "";
        dragonMessageDisplay.text = "";
        audioManager.PlayKeyclickSound();
        if(letterCheck && letters>=letterCap){
            PlayerWins();
        }
    }

    public void IncorrectLetter(){
        if (!NoError) {errors++;}
        UpdateAllScores();
        messageScoreDisplay.color=new Color32(255, 0, 0, 255);
        completedWord.text = "";
        dragonMessageDisplay.text = "";
        audioManager.PlayFailDrum();
        if (NoError){
            // Nothing happens
        } else if (onlyOneError) {
            GameOver();
        } else {
            switch (errors)
            {
                case 3:
                    GameOver();
                    break;
                case 2:
                    messageScoreDisplay.text = "Only one more chance!";
                    break;
                case 1:
                    messageScoreDisplay.text = "Oh no!";
                    break;
                case 0:
                    messageScoreDisplay.text = "It's OK! Try again!";
                    break;
            }
        }
    }

    public void CompletedWord(string word){
        words++;
        UpdateAllScores();
        ExtraMessage(word);
        messageScoreDisplay.color=new Color32(0, 255, 0, 255);
        messageScoreDisplay.text = "Word completed:" ;
        completedWord.color=new Color32(0, 255, 0, 255);
        completedWord.text = word;

        if(GameVariables.discoDragonCheck){
            objectMover.SetAndIncreaseTempo();
            circleSpawner.UpdateInstantiationIntervals();
        }

        if (!unlimitedWordsCheck && words == wordCap && !letterCheck){
            PlayerWins();
        } else {
            audioManager.PlayOneShot(word); // Stops the sound from playing on victory
        }
    }

    public void GameOver(){
        if (!WordManager.gameover){
            completedWord.text = "";
            dragonMessageDisplay.text = "";
            messageScoreDisplay.color = red;
            messageScoreDisplay.text = GameVariables.goalsOfTheGame;
            completedWord.text="<b>Game over!</b>";
            dragonMessageDisplay.text = "press spacebar to start again\n \npress escape to go to main menu";
            dragonMessageDisplay.color=red;
            completedWord.color=red;
            audioManager.PlayOneShot("gameOver");
            audioManager.PlayOneShot("failGong");
            WordManager.gameover = true;
            timeManager.EndTimer();
        } else {
            BackToMainMenu();
        }
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene(0);
    }

    public void PlayerWins(){
        messageScoreDisplay.text = GameVariables.goalsOfTheGame;
        completedWord.text = "Congratulations!!!";
        dragonMessageDisplay.text = "press spacebar to start again\n \npress escape to go to main menu";
        messageScoreDisplay.color=green;
        completedWord.color=green;
        dragonMessageDisplay.color=green;        
        audioManager.PlayOneShot("congratulations");
        audioManager.PlayOneShot("victoryGong");
        WordManager.gameover = true;
        timeManager.EndTimer();
    }

    public void DiscoFail() {
        if (!NoError) {errors++;}
        UpdateAllScores();
        messageScoreDisplay.color=new Color32(255, 0, 0, 255);
        completedWord.text = "";
        dragonMessageDisplay.text = "Disco Fail";
        audioManager.PlayFailDrum();
        switch (errors)
        {
            case 3:
                GameOver();
                break;
            case 2:
                messageScoreDisplay.text = "Only one more chance!";
                break;
            case 1:
                messageScoreDisplay.text = "Oh no!";
                break;
            case 0:
                messageScoreDisplay.text = "It's OK! Try again!";
                break;
        } 
    }

    // If I knew how I would change the wordList to be a wordDictionary
    public void ExtraMessage(string word){
        if (word == previousWord) {
            text = "...didn't I just see that one?";    
        } else {
        switch(word){
            case "yum":
                // play these as sound effects
                text = "yum yum for my tum tum!";
                break;
            case "claw":
                text = "all the better to claw you with!";
                break;
            case "teeth":
                text = "all the better to eat you with!";
                break;
            case "dragon":
                text = "hey that's me!";
                break;
            case "fire":
                text = "i taught it to burn!";
                break;
            case "draig":
                text = "cymru am byth!";
                break;
            case "gold":
                text = "it's all mine!";
                break;
            case "puff":
                text = "we're all magic, not just him!";
                break;
            case "dratini":
                text = "so cute!";
                break;
            case "hydra":
                text = "lernie?";
                break;
            default:
                text="";
                break;       
            }
        }
        dragonMessageDisplay.text = text;
        previousWord = word;
    }
}
