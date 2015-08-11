using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
    
    public static float speed;
    private float posX;
    public int pointValue;

    private GameObject playerObject;
    private Animator playerAnimator;

	void Start () {
        speed = -2.5f + PlayerScript.increaseOfSpeedOnComponents;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = playerObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerAnimator != null && !playerAnimator.GetBool("isIdle"))
        {

            posX = transform.position.x;
            posX += speed * Time.deltaTime;

            transform.position = new Vector3(posX, transform.position.y, transform.position.z);

            if (transform.position.x <= -4)
            {
                Destroy(this.gameObject);
            }
        }
	}

    void OnTriggerEnter2D()
    {
        Debug.Log("Gotta Catch 'Em All");
        PlayerScript.score += pointValue;
        GameObject.Destroy(this.gameObject);
    }
}
