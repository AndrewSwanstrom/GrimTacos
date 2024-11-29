using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject masterSlider;
    public GameObject musicSlider;
    Slider slider;
    Slider slider2;
    // Start is called before the first frame update
    void Start()
    {
        slider = masterSlider.GetComponent<Slider>();
        slider2 = musicSlider.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MasterControl() {
        PlayerPrefs.SetFloat("SavedMasterVolume", slider.value);
        slider.value = PlayerPrefs.GetFloat("SavedMasterVolume");
        AudioListener.volume = PlayerPrefs.GetFloat("SavedMasterVolume");
    }

    public void MusicControl() {
        PlayerPrefs.SetFloat("SavedMusicVolume", slider2.value);
        slider2.value = PlayerPrefs.GetFloat("SavedMusicVolume");
    }
}
