using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfGenScore : MonoBehaviour
{
    public TMP_Text text;
    float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.text = (time).ToString("0.##");
    }
}
