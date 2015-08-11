using UnityEngine;
using System.Collections;

public class SpawnPointScript : MonoBehaviour {

    public GameObject spawnigObject;
    public float rateSpawn;
    public float timeCount;
    public GameObject playerObject;
    private Animator playerAnimator;

	// Use this for initialization
	void Start () {
        timeCount = 0;
        rateSpawn = 0;
        playerAnimator = playerObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerAnimator != null && !playerAnimator.GetBool("isIdle"))
        {
            timeCount += Time.deltaTime;
            rateSpawn = Random.Range(1, 50);

            if (timeCount >= rateSpawn)
            {
                timeCount = 0;
                GameObject tempObject = Instantiate(spawnigObject) as GameObject;
                tempObject.transform.position = new Vector3(transform.position.x,
                                                                tempObject.transform.position.y,
                                                                tempObject.transform.position.z);
            }
        }
	}
}
