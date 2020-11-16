using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button playButton;
    public Button settingsButton;
    public Button creditButton;
    public Button exitButton;

    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject creditMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditMenu.SetActive(false);
        AudioManager.Instance.StopAll();
        AudioManager.Instance.Play("MenuMusic");
    }
    
    public void SwapMenu(string menu)
    {
        DisableAllMenu();
        switch (menu)
        {
            case "Main" :
                mainMenu.SetActive(true);
                break;
            case "Settings" : 
                settingsMenu.SetActive(true);
                break;
            case "Credits" :
                creditMenu.SetActive(true);
                break;
            default:
                Debug.Log("Wrong Argument");
                break;
        }
        AudioManager.Instance.Play("ButtonClick");
        
    }

    public void LauchGame()
    {
        AudioManager.Instance.Play("ButtonClick");
        AudioManager.Instance.Stop("MenuMusic");
        AudioManager.Instance.Play("GameMusic");
        SceneManager.LoadScene("Scenes/Game");
    }

    public void QuitGame()
    {
        AudioManager.Instance.Play("Goodbye");
        Application.Quit();
    }
    
    private void DisableAllMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        creditMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
