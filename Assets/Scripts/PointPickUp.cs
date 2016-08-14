using UnityEngine;
using System.Collections;

public class PointPickUp : MonoBehaviour {
    public AudioClip collectPoints;

    public GameObject ball;

    public Material _RedMaterial;
    public Material _BlueMaterial;
    public Material _YellowMaterial;
    public Material _GreenMaterial;
    public Material _OrangeMaterial;

    enum PickUpColours
    {
        RED,
        BLUE,
        YELLOW,
        GREEN,
        ORANGE,
        NONE
    }

    float score = 0;
    AudioSource soundSource;

    void Awake()
    {
        soundSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        score = PlayerPrefs.GetInt("Score");
    }

    void Update()
    {
        GameObject baller = GameObject.Find("Ball");
        if(PlayerPrefs.GetInt("SuckerPower", 0) != 0)
        {
            if (baller != null)
            {
                if(Vector3.Distance(baller.gameObject.transform.position, gameObject.transform.position) < 7)
                {
                    this.transform.LookAt(baller.transform);
                    this.transform.position = Vector3.Lerp(transform.position, baller.transform.position, Time.deltaTime * 3);
                }
            }
        }
    }

    void AddPoint()
    {
        GameObject baller = GameObject.Find("Ball");

        if (baller.gameObject.GetComponent<Renderer>().sharedMaterial == _GreenMaterial)
        {
            score = PlayerPrefs.GetInt("Score");
            score += 2;
        }
        else
        {
            score = PlayerPrefs.GetInt("Score");
            score++;
        }
        
        PlayerPrefs.SetInt("Score", (int)score);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            AddPoint();
            transform.position = Vector3.one * 9999999f;
            if(PlayerPrefs.GetInt("Sound") == 1)
                soundSource.PlayOneShot(collectPoints, 1f);

            PickUpColours selectedColour = AddPickUpPoint(gameObject.tag);
            ClearColours(selectedColour);
            ChangeBallColour(ball, selectedColour);
            Destroy(gameObject, collectPoints.length + 2);
        }
    }

    //Accumalates points for each colour
    PickUpColours AddPickUpPoint(string tag)
    {
        Debug.Log("Adding Point.");
        switch (tag)
        {
            case "RedPoint":
                int redPoint = PlayerPrefs.GetInt("RedPickUp");
                redPoint++;
                PlayerPrefs.SetInt("RedPickUp", redPoint);
                if (redPoint == 5)
                {
                    Debug.Log("RED HIT 5");
                    return PickUpColours.RED;
                }
                    
                break;
            case "BluePoint":
                int bluePoint = PlayerPrefs.GetInt("BluePickUp");
                bluePoint++;
                PlayerPrefs.SetInt("BluePickUp", bluePoint);
                if (bluePoint == 5)
                {
                    Debug.Log("BLUE HIT 5");
                    return PickUpColours.BLUE;
                }
                break;
            case "YellowPoint":
                int yellowPoint = PlayerPrefs.GetInt("YellowPickUp");
                yellowPoint++;
                PlayerPrefs.SetInt("YellowPickUp", yellowPoint);
                if (yellowPoint == 5)
                {
                    Debug.Log("YELLOW HIT 5");
                    return PickUpColours.YELLOW;
                }
                break;
            case "GreenPoint":
                int greenPoint = PlayerPrefs.GetInt("GreenPickUp");
                greenPoint++;
                PlayerPrefs.SetInt("GreenPickUp", greenPoint);
                if (greenPoint == 5)
                {
                    Debug.Log("GREEN HIT 5");
                    return PickUpColours.GREEN;
                }
                break;
            case "OrangePoint":
                int orangePoint = PlayerPrefs.GetInt("OrangePickUp");
                orangePoint++;
                PlayerPrefs.SetInt("OrangePickUp", orangePoint);
                if (orangePoint == 5)
                {
                    Debug.Log("ORANGE HIT 5");
                    return PickUpColours.ORANGE;
                }
                break;
        }

        return PickUpColours.NONE;
    }

    //Resets the Colour Points to 0
    void ClearColours(PickUpColours colour)
    {
        if(colour != PickUpColours.NONE)
        {
            PlayerPrefs.SetInt("RedPickUp", 0);
            PlayerPrefs.SetInt("BluePickUp", 0);
            PlayerPrefs.SetInt("OrangePickUp", 0);
            PlayerPrefs.SetInt("YellowPickUp", 0);
            PlayerPrefs.SetInt("GreenPickUp", 0);
        }
        
    }

    void ChangeBallColour(GameObject ball, PickUpColours colour)
    {
        GameObject baller = GameObject.Find("Ball");
        switch (colour)
        {
            case PickUpColours.RED:
                baller.gameObject.GetComponent<Renderer>().material = _RedMaterial;
                if (baller.gameObject.GetComponent<Renderer>().sharedMaterial == _RedMaterial)
                    baller.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                break;
            case PickUpColours.BLUE:
                baller.gameObject.GetComponent<Renderer>().material = _BlueMaterial;
                PlayerPrefs.SetInt("SuckerPower", 1);
                break;
            case PickUpColours.ORANGE:
                baller.gameObject.GetComponent<Renderer>().material = _OrangeMaterial;
                break;
            case PickUpColours.YELLOW:
                baller.gameObject.GetComponent<Renderer>().material = _YellowMaterial;
                if (baller.gameObject.GetComponent<Renderer>().sharedMaterial == _YellowMaterial)
                    baller.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
                break;
            case PickUpColours.GREEN:
                baller.gameObject.GetComponent<Renderer>().material = _GreenMaterial;
                break;
        }
    }
}
