using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public UnityEngine.UI.Text score;
    public UnityEngine.UI.Text record;

    // Use this for initialization
    void Start () {
        score.text = PlayerPrefs.GetInt("score").ToString();
        record.text = PlayerPrefs.GetInt("record").ToString();
    }
                   
    // Update is called once per frame
    void Update () {
	
	}
}
