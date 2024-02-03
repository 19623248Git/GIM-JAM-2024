using UnityEngine;
using UnityEngine.SceneManagement;

public class IMAGEScript : MonoBehaviour
{
    public string nextSceneName = "PLAYSCREEN"; // Name of the scene to load

    // Update is called once per frame
    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
