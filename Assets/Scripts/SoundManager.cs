using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource; 
    [SerializeField] private AudioSource _effectsSource;
    [SerializeField] private AudioSource _StarSource;
    [SerializeField] private AudioSource _SuccessSource;
    
    public GameObject currentScene;

    public int Value;

    void Update()
    {
        Value = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Your scene is " + Value);
    }

    void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject); 

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    } 

    public void ToggleMusic()
    {
        _musicSource.mute = !_musicSource.mute;
    }
    
}
