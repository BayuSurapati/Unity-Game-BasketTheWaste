using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string SceneTutor;
    public string ScenePlay;
    public GameObject panelTutor;
    public GameObject panelCredits;

    // Start is called before the first frame update
    void Start()
    {
        panelTutor.SetActive(false);
        panelCredits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(ScenePlay);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        panelTutor.SetActive(true);
    }

    public void Credits()
    {
        panelCredits.SetActive(true);
    }

    public void backFromTutor()
    {
        panelTutor.SetActive(false);
    }

    public void backFromCredits()
    {
        panelCredits.SetActive(false);
    }
}
