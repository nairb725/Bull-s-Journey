using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_UI;
    [SerializeField] TrackingCamera m_Camera;
    [SerializeField] PlayerController m_Player;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lauchgame()
    {
        Debug.Log("play");

        DisplayUI(false);
        Invoke(nameof(StartTracking), 2f);
    }

    public void Quit()
    {
        Debug.Log("quit");
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

    public bool IsEndGame ()
    {
        return false;
    }
}
