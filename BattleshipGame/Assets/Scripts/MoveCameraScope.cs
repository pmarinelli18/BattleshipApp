using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCameraScope : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public Camera camera;
    public float scope_speed;
    public float acc_speed;
    public float dec;
    private float acc;
    public float border;
    private float left_border;
    private float right_border;
    public Text timer;
    public Text win;
    public bool gameStart;

    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        acc = 0;
        left_border = camera.transform.position.x - border;
        right_border = camera.transform.position.x + border;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            if (timer.text != "0" && win.enabled == false)
            {
                if (movementJoystick.joystickVec.x == 0)
                {
                    acc -= acc * acc_speed / dec;
                }
                //Debug.Log(camera.transform.position.x);
                //Debug.Log(movementJoystick.joystickVec.x);
                acc += acc_speed * movementJoystick.joystickVec.x;
                float movement = (movementJoystick.joystickVec.x + acc) * scope_speed;
                if ((movement < 0 && camera.transform.position.x > left_border) || (movement > 0 && camera.transform.position.x < right_border))
                {
                    camera.transform.Translate(movement, 0, 0);
                }
                else
                {
                    acc = 0;
                }
            }
        }
    }
    public void StartGame()
    {
        gameStart = true;
    }
}
