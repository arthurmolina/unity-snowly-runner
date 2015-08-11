using UnityEngine;
using System.Collections;

public class HazardScript : MonoBehaviour {

    public static float speed;
    private float posX;
    public int pointValue;

    private GameObject playerObject;
    private Animator playerAnimator;

    void Start()
    {
        speed = -2.062f + PlayerScript.increaseOfSpeedOnComponents;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = playerObject.GetComponent<Animator>();
    }

	void Update () 
    {
        if (playerAnimator != null && !playerAnimator.GetBool("isIdle"))
        {

            if (pointValue > 0 && playerObject.transform.position.x > transform.position.x)
            {
                PlayerScript.score += pointValue;
                pointValue = 0;
            }

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
        Debug.Log("YOU'RE DEAD! :D");
        GameObject.Destroy(this.gameObject);
        Application.LoadLevel(2);
    }
}
