using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    public GameObject audio;
    AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music = audio.GetComponent<AudioSource>();
        music.volume = PlayerPrefs.GetFloat("SavedMusicVolume");
    }

}
