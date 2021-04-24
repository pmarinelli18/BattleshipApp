using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotateCircle : MonoBehaviour
{
    private int current;
    private int previous;
    private int rotate;
    public Text text;
    public int random;
    public Text Goal;
    public Text timer;
    public int startCount;
    public int dangerZone;
    public GameObject Wait;
    private float countdown;
    public Text endgametext;
    public GameObject AccountManager;
    bool gameEnd;
    public float waitCount;
    public Text waitTimer;
    public bool gameStart;
    public GameObject Instuctions;
    void Start()
    {
        gameEnd = false;
        countdown = (float)startCount;
        endgametext.enabled = false;
        Wait.SetActive(false);
        UpdateText();
        AccountManager = GameObject.Find("AccountManager");
        previous = 0;
        rotate = 0;
        random = Random.Range(10, 20);
        int sign = Random.Range(1, 3);
        if (sign == 1)
            random = -random;
        Goal.text = "Get to the value " + random.ToString();

    }
    void Update()
    {
        if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            waitTimer.text = ((int)waitCount).ToString();
        }
        else
        {
            if (!gameStart)
            {
                waitTimer.enabled = false;
                gameStart = true;
                Instuctions.SetActive(false);
            }
            if (timer.text != "0")
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + transform.position;
                //pos = Input.mousePosition - pos;
                float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
                if (ang > -180 && ang <= -90)
                {
                    current = 0;
                }
                else if (ang > -90 && ang <= 0)
                {
                    current = 1;
                }
                else if (ang > 0 && ang <= 90)
                {
                    current = 2;
                }
                else if (ang > 0 && ang <= 180)
                {
                    current = 3;
                }
                if (previous == 0)
                {
                    if (current == 1)
                        rotate++;
                    if (current == 3)
                        rotate--;
                }
                if (previous == 1)
                {
                    if (current == 2)
                        rotate++;
                    if (current == 0)
                        rotate--;
                }
                if (previous == 2)
                {
                    if (current == 3)
                        rotate++;
                    if (current == 1)
                        rotate--;
                }
                if (previous == 3)
                {
                    if (current == 0)
                        rotate++;
                    if (current == 2)
                        rotate--;
                }
                previous = current;
                transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
                text.text = rotate.ToString();
                countdown -= Time.deltaTime;
                if ((int)countdown <= dangerZone)
                {
                    timer.color = new Color(1.0f, 0.0f, 0.0f);
                }
                UpdateText();
                if (timer.text == "0" && !gameEnd)
                {
                    gameEnd = true;
                    endgametext.enabled = true;
                    timer.color = new Color(1.0f, 0.0f, 0.0f);
                    string submit;
                    if (rotate == random)
                    {
                        submit = "game/navigation";
                        //Goal.text = "you Win";
                    }
                    else
                    {
                        submit = "game/lostGame";
                        //Goal.text = "you Lose";
                    }
                    Wait.SetActive(true);
                    AccountManager.GetComponent<AccountAuthentication>().SendMessage(submit);
                }
            }
        }
    }
        void UpdateText()
        {
            if (timer.text != "0")
            {
                timer.text = ((int)countdown).ToString();
            }
        }
        /*private float baseAngle = 0.0f;
        void OnMouseDown()
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            pos = Input.mousePosition - pos;
            baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
            baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
        }
        void OnMouseDrag()
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            pos = Input.mousePosition - pos;
            float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
            transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
        }*/
        // Use this for initialization
        /*void Start()
        {

        }

        void Update()
        {
            bool turtle = false;
            RaycastHit hit;

            if (Input.GetMouseButton(0))
            {

                float x = Input.GetAxis("Mouse X");
                float y = Input.GetAxis("Mouse Y");
                float speed = 10;
                transform.rotation *= Quaternion.AngleAxis(x * speed, Vector3.forward);
                transform.rotation *= Quaternion.AngleAxis(y * speed, Vector3.forward);


            }
        }*/
        
}