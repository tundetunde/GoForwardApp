using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Ball : MonoBehaviour {
    public GameObject _platform;
    public GameObject _highPlatform;
    public GameObject _trapPlatform;
    GameObject _lastPlatform;
    Rigidbody rb;

    public GameObject _pickUp;
    public GameObject _redPickUp;
    public GameObject _bluePickUp;
    public GameObject _yellowPickUp;
    public GameObject _greenPickUp;
    public GameObject _orangePickUp;

    public Material _RedMaterial;
    public Material _BlueMaterial;
    public Material _YellowMaterial;
    public Material _GreenMaterial;
    public Material _OrangeMaterial;
    public Material _OriginalMaterial;

    public Text doublePointText ;
    public Text timeText;

    bool isStarted = false;
    float timer = 0;
    float speed = 3;
    void OnTap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            return;
        }
        if (Input.GetKeyDown("a"))
            rb.velocity = new Vector3(-speed, 0, 0);
            
        if (Input.GetKeyDown("d"))
            rb.velocity = new Vector3(speed, 0, 0);

        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
            rb.velocity = new Vector3(0, 0, speed);
    }

    void Awake()
    {
        doublePointText.gameObject.SetActive(false);
        switch (UseBall.colour)
        {
            case UseBall.COLOURS.BLUE:
                gameObject.GetComponent<Renderer>().material = _BlueMaterial;
                PlayerPrefs.SetInt("SuckerPower", 1);
                break;
            case UseBall.COLOURS.YELLOW:
                gameObject.GetComponent<Renderer>().material = _YellowMaterial;
                speed = 4;
                break;
            case UseBall.COLOURS.RED:
                gameObject.GetComponent<Renderer>().material = _RedMaterial;
                break;
            case UseBall.COLOURS.GREEN:
                gameObject.GetComponent<Renderer>().material = _GreenMaterial;
                break;
            case UseBall.COLOURS.ORANGE:
                gameObject.GetComponent<Renderer>().material = _OrangeMaterial;
                break;
            default:
                gameObject.GetComponent<Renderer>().material = _OriginalMaterial;
                break;
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

        for (int index = 0; index < 200; index++)
        {
            SpawnPlatform();
        }
    }
	
	// Update is called once per frame
	void Update () {
        OnTap();
        DoubleTimeMaterial();
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
        int randonNumber = UnityEngine.Random.Range(0, 3);
        int randonNumber2 = UnityEngine.Random.Range(0, 5);

        switch (randonNumber)
        {
            case 0:
                {
                    // Creating a new platform, setting position w.r.t. last platform and after that assigning it as lastPlatform
                    if (randonNumber2 == 4)
                        _lastPlatform = Instantiate(_platform, new Vector3(_lastPlatform.transform.position.x,
                        _lastPlatform.transform.position.y,
                        _lastPlatform.transform.position.z + 1.5f),
                        Quaternion.identity) as GameObject;
                    else
                        _lastPlatform = Instantiate(_platform, new Vector3(_lastPlatform.transform.position.x,
                        _lastPlatform.transform.position.y,
                        _lastPlatform.transform.position.z + 1.5f),
                        Quaternion.identity) as GameObject;
                    
                }
                
                break;
            case 1:
                {
                    // Creating a new platform, setting position w.r.t. last platform and after that assigning it as lastPlatform
                    if (randonNumber2 == 4)
                        _lastPlatform = Instantiate(_platform, new Vector3(_lastPlatform.transform.position.x - 1.5f,
                        _lastPlatform.transform.position.y,
                        _lastPlatform.transform.position.z),
                        Quaternion.identity) as GameObject;
                    else
                        _lastPlatform = Instantiate(_platform, new Vector3(_lastPlatform.transform.position.x - 1.5f,
                        _lastPlatform.transform.position.y,
                        _lastPlatform.transform.position.z),
                        Quaternion.identity) as GameObject;
                }
                break;
            case 2:
                {
                    if (randonNumber2 == 4)
                        // Creating a new platform, setting position w.r.t. last platform and after that assigning it as lastPlatform
                        _lastPlatform = Instantiate(_platform, new Vector3(_lastPlatform.transform.position.x + 1.5f,
                        _lastPlatform.transform.position.y,
                        _lastPlatform.transform.position.z),
                        Quaternion.identity) as GameObject;
                    else
                        // Creating a new platform, setting position w.r.t. last platform and after that assigning it as lastPlatform
                        _lastPlatform = Instantiate(_platform, new Vector3(_lastPlatform.transform.position.x + 1.5f,
                        _lastPlatform.transform.position.y,
                        _lastPlatform.transform.position.z),
                        Quaternion.identity) as GameObject;
                }
                
                break;
        }

        randonNumber = UnityEngine.Random.Range(0, 40);

        switch (randonNumber)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                break;
            case 4:
                _pickUp = SpawnPickUps.SpawnPlatform(_pickUp, _lastPlatform.transform.position.x, _lastPlatform.transform.position.y, _lastPlatform.transform.position.z);
                break;
            case 5:
                _pickUp = SpawnPickUps.SpawnPlatform(_redPickUp, _lastPlatform.transform.position.x, _lastPlatform.transform.position.y, _lastPlatform.transform.position.z);
                break;
            case 6:
                _pickUp = SpawnPickUps.SpawnPlatform(_bluePickUp, _lastPlatform.transform.position.x, _lastPlatform.transform.position.y, _lastPlatform.transform.position.z);
                break;
            case 7:
                _pickUp = SpawnPickUps.SpawnPlatform(_yellowPickUp, _lastPlatform.transform.position.x, _lastPlatform.transform.position.y, _lastPlatform.transform.position.z);
                break;
            case 8:
                _pickUp = SpawnPickUps.SpawnPlatform(_greenPickUp, _lastPlatform.transform.position.x, _lastPlatform.transform.position.y, _lastPlatform.transform.position.z);
                break;
            case 9:
                _pickUp = SpawnPickUps.SpawnPlatform(_orangePickUp, _lastPlatform.transform.position.x, _lastPlatform.transform.position.y, _lastPlatform.transform.position.z);
                break;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            // Because there is no other thing except platform to collide so I'm not checking that on which our Ball collided.
            // Spawning new platform on leaving current platform
            SpawnPlatform();
            // Assigning platform's Gameobject to a variable "platform"
            GameObject platform = other.gameObject;
            // Turning off "isKinematic" attribute of platform, that will make platform falling down.
            
            // After start falling, destroy that platform after 1 second.
            InvokeDestroyPlatfrom(platform);
        }
    }

    void InvokeDestroyPlatfrom(GameObject platform)
    {
        // Starting Coroutine to destroy platform.
        StartCoroutine(DestroyPlatform(platform));
    }

    IEnumerator DestroyPlatform(GameObject platform)
    {
        //yield return new WaitForSeconds(1.5f);
        //platform.GetComponent<Rigidbody>().isKinematic = false;
        //Waiting for 1 second to execute next line(s) of code.
        yield return new WaitForSeconds(3.5f);
        // Destroying platform
        Destroy(platform);
    }

    void DoubleTimeMaterial()
    {
        GameObject baller = GameObject.Find("Ball");
        if (baller.gameObject.GetComponent<Renderer>().sharedMaterial == _BlueMaterial || baller.gameObject.GetComponent<Renderer>().sharedMaterial == _RedMaterial
            || baller.gameObject.GetComponent<Renderer>().sharedMaterial == _GreenMaterial || baller.gameObject.GetComponent<Renderer>().sharedMaterial == _YellowMaterial
                || baller.gameObject.GetComponent<Renderer>().sharedMaterial == _OrangeMaterial)
        {
            doublePointText.gameObject.SetActive(true);
            if (baller.gameObject.GetComponent<Renderer>().sharedMaterial == _GreenMaterial)
                doublePointText.text = "DOUBLE SCORE";
            if(baller.gameObject.GetComponent<Renderer>().sharedMaterial == _YellowMaterial)
            {
                doublePointText.text = "SONIC SPEED";
                speed = 4;
            }
            if (baller.gameObject.GetComponent<Renderer>().sharedMaterial == _BlueMaterial)
                doublePointText.text = "SONIC SUCTION";
            if (baller.gameObject.GetComponent<Renderer>().sharedMaterial == _RedMaterial)
                doublePointText.text = "ANTI-GRAVITY";
            if (baller.gameObject.GetComponent<Renderer>().sharedMaterial == _OrangeMaterial)
                doublePointText.text = "I DUNNO YET";

            timer += Time.deltaTime;
            timeText.gameObject.SetActive(true);
            timeText.text = Convert.ToString(Convert.ToInt32(timer));
            if (timer > 5)
            {
                timeText.gameObject.SetActive(false);
                if (baller.gameObject.GetComponent<Renderer>().sharedMaterial == _RedMaterial)
                    baller.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                if (baller.gameObject.GetComponent<Renderer>().sharedMaterial == _YellowMaterial)
                    speed = 3;
                if (baller.gameObject.GetComponent<Renderer>().sharedMaterial == _BlueMaterial)
                    PlayerPrefs.SetInt("SuckerPower", 0);
                if (baller.gameObject.GetComponent<Renderer>().sharedMaterial == _GreenMaterial)
                    doublePointText.gameObject.SetActive(false);

                switch (UseBall.colour)
                {
                    case UseBall.COLOURS.BLUE:
                        baller.gameObject.GetComponent<Renderer>().material = _BlueMaterial;
                        PlayerPrefs.SetInt("SuckerPower", 1);
                        break;
                    case UseBall.COLOURS.YELLOW:
                        baller.gameObject.GetComponent<Renderer>().material = _YellowMaterial;
                        speed = 4;
                        break;
                    case UseBall.COLOURS.RED:
                        baller.gameObject.GetComponent<Renderer>().material = _RedMaterial;
                        break;
                    case UseBall.COLOURS.GREEN:
                        baller.gameObject.GetComponent<Renderer>().material = _GreenMaterial;
                        break;
                    case UseBall.COLOURS.ORANGE:
                        baller.gameObject.GetComponent<Renderer>().material = _OrangeMaterial;
                        break;
                    default:
                        baller.gameObject.GetComponent<Renderer>().material = _OriginalMaterial;
                        break;
                }
                timer = 0;
            }
        }
    }
}
