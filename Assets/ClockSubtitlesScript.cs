using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockSubtitlesScript : MonoBehaviour {
    public Text Subtitles;
    public GameObject Key;
    public GameObject BookClue;

    private void OnTriggerEnter(Collider other)
    {
        if (Key.activeSelf && BookClue.GetComponent<ClueScript>().revealed)
        {
            StartCoroutine(ClockSubtitles());
        } 
    }
    IEnumerator ClockSubtitles()
    {
        Subtitles.GetComponent<Text>().text = "Weird... The clock doesn't seem to work.";
        yield return new WaitForSeconds(5);
        Subtitles.GetComponent<Text>().text = "";
    }
}
