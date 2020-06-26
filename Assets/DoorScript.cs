using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour {
    public GameObject Door;
    public GameObject Key;
    public AudioClip LockedSound;
    public AudioClip OpenDoorSound;
    public AudioClip CloseDoorSound;
    public Text Subtitles;
    public Image image;
    public bool IsOpen = false;
    private bool key = false;

    void Start()
    {
        gameObject.GetComponent<DoorScript>().enabled = false;
    }

    void Update()
    {
        key = Key.GetComponent<TakeClueScript>().taken;
    }

    private void OnMouseDown()
    {
        if(key)
        {
            if (IsOpen)
            {
                Door.transform.Rotate(0, 0, -90f);
                GetComponent<AudioSource>().clip = CloseDoorSound;
                GetComponent<AudioSource>().Play();
                IsOpen = false;
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                Door.transform.Rotate(0, 0, 90f);
                GetComponent<AudioSource>().clip = OpenDoorSound;
                GetComponent<AudioSource>().Play();
                IsOpen = true;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(DoorOpenSubtitles());
                StartCoroutine(FadeIn());
                StartCoroutine(WaitBeforeEnd());
            }
        } else
        {
            GetComponent<AudioSource>().clip = LockedSound;
            GetComponent<AudioSource>().Play();
            StartCoroutine(DoorLockedSubtitles());
        }      
    }

    IEnumerator DoorOpenSubtitles()
    {
        Subtitles.GetComponent<Text>().text = "Finally !";
        yield return new WaitForSeconds(3);
        Subtitles.GetComponent<Text>().text = "";
    }

    IEnumerator DoorLockedSubtitles()
    {
        Subtitles.GetComponent<Text>().text = "The door is locked.";
        yield return new WaitForSeconds(3);
        Subtitles.GetComponent<Text>().text = "";
    }

    IEnumerator WaitBeforeEnd()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(3);
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
}
