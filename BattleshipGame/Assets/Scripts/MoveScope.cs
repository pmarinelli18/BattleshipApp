using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScope : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float scopeSpeed;
    private Rigidbody2D rb;
    private float acc = 0.0f;
    public float acc_fac;
    public int diff_mod;
    public bool gameStart;
    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        rb = GetComponent<Rigidbody2D>();
        Vector3 init = new Vector3(0, 0.8f, 0);
        System.Random rand = new System.Random();
        float randomfloat = (float)(rand.Next(0, 2*diff_mod) - diff_mod);
        if (randomfloat < 0)
        {
            randomfloat = randomfloat - 20;
        }
        else
        {
            randomfloat = randomfloat + 20;
        }
        init.x = randomfloat;
        transform.position = init;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            if (movementJoystick.joystickVec.y != 0)
            {
                if ((movementJoystick.joystickVec.x > 0 && acc < 0) || (movementJoystick.joystickVec.x < 0 && acc > 0))
                {
                    acc = 0;
                }
                //Vector3 movement1 = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
                acc += movementJoystick.joystickVec.x * acc_fac;
                Vector3 movement = new Vector3(movementJoystick.joystickVec.x + acc, 0, 0);
                rb.velocity = new Vector2(movementJoystick.joystickVec.x * scopeSpeed, movementJoystick.joystickVec.y * scopeSpeed);
                movement = -movement;
                transform.position = transform.position + movement * Time.deltaTime;
            }
            else
            {
                acc = 0.0f;
                rb.velocity = Vector2.zero;
            }

        }
    }
    public void StartGame()
    {
        gameStart = true;
    }
}
