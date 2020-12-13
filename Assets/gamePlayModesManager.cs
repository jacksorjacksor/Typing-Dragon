using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamePlayModesManager : MonoBehaviour
{
    public TextMeshProUGUI goals;
    public TextMeshProUGUI conflict;
    public TextMeshProUGUI discoDragon;
    public TextMeshProUGUI discoDragonDesc;
    public GameObject discoDragonError;
    public TextMeshProUGUI endlessDragon;
    public TextMeshProUGUI endlessDragonDesc;
    public GameObject endlessDragonError;
    public TextMeshProUGUI glassDragon;
    public TextMeshProUGUI glassDragonDesc;
    public GameObject glassDragonError;
    public TextMeshProUGUI immortalDragon;
    public TextMeshProUGUI immortalDragonDesc;
    public GameObject immortalDragonError;
    public TextMeshProUGUI speedDragon;
    public TextMeshProUGUI speedDragonDesc;
    public GameObject speedDragonError;
    public TextMeshProUGUI postalDragon;
    public TextMeshProUGUI postalDragonDesc;
    public GameObject postalDragonError;
    public TextMeshProUGUI libraryDragon;
    public TextMeshProUGUI libraryDragonDesc;
    public GameObject libraryDragonError; 
    public TextMeshProUGUI goalsSecondLevel;

    public Color32 white = new Color32(255,255,255,255);
    public Color32 green = new Color32(0,255,0,255);
    public Color32 red = new Color32(255,0,0,255);

    private string words;
    private int letters;
    private int errors;
    private int timer;
    private string goalsText="";
    private string discoText="";
    private string errorSuffix;

    private void Start() {
        words = "10";
        letters = 0;
        errors = 3;
        timer = 0;
        goalsText = "Goal:";
        
        conflict.text = "";
        initialColorSetting();
        disableAllErrors();
        RefreshGoals();
    }

    public void RefreshGoals(){
        goals.text = goalsText;
        if(words.Length>0 && letters!=100){ // Don't show words if there are 100 letters ("Post Dragon")
            goals.text = goals.text + " " + words + " words";}
        if(letters>0){goals.text = goals.text + " " + letters + " letters";} 
        
        if(errors>0){
            if(errors==1){errorSuffix="";}else{errorSuffix="s";}
            goals.text = goals.text + " within " + errors + " error" + errorSuffix;}
        if(timer>0){goals.text = goals.text + " within " + timer + " seconds";}
        if(discoText.Length>0){goals.text = goals.text + " " + discoText;}
    }
    
    public void gamePlayModesScript(){
        // Refreshes the conflix text
        if(Input.anyKeyDown){
            conflict.text="";
            disableAllErrors();
        }
        if(Input.GetKeyDown("d")){
            // DISCO DRAGON
            if(GameVariables.speedDragonCheck){
                conflict.text="Cannot have Disco Dragon at same time as Speed Dragon";
                AudioManager.manager.PlayFailDrum();
                discoDragonError.SetActive(true);
                speedDragonError.SetActive(true);
            } else {
                
                textColorChanger(discoDragon,discoDragonDesc);

                // Changes the variable
                if(GameVariables.discoDragonCheck){
                    GameVariables.discoDragonCheck = !GameVariables.discoDragonCheck;
                } else {
                    GameVariables.discoDragonCheck = true;
                    
                }
                // Goal text:
                if(GameVariables.discoDragonCheck){
                    AudioManager.manager.PlayOneShot("Disco");
                    discoText = "(in rhythm!)";
                } else {
                    discoText = "";
                }
                RefreshGoals();
            }

        } else if (Input.GetKeyDown("e")){
            // ENDLESS DRAGON

            // Check if Library Dragon already activated
            if(GameVariables.libraryDragonCheck){
                conflict.text="Cannot have Endless Dragon at same time as Library Dragon";
                endlessDragonError.SetActive(true);
                libraryDragonError.SetActive(true);
                AudioManager.manager.PlayFailDrum();
            } else if (GameVariables.postalDragonCheck){
                conflict.text="Cannot have Endless Dragon at same time as Postal Dragon";
                endlessDragonError.SetActive(true);
                postalDragonError.SetActive(true);    
                AudioManager.manager.PlayFailDrum();       
            } else {
                // Endless Dragon
                textColorChanger(endlessDragon,endlessDragonDesc);

                // Changes the variable
                if(GameVariables.endlessDragonCheck){
                    GameVariables.endlessDragonCheck = !GameVariables.endlessDragonCheck;
                } else {
                    GameVariables.endlessDragonCheck = true;
                }

                // Goal text:
                if(GameVariables.endlessDragonCheck){
                    AudioManager.manager.PlayOneShot("Endless");
                    words = "unlimited";
                    letters = 0;
                } else {
                    // Check if Library dragon
                    if(GameVariables.libraryDragonCheck){
                        words = "40";
                    } else {
                        words = "10";
                    }
                }
                RefreshGoals();
            }

        } else if (Input.GetKeyDown("g")){
            // GLASS DRAGON

            // Check if Library Dragon already activated
            if(GameVariables.immortalDragonCheck){
                conflict.text="Cannot have Glass Dragon at same time as Immortal Dragon";
                glassDragonError.SetActive(true);
                immortalDragonError.SetActive(true);
                AudioManager.manager.PlayFailDrum();
            } else {
                // Glass Dragon
                textColorChanger(glassDragon,glassDragonDesc);

                if(GameVariables.glassDragonCheck){
                    GameVariables.glassDragonCheck = !GameVariables.glassDragonCheck;
                } else {
                    
                    GameVariables.glassDragonCheck = true;
                }

                // Goal text:
                if(GameVariables.glassDragonCheck){
                    
                AudioManager.manager.PlayOneShot("Glass");
                    errors = 1;
                } else {
                    errors = 3; 
                }
                RefreshGoals();
            }
        } else if (Input.GetKeyDown("i")){
            // IMMORTAL DRAGON

            // Check if Glass Dragon
            if(GameVariables.glassDragonCheck){
                conflict.text="Cannot have Immortal Dragon at same time as Glass Dragon";
                immortalDragonError.SetActive(true);
                glassDragonError.SetActive(true);
                AudioManager.manager.PlayFailDrum();
            } else {

                textColorChanger(immortalDragon,immortalDragonDesc);

                if(GameVariables.immortalDragonCheck){
                    GameVariables.immortalDragonCheck = !GameVariables.immortalDragonCheck;
                } else {
                    
                    GameVariables.immortalDragonCheck = true;
                }

                // Goal text:
                if(GameVariables.immortalDragonCheck){
                    
                AudioManager.manager.PlayOneShot("Immortal");
                    errors = 0;
                } else {
                    errors = 3; 
                }
                RefreshGoals();

            }

        } else if (Input.GetKeyDown("s")){
            // Speed Dragon

            // Check if Disco Dragon
            if(GameVariables.discoDragonCheck){
                conflict.text="Cannot have Speed Dragon at same time as Disco Dragon";
                discoDragonError.SetActive(true);
                speedDragonError.SetActive(true);
                AudioManager.manager.PlayFailDrum();
            } else {
                
                textColorChanger(speedDragon,speedDragonDesc);
                

                if(GameVariables.speedDragonCheck){
                    GameVariables.speedDragonCheck = !GameVariables.speedDragonCheck;
                } else {
                    
                    GameVariables.speedDragonCheck = true;
                }

                // Goal text:
                if(GameVariables.speedDragonCheck){
                    AudioManager.manager.PlayOneShot("Speed");
                    timer = 30;
                } else {
                    timer = 0; 
                }
                RefreshGoals();
            }

        } else if (Input.GetKeyDown("p")){
            // POSTAL DRAGON
            
            // Check if Library Dragon
            if(GameVariables.libraryDragonCheck){
                conflict.text="Cannot have Postal Dragon at same time as Library Dragon";
                postalDragonError.SetActive(true);
                libraryDragonError.SetActive(true);
                AudioManager.manager.PlayFailDrum();
            } else if (GameVariables.endlessDragonCheck){
                conflict.text="Cannot have Postal Dragon at same time as Endless Dragon";
                postalDragonError.SetActive(true);
                endlessDragonError.SetActive(true);     
                AudioManager.manager.PlayFailDrum();          
            } else {
                textColorChanger(postalDragon,postalDragonDesc);

                if(GameVariables.postalDragonCheck){
                    GameVariables.postalDragonCheck = !GameVariables.postalDragonCheck;
                } else {
                    GameVariables.postalDragonCheck = true;
                }

                // Goal text:
                if(GameVariables.postalDragonCheck){
                    AudioManager.manager.PlayOneShot("Postal");
                    letters = 100;
                } else {
                    letters = 0; 
                }
                RefreshGoals();

            }  

        } else if (Input.GetKeyDown("l")){
            // Library Dragon

            // Check if Postal Dragon
            if(GameVariables.postalDragonCheck){
                conflict.text="Cannot have Library Dragon at same time as Postal Dragon";
                postalDragonError.SetActive(true);
                libraryDragonError.SetActive(true);
                AudioManager.manager.PlayFailDrum();
            } else if(GameVariables.endlessDragonCheck) {
                conflict.text="Cannot have Endless Dragon at same time as Postal Dragon";
                endlessDragonError.SetActive(true);
                libraryDragonError.SetActive(true);
                AudioManager.manager.PlayFailDrum();
            } else {
                textColorChanger(libraryDragon,libraryDragonDesc);

                if(GameVariables.libraryDragonCheck){
                    GameVariables.libraryDragonCheck = !GameVariables.libraryDragonCheck;
                } else {
                    GameVariables.libraryDragonCheck = true;
                }

                // Goal text:
                if(GameVariables.libraryDragonCheck){
                    AudioManager.manager.PlayOneShot("Library");
                    words = "40";
                } else {
                    words = "10"; 
                }
                RefreshGoals();

            }
        }

        GameVariables.goalsOfTheGame = goals.text;
        goalsSecondLevel.text = GameVariables.goalsOfTheGame;
    }

    private void textColorChanger(TextMeshProUGUI main, TextMeshProUGUI desc){
        if(main.color==white){
            main.color=green;
            desc.color=green;

        } else {
            main.color=white;
            desc.color=white;           
        }
    }

    private void initialColorSetting(){
        textColorChangerInitial(discoDragon,discoDragonDesc,GameVariables.discoDragonCheck);
        textColorChangerInitial(endlessDragon,endlessDragonDesc,GameVariables.endlessDragonCheck);
        textColorChangerInitial(glassDragon,glassDragonDesc,GameVariables.glassDragonCheck);
        textColorChangerInitial(immortalDragon,immortalDragonDesc,GameVariables.immortalDragonCheck);
        textColorChangerInitial(speedDragon,speedDragonDesc,GameVariables.speedDragonCheck);
        textColorChangerInitial(postalDragon,postalDragonDesc,GameVariables.postalDragonCheck);
        textColorChangerInitial(libraryDragon,libraryDragonDesc,GameVariables.libraryDragonCheck);
    }

    private void disableAllErrors(){
        // discoDragonError.text = "";
        // endlessDragonError.text = "";
        // glassDragonError.text = "";
        // immortalDragonError.text = "";
        // speedDragonError.text = "";
        // postalDragonError.text = "";
        // libraryDragonError.text = ""; 

        discoDragonError.SetActive(false);
        endlessDragonError.SetActive(false);
        glassDragonError.SetActive(false);
        immortalDragonError.SetActive(false);
        speedDragonError.SetActive(false);
        postalDragonError.SetActive(false);
        libraryDragonError.SetActive(false);         
    }

    private void textColorChangerInitial(TextMeshProUGUI main, TextMeshProUGUI desc, bool check){
        if(check){
            main.color=green;
            desc.color=green;

        } else {
            main.color=white;
            desc.color=white;           
        }
    }
}
