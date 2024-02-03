using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    private void Awake()
    {
        // Ensure only one instance of MusicManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this GameObject when loading a new scene
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate MusicManager instances
        }
    }

    void Start()
    {
        // Play the music
        GetComponent<AudioSource>().Play();
    }
}
