using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    enum BALL_STATE
    {
        FORWARD,
        SIDE
    }
    
    public GameObject _platform;
    GameObject _lastPlatform;
    Rigidbody rb;

    bool isStarted = false;
    float speed = 3;
    BALL_STATE ballState = BALL_STATE.FORWARD;

    void OnTap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            return;
        }
        if (Input.GetKeyDown("a"))
        {
            ballState = BALL_STATE.SIDE;
            rb.velocity = new Vector3(-speed, 0, 0);
        }
            
        if (Input.GetKeyDown("d"))
        {
            ballState = BALL_STATE.SIDE;
            rb.velocity = new Vector3(speed, 0, 0);
        }

        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            ballState = BALL_STATE.SIDE;
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
    
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        _lastPlatform = Instantiate(_platform);
        _lastPlatform.transform.position = new Vector3(0, 0, 3);
        for (int index = 0; index < 7; index++)
        {
            SpawnStartingPlatform();
        }

        for (int index = 0; index < 50; index++)
        {
            SpawnPlatform();
        }
    }
	
	// Update is called once per frame
	void Update () {
        OnTap();
        if (isStarted)
        {
            rb.velocity = new Vector3(0, 0, speed);
            isStarted = false;
        }
    }

    // This method will spawn new platform at the end node of platform chain
    void SpawnStartingPlatform()
    {
        _lastPlatform = Instantiate(_platform, new Vector3(_lastPlatform.transform.position.x,
        _lastPlatform.transform.position.y,
        _lastPlatform.transform.position.z + 1),
        Quaternion.identity) as GameObject;
    }

    // This method will spawn new platform at the end node of platform chain
    void SpawnPlatform()
    {
        // Generating random number between 0 and 1. That will decide that the new platform should create either on left or right
        int randonNumber = Random.Range(0, 3);
        // If randomNumber got 0

        switch (randonNumber)
        {
            case 0:
                // Creating a new platform, setting position w.r.t. last platform and after that assigning it as lastPlatform
                _lastPlatform = Instantiate(_platform, new Vector3(_lastPlatform.transform.position.x,
                _lastPlatform.transform.position.y,
                _lastPlatform.transform.position.z + 1),
                Quaternion.identity) as GameObject;
                break;
            case 1:
                // Creating a new platform, setting position w.r.t. last platform and after that assigning it as lastPlatform
                _lastPlatform = Instantiate(_platform, new Vector3(_lastPlatform.transform.position.x - 1,
                _lastPlatform.transform.position.y,
                _lastPlatform.transform.position.z),
                Quaternion.identity) as GameObject;
                break;
            case 2:
                // Creating a new platform, setting position w.r.t. last platform and after that assigning it as lastPlatform
                _lastPlatform = Instantiate(_platform, new Vector3(_lastPlatform.transform.position.x + 1,
                _lastPlatform.transform.position.y,
                _lastPlatform.transform.position.z),
                Quaternion.identity) as GameObject;
                break;
        }
    }

    void OnCollisionExit(Collision other)
    {
        // Because there is no other thing except platform to collide so I'm not checking that on which our Ball collided.
        // Spawning new platform on leaving current platform
        SpawnPlatform();
        // Assigning platform's Gameobject to a variable "platform"
        GameObject platform = other.gameObject;
        // Turning off "isKinematic" attribute of platform, that will make platform falling down.
        platform.GetComponent<Rigidbody>().isKinematic = false;
        // After start falling, destroy that platform after 1 second.
        InvokeDestroyPlatfrom(platform);
    }

    void InvokeDestroyPlatfrom(GameObject platform)
    {
        // Starting Coroutine to destroy platform.
        StartCoroutine(DestroyPlatform(platform));
    }

    IEnumerator DestroyPlatform(GameObject platform)
    {
        //Waiting for 1 second to execute next line(s) of code.
        yield return new WaitForSeconds(1.0f);
        // Destroying platform
        Destroy(platform);
    }


}
