using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfGenScore : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text highScore;

    [HideInInspector]
    public float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.text = (time).ToString("0");
    }

    public void SaveScore() {
        if (PlayerPrefs.HasKey("SavedHighScore")) {
            if (time > PlayerPrefs.GetFloat("SavedHighScore")) {
                PlayerPrefs.SetFloat("SavedHighScore", time);
            }
        }
        else {
            PlayerPrefs.SetFloat("SavedHighScore", time);
        }

        highScore.text = "High Score: " + PlayerPrefs.GetFloat("SavedHighScore").ToString("0.##");
        time = 0;
    }
}
