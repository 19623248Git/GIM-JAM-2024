using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SETTINGS : MonoBehaviour
{
    [SerializeField] GameObject StartButt;
    public void startbutton()
    {
        SceneManager.LoadScene("BasementMain");
    }
    public void Quit()
    {
        Debug.Log("Quitting the game...");
        Application.Quit(); // Quit the application 
        EditorApplication.isPlaying = false;
    }
    public void askinfo()
    {
        SceneManager.LoadScene("INFOSCENE");
    }

    public void gobacktoPLAY()
    {
        SceneManager.LoadScene("PLAYSCREEN");
    }
}
