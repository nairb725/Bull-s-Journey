using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_UI;
    [SerializeField] TrackingCamera m_Camera;
    [SerializeField] PlayerController m_Player;

    public void DisplayUI(bool display) => m_UI.SetActive(display);

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
        DisplayUI(false);
        Invoke(nameof(StartTracking), 2f);
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
}
