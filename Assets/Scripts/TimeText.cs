using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    [SerializeField] Text timeText;

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;

        string timeString = currentTime.ToString("HH : mm");

        timeText.text = timeString;
    }
}
