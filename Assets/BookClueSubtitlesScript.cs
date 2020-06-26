using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookClueSubtitlesScript : MonoBehaviour {
    public Text Subtitles;

    private void OnMouseDown()
    {
        StartCoroutine(ClueSubtitles());
    }
    IEnumerator ClueSubtitles()
    {
        yield return new WaitForSeconds(1);
        Subtitles.GetComponent<Text>().text = "Time is ticking.... What does it mean ?";
        yield return new WaitForSeconds(6);
        Subtitles.GetComponent<Text>().text = "";
    }
}
