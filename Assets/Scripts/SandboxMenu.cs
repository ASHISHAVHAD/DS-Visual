using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SandboxMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadQueue()
    {
        SceneManager.LoadScene("Queue");
    }

    public void loadStack()
    {
        SceneManager.LoadScene("Stack");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
