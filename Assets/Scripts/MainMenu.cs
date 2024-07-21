using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadSandboxMenu()
    {
        SceneManager.LoadScene("Sandbox Menu");
    }

    public void exit()
    {
        Application.Quit();
    }

    public void loadTakeATour()
    {
        SceneManager.LoadScene("QueueTAT");
    }

    public void loadTATMenu()
    {
        SceneManager.LoadScene("TATMenu");
    }

    public void loadMeetTheTeam()
    {
        SceneManager.LoadScene("MeetTheTeam");
    }

    public void loadAbout()
    {
        SceneManager.LoadScene("About");
    }
}
