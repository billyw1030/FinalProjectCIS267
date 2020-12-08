using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSettings : MonoBehaviour
{
    MainGameManagerScript gameManagerScript;

    [SerializeField] private GameObject mainMenuSettings;

    //[SerializeField] private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<MainGameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateMainMenuSettings()
    {
        mainMenuSettings.SetActive(true);
        
    }

    public void DeactivateMainMenuSettings()
    {
        mainMenuSettings.SetActive(false);
        
    }

    public void cheatsEnabled()
    {
        gameManagerScript.setCheatStatus(true);
        DeactivateMainMenuSettings();
    }

    public void cheatsDisabled()
    {
        gameManagerScript.setCheatStatus(false);
        DeactivateMainMenuSettings();
    }

    public void backButton()
    {
        DeactivateMainMenuSettings();
    }
}
