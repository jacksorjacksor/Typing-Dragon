using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScreenManager : MonoBehaviour
{    
    public GameObject firstLevelMenu;
    public GameObject secondLevelMenu;
    public GameObject gameplayModesMenu;
    public GameObject aboutMenu;
    public GameObject creditsMenu;
    public gamePlayModesManager gamePlayModesManager;
    public GameObject quitPanel;

    private GameObject activeMenu;

    void Start(){
        if(GameVariables.firstTimeLoading){
            AudioManager.manager.PlayOneShot("TypingDragon");
            AudioManager.manager.PlayOneShot("Gong");
            GameVariables.firstTimeLoading = false;
        }
        activeMenu = firstLevelMenu;
        DeactivateAllPages();
    }

    private void DeactivateAllPages(){
        firstLevelMenu.SetActive(false);
        secondLevelMenu.SetActive(false);
        aboutMenu.SetActive(false);
        gameplayModesMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        activeMenu.SetActive(true);
        // When you press any key play the click sound
        if(Input.anyKeyDown){
            AudioManager.manager.PlayKeyclickSound();
        }

        if (Input.GetKeyDown("space")){
            if(quitPanel.activeSelf){
                Application.Quit();
            }
        }

        if (Input.GetKeyDown("escape")){
            quitPanel.SetActive(!quitPanel.activeSelf);
            DeactivateAllPages();
            if(!quitPanel.activeSelf){
                activeMenu.SetActive(true);
            }
        }

        if(activeMenu==firstLevelMenu){
            // Make the SetActives into a script
            if (Input.GetKeyDown("space")){
                activeMenu.SetActive(false);
                activeMenu = secondLevelMenu;
            }

        } else if (activeMenu==secondLevelMenu) {
            if (Input.GetKeyDown("a")){
                activeMenu.SetActive(false);
                activeMenu = aboutMenu;
            
            } else if (Input.GetKeyDown("g")){
                activeMenu.SetActive(false);
                activeMenu = gameplayModesMenu;           
            
            } else if (Input.GetKeyDown("c")){
                activeMenu.SetActive(false);
                activeMenu = creditsMenu;            
            
            } else if (Input.GetKeyDown("p") | Input.GetKeyDown("space")){
                // Active choice to have p OR space be start playing as
                // it felt more natural
                Debug.Log("Play the game!");
                SceneManager.LoadScene("MainGame");
            }

        } else if (activeMenu==aboutMenu){
            if (Input.GetKeyDown("space")){
                activeMenu.SetActive(false);
                activeMenu = secondLevelMenu;
            }

        } else if (activeMenu==gameplayModesMenu){
            if (Input.GetKeyDown("space")){
                activeMenu.SetActive(false);
                activeMenu = secondLevelMenu;
            } else {
                gamePlayModesManager.gamePlayModesScript();
            }

        } else if (activeMenu==creditsMenu){
            if (Input.GetKeyDown("space")){
                activeMenu.SetActive(false);
                activeMenu = secondLevelMenu;
                
            } 
        }
    }
}

