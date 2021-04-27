using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }

    
    public void mouseActivate()
    {
        
    }
    

    
    

    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Quit");


    }


    public void Easy()
    {
        SceneManager.LoadScene("Easy");
    }

    public void Medium()
    {
        SceneManager.LoadScene("Medium");
    }

    public void Hard()
    {
        SceneManager.LoadScene("Hard");
    }

    public void Insane()
    {
        SceneManager.LoadScene("Insane");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("loading");
    }
}


