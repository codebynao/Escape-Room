using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueScript : MonoBehaviour {

    public GameObject clue;
    public bool revealed = false;
    public GameObject nextClue;

    private void OnMouseDown()
    {
        if(nextClue.GetComponent<LiftScript>())
        {
            nextClue.GetComponent<LiftScript>().enabled = true;
        }
        clue.SetActive(true);
        revealed = true;

        if (GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().Play();
        }        
    }
}
