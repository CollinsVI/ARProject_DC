using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject tutorialOverlay; 

    
    public void StartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    
    public void ShowTutorial()
    {
        
        tutorialOverlay.SetActive(true); 

    }

    
    public void HideTutorial()
    {

        tutorialOverlay.SetActive(false); 
        //Add the back button ASAP

    }

    
    public void QuitGame()
    {
        
        Application.Quit();

    }
}
