using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float speed = 1;
    public int jumpForce;
    public bool isGrounded;
    public static int score;

    public Transform groundCheck;
    public Rigidbody2D playerRigidBody;
    public Animator animator;
    public LayerMask whatIsGround;
    public AudioClip jumpSfx;
    public AudioClip doubleJumpSfx;
    public UnityEngine.UI.Text txtScore;
    private bool isRunning;
    private int limitForSpeed;
    public static float increaseOfSpeedOnComponents;

    void Start()
    {
        increaseOfSpeedOnComponents = 0.0f;
        isRunning = true;
        score = 0;
        limitForSpeed = 100;
    }

	void Update () 
    {
        txtScore.text = score.ToString();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRigidBody.AddForce(Vector2.up * jumpForce);
            this.GetComponent<AudioSource>().PlayOneShot(jumpSfx);
        }
            
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);

        if (Input.GetButtonDown("Fire1"))
        {
            isRunning = !isRunning;
        }

        animator.SetBool("isJumping", !isGrounded);
        animator.SetBool("isRunning", isGrounded && isRunning);
        animator.SetBool("isIdle", isGrounded && !isRunning);

        letsUpdateSpeed();
	}

    public void letsUpdateSpeed()
    {
        if (score >= limitForSpeed)
        {
            increaseOfSpeedOnComponents += -0.5f;
            GameObject bkground = GameObject.FindGameObjectWithTag("Background");
            BackgroundScript bkgsScript = bkground.GetComponent<BackgroundScript>();
            bkgsScript.scrollSpeed += 0.1f;

            limitForSpeed += 100;
        }
    }

	void OnTriggerEnter2D()
	{
		PlayerPrefs.SetInt("score", score);
		if (score > PlayerPrefs.GetInt("record"))
		{
			PlayerPrefs.SetInt("record", score);
		}
	}
}
