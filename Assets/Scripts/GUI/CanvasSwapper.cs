using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwapper : MonoBehaviour {

    public Canvas mainMenu;
    public Canvas debugMenu;
    public Canvas howToPlay;
    public Canvas options;
    public Canvas gameplay;
    private GameManager gameManager;
    private SoundManager soundManager;

    public void SetupCanvas(GameManager gameManager, SoundManager soundManager)
    {
        this.gameManager = gameManager;
        this.soundManager = soundManager;
        SetCanvas("DEBUG");
    }

    public void SetCanvas(string menu)
    {
        mainMenu.gameObject.SetActive(false);
        debugMenu.gameObject.SetActive(false);
        howToPlay.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        gameplay.gameObject.SetActive(false);

        switch (menu)
        {
            case "MENU":
                mainMenu.gameObject.SetActive(true);
                gameManager.isPlaying = false;
                break;
            case "DEBUG":
                debugMenu.gameObject.SetActive(true);
                gameManager.isPlaying = false;
                break;
            case "HOWTOPLAY":
                howToPlay.gameObject.SetActive(true);
                break;
            case "OPTIONS":
                options.gameObject.SetActive(true);
                break;
            case "GAMEPLAY":
                gameplay.gameObject.SetActive(true);
                gameManager.isPlaying = true;
                break;
            default:
                Debug.LogErrorFormat("{0} isn't a valid canvas", menu);
                break;
        }
    }
    public void Btn_Menu()
    {
        SetCanvas("MENU");
        soundManager.PlaySound("SELECT");
        gameManager.RemoveControllers();
    }

    public void Btn_HowToPlay()
    {
        SetCanvas("HOWTOPLAY");
        soundManager.PlaySound("SELECT");
    }

    public void Btn_Options()
    {
        SetCanvas("OPTIONS");
        soundManager.PlaySound("SELECT");
    }

    public void Btn_PVP_Gameplay()
    {
        gameManager.mode = GameManager.GameMode.PVP;
        gameManager.SetupControllers();
        SetCanvas("GAMEPLAY");
        soundManager.PlaySound("SELECT");
    }

    public void Btn_PVC_Gameplay()
    {
        gameManager.mode = GameManager.GameMode.PVC;
        gameManager.SetupControllers();
        SetCanvas("GAMEPLAY");
        soundManager.PlaySound("SELECT");
    }

    public void Btn_CvC_Gameplay()
    {
        gameManager.mode = GameManager.GameMode.CVC;
        gameManager.SetupControllers();
        SetCanvas("GAMEPLAY");
        soundManager.PlaySound("SELECT");
    }

    // Allows the restart button to play the sound effect
    public void Btn_Restart()
    {
        soundManager.PlaySound("SELECT");
    }
}
