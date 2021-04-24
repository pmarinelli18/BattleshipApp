using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{

    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    public Animator animator;
    public GameObject gun;
    public GameObject torpedo;
    public GameObject radar;
    public GameObject hack;
    public GameObject repair;
    public GameObject navigation;
    public GameObject button;
    public Text buttonText;
    public string scene;
    bool isOn = false;
    public Sprite highlighted;
    public Sprite unHighlighted;
    float distGun;
    float distTorpedo;
    float distRadar;
    float distHack;
    float distRepair;
    float distNavigation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void switchScene()
    {
        SceneManager.LoadScene(scene);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (movementJoystick.joystickVec.y != 0)
        {
            //Vector3 movement1 = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
            animator.SetFloat("Horizontal", movementJoystick.joystickVec.x);
            animator.SetFloat("Vertical", movementJoystick.joystickVec.y);
            animator.SetFloat("Magnitude", playerSpeed);
            Vector3 movement = new Vector3(movementJoystick.joystickVec.x, movementJoystick.joystickVec.y, 0);


            transform.position = transform.position + movement * Time.deltaTime;
            //transform.position.y = 0;
            //Debug.Log("object" + transform.position.y);
            //Debug.Log("gun" + gun.transform.position);
            distGun = Vector3.Distance(transform.position, gun.transform.position);
            distTorpedo = Vector3.Distance(transform.position, torpedo.transform.position);
            distRadar = Vector3.Distance(transform.position, radar.transform.position);
            distHack = Vector3.Distance(transform.position, hack.transform.position);
            distRepair = Vector3.Distance(transform.position, repair.transform.position);
            distNavigation = Vector3.Distance(transform.position, navigation.transform.position);

            if (distGun <= 1.1f && gun.GetComponent<SpriteRenderer>().enabled)
            {
                if (!isOn)
                {
                    button.SetActive(true);
                    isOn = true;
                    scene = "CannonMinigame";
                    gun.GetComponent<SpriteRenderer>().sprite = highlighted;
                    buttonText.text = "Shoot Cannon";
                }
            }
            else if (distTorpedo <= 1.1f && torpedo.GetComponent<SpriteRenderer>().enabled)
            {
                if (!isOn)
                {
                    button.SetActive(true);
                    isOn = true;
                    scene = "MissleMinigame";
                    torpedo.GetComponent<SpriteRenderer>().sprite = highlighted;
                    buttonText.text = "Shoot Torpedo";
                }
            }
            else if (distRadar <= 1.1f && radar.GetComponent<SpriteRenderer>().enabled)
            {
                if (!isOn)
                {
                    button.SetActive(true);
                    isOn = true;
                    scene = "radarRepairGuessGame";
                    radar.GetComponent<SpriteRenderer>().sprite = highlighted;
                    buttonText.text = "Setup/Fix Radar";
                }
            }
            else if (distHack <= 1.1f && hack.GetComponent<SpriteRenderer>().enabled)
            {
                if (!isOn)
                {
                    button.SetActive(true);
                    isOn = true;
                    scene = "HackingMinigame";
                    hack.GetComponent<SpriteRenderer>().sprite = highlighted;
                    buttonText.text = "Hack Oponent";
                }
            }
            else if (distRepair <= 1.1f && repair.GetComponent<SpriteRenderer>().enabled)
            {
                if (!isOn)
                {
                    button.SetActive(true);
                    isOn = true;
                    scene = "FixBoatMinigame";
                    repair.GetComponent<SpriteRenderer>().sprite = highlighted;
                    buttonText.text = "Repair Ship";
                }
            }
            else if (distNavigation <= 1.1f && navigation.GetComponent<SpriteRenderer>().enabled)
            {
                if (!isOn)
                {
                    button.SetActive(true);
                    isOn = true;
                    scene = "NavigationMinigame";
                    navigation.GetComponent<SpriteRenderer>().sprite = highlighted;
                    buttonText.text = "Move Ship";
                }
            }
            else
            {
                if(isOn)
                {
                    button.SetActive(false);
                    isOn = false;
                    gun.GetComponent<SpriteRenderer>().sprite = unHighlighted;
                    torpedo.GetComponent<SpriteRenderer>().sprite = unHighlighted;
                    hack.GetComponent<SpriteRenderer>().sprite = unHighlighted;
                    radar.GetComponent<SpriteRenderer>().sprite = unHighlighted;
                    repair.GetComponent<SpriteRenderer>().sprite = unHighlighted;
                    navigation.GetComponent<SpriteRenderer>().sprite = unHighlighted;
                }
                
            }
        }
        else
        {
            animator.SetFloat("Magnitude", 0);
            rb.velocity = Vector2.zero;
        }
    }
}
