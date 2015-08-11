using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            Application.LoadLevel("game");
        }
	}
}
