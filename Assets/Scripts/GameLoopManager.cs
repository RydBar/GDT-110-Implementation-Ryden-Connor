using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine.Rendering;
using System;
using UnityEngine.InputSystem.XR.Haptics;

public class GameLoopManager : MonoBehaviour
{
    //State Machine
    public enum GameState
    {
        Menu,
        Playing,
        Paused,
        GameOver,
        Victory
    }

    public GameState currentState = GameState.Menu;

    //the TextMeshPros get dragged into the public variables in the editor
    public TextMeshProUGUI statsDisplay;
    public TextMeshProUGUI stateDisplay;
    public TextMeshProUGUI instructionsDisplay;

    private int frameCount;
    private float currentFPS;
    public int score;
    private float gameplayTime;
    public int scoreToWin = 5;
    //private float currentTimeScale;

    public GameObject playerObject;


    void Start()
    {
        frameCount = 0;
    }

    void Update()
    {

        //Switch statement keeps firing the function corresponding to the current state
        switch (currentState)
        {
            case GameState.Menu:
                UpdateMenuState();
                break;
            case GameState.Playing:
                UpdatePlayingState();
                break;
            case GameState.Paused:
                UpdatePausedState();
                break;
            case GameState.GameOver:
                UpdateGameOverState();
                break;
            case GameState.Victory:
                UpdateVictoryState();
                break;
        }

        DisplayStats();
    }


    void DisplayStats()
    {

        if (statsDisplay != null) //statS
        {
            string stats = "";

            stats += "Frame " + frameCount + "\n";

            stats += "FPS: " + currentFPS.ToString("F1") + "\n";

            stats += "Score: " + score + "\n";

            stats += "Gameplay Time: " + gameplayTime + "\n";

            stats += "Elapsed Time: " + Time.time.ToString("F1") + "\n";

            statsDisplay.text = stats;
        }

        if (stateDisplay != null) //statE
        {
            stateDisplay.text = "STATE: " + currentState.ToString();
        }

        if (instructionsDisplay != null)
        {
            string instructions = "";

            switch (currentState)
            {
                case GameState.Menu:
                    instructions = "Press SPACE to Start";
                    break;
                case GameState.Playing:
                    instructions = "W/A/S/D or Arrow Keys to move.\nCollect " + scoreToWin + " coins to win!"
                        + "\nPress ESC to Pause";
                    break;
                case GameState.Paused:
                    instructions = "Press ESC to Resume | Press Q to Quit to Menu";
                    break;
                case GameState.GameOver:
                    instructions = "GAME OVER!\nPress R to Retry | Press M to Quit to Menu";
                    break;
                case GameState.Victory:
                    instructions = "YOU GOT ALL ITEMS AND WON!!!\nPress M to Quit to Menu";
                    break;
            }

            instructionsDisplay.text = instructions;
        }

    }

    // ============ UPDATE STATE FUNCTIONS =============
    void UpdateMenuState()
    {
        playerObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Space)) //Space pressed
        {
            currentState = GameState.Playing;
            score = 0;
            gameplayTime = 0f;
            Debug.Log("State changed to: " + currentState);
            playerObject.GetComponent<PlayerHealth>().ResetHealth();
            playerObject.SetActive(true);
        }
    }
    void UpdatePlayingState()
    {

        Time.timeScale = 1f;

        frameCount++;
        currentFPS = 1 / Time.deltaTime;
        gameplayTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape)) //Esc pressed
        {
            currentState = GameState.Paused;
            Debug.Log("State changed to: " + currentState);
        }

        if (Input.GetKeyDown(KeyCode.G)) //G pressed
        {
            currentState = GameState.GameOver;
            Debug.Log("State changed to: " + currentState);
        }

        if (score >= scoreToWin)
        {
            currentState = GameState.Victory;
        }
    }
    void UpdatePausedState()
    {
        Time.timeScale = 0f;

        if (Input.GetKeyDown(KeyCode.Escape)) //Esc pressed
        {
            currentState = GameState.Playing;
            Debug.Log("State changed to: " + currentState);
        }

        if (Input.GetKeyDown(KeyCode.Q)) //Q pressed
        {
            currentState = GameState.Menu;
            Debug.Log("State changed to: " + currentState);
            playerObject.SetActive(false);
        }
    }
    void UpdateGameOverState()
    {
        playerObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.R)) //R pressed
        {
            currentState = GameState.Playing;
            score = 0;
            gameplayTime = 0f;
            Debug.Log("State changed to: " + currentState);
            playerObject.GetComponent<PlayerHealth>().ResetHealth();
            playerObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.M)) //M pressed
        {
            currentState = GameState.Menu;
            Debug.Log("State changed to: " + currentState);
            playerObject.SetActive(false);

        }
    }

    void UpdateVictoryState()
    {
        playerObject.SetActive(false);
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            currentState = GameState.Menu;
        }
    }

    //void HandleInput()
    //{

    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        Time.timeScale = 0.5f;
    //        currentTimeScale = 0.5f;
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        Time.timeScale = 1f;
    //        currentTimeScale = 1f;
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        Time.timeScale = 2f;
    //        currentTimeScale = 2f;
    //    }
    //}
}
