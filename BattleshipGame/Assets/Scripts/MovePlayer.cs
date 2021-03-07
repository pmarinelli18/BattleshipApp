using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    public Animator animator;
    public GameObject gun;
    public GameObject button;
    bool isOn = false;
    public Sprite highlighted;
    public Sprite unHighlighted;
    float dist;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            dist = Vector3.Distance(transform.position, gun.transform.position);

            if (dist <= 1.5f)
            {
                if (!isOn)
                {
                    button.SetActive(true);
                    isOn = true;
                    gun.GetComponent<SpriteRenderer>().sprite = highlighted;
                }
                

                
            }
            else
            {
                if(isOn)
                {
                    button.SetActive(false);
                    isOn = false;
                    gun.GetComponent<SpriteRenderer>().sprite = unHighlighted;
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
