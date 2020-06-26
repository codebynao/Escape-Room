using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour {

	void Start () {
        if(Cursor.lockState != CursorLockMode.None)
            Cursor.lockState = CursorLockMode.None;
	}
	
}
