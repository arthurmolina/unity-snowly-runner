using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

    public float scrollSpeed = 0.1f;
    private float offset;
    private Renderer rend;
    public GameObject playerObject;
    private Animator playerAnimator;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        playerAnimator = playerObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        if (playerObject != null && !playerAnimator.GetBool("isIdle"))
        {
            offset += scrollSpeed * Time.deltaTime;
			rend.material.mainTextureOffset = Vector2.right * offset;
        }
    }
}
