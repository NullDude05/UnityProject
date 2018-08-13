using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    public GameObject player;
    public Text timerText;
    private float startTime;
    private float score;

    private void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update () {
        float t = Time.time - startTime;

        string seconds = (t % 60).ToString("f0");

        timerText.text = seconds;
	}
}
