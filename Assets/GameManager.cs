using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Keeping these so we can SEE the values
    public bool discoDragonCheck;       // Disco Dragon = Rhythm game
    public bool glassDragonCheck;       // Glass Dragon = Only one life
    public bool speedDragonCheck ;       // Speed Dragon = Time limit
    public bool unlimitedWordsCheck;    // Endless Dragon = No word limit
    public bool letterDragonCheck;      // Postal Dragon = only cares about letters
    public bool typeAllWordsCheck;      // Encyclopedic Dragon = type out all words
    public bool noErrorCheck;           // Training Dragon = no errors

    public CircleSpawner circleSpawner;
    public GameObject discoDragonAssets;
    public WordManager wordManager;
    public ScoreManager scoreManager;
    public GameObject wordGeneratorObject;
    private WordGenerator wordGenerator;
    public timeManager timeManager;

    // Move the timer to here (to control the TimerDisplay)

    private void Awake() {
        DiscoDragon(GameVariables.discoDragonCheck); 
        GlassDragon(GameVariables.glassDragonCheck);
        LetterDragon(GameVariables.postalDragonCheck);
        SpeedDragon(GameVariables.speedDragonCheck);
        EndlessDragon(GameVariables.endlessDragonCheck);
        LibraryDragon(GameVariables.libraryDragonCheck);
        ImmortalDragon(GameVariables.immortalDragonCheck);
        WordManager.gameover=false;
    }

    private void Update() {
        if(Input.GetKeyDown("escape")){
            scoreManager.GameOver();
        }
    }

    public void RestartScene() {
        SceneManager.LoadScene(1);
    }

    private void DiscoDragon(bool state){
        // Disable scripts 
        circleSpawner.GetComponent<CircleSpawner>().enabled = state;
        discoDragonAssets.SetActive(state);
        wordManager.discoDragon=state;
    }

    private void GlassDragon(bool state){
        scoreManager.onlyOneError = state;
    }

    private void LetterDragon(bool state){
        scoreManager.letterCheck = state;
    }

    private void SpeedDragon(bool state){
        timeManager.timeAttack = state;
    }

    private void EndlessDragon(bool state){
        wordManager.unlimitedWordsCheck = state;
        scoreManager.unlimitedWordsCheck = state;
    }

    private void LibraryDragon(bool state){
        scoreManager.typeAllWordsCheck = state;
    }

    private void ImmortalDragon(bool state){
        scoreManager.NoError = state;
    }
}
