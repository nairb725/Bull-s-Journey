using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Menu, Play, Lose, Win
}
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_UI;
    [SerializeField] TrackingCamera m_Camera;
    [SerializeField] PlayerController m_Player;
    [SerializeField] GrandpaController m_GrandPa;
    private GameState _gameState;
    [SerializeField] GameObject canvasWin;
    [SerializeField] GameObject canvasLose;
    [SerializeField] GameObject canvasMenu;
    [SerializeField] private AudioSource randomSound;
    [SerializeField] private AudioClip[] audioSources;

    public void DisplayUI(bool display) => m_UI.SetActive(display);

    public static GameManager Instance; // A static reference to the GameManager instance
    void Awake()
    {
        if (Instance == null) // If there is no instance already
        {
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
    }

    private void Start()
    {
        m_GrandPa.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch(_gameState){
            case GameState.Menu:
                canvasMenu.SetActive(true);
                break;
            case GameState.Play:
                canvasMenu.SetActive(false);
                canvasLose.SetActive(false);
                canvasWin.SetActive(false);
                break;
            case GameState.Lose:
                canvasLose.SetActive(true);
                break;
            case GameState.Win:
                canvasWin.SetActive(true);
                break;
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G))
        {
            RandomSound();
        }
    }

    public void Lauchgame()
    {
        _gameState = GameState.Play;
        m_GrandPa.gameObject.SetActive(true);
        m_GrandPa.StartGame();
        Invoke(nameof(StartTracking), 4f);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        //Quit app
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
     }

    private void StartTracking()
    {
        m_Camera.Track();
    }

    public bool IsEndGame()
    {   
        return GameState.Lose == _gameState || GameState.Win == _gameState;
    }

    public void ChangeState(GameState state)
    {
        _gameState = state;
        if (IsEndGame()) m_Camera.Untrack();
    }

    void RandomSound()
    {
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();
    }
}
