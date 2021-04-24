using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public Text timer;
    public int startCount;
    public int dangerZone;
    private float countdown;
    public Text endgametext;
    public Text win;
    public float waitCount;
    public Text waitTimer;
    public bool gameStart;
    public GameObject Instuctions;
    public GameObject MoveScope;
    public GameObject SpawnMines;
    public GameObject MoveTorpedo;

    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        countdown = (float)startCount;
        endgametext.enabled = false;
        UpdateText();
    }

    void UpdateText()
    {
        if (timer.text != "0")
        {
            timer.text = ((int)countdown).ToString();
        }
    }

    // Update is called once per frame
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
                if(SceneManager.GetActiveScene().name == "CannonMinigame")
                    MoveScope.GetComponent<MoveCameraScope>().StartGame();
                if (SceneManager.GetActiveScene().name == "MissleMinigame")
                {
                    MoveTorpedo.GetComponent<MoveTorpedo>().StartGame();
                    SpawnMines.GetComponent<SpawnMines>().StartGame();
                }
            }
            if (timer.text != "0" && win.enabled == false)
            {
                countdown -= Time.deltaTime;
                if ((int)countdown <= dangerZone)
                {
                    timer.color = new Color(1.0f, 0.0f, 0.0f);
                }
            }
            UpdateText();
            if (timer.text == "0")
            {
                endgametext.enabled = true;
                timer.color = new Color(1.0f, 0.0f, 0.0f);
            }
        }
    }
    public bool isStart()
    {
        return gameStart;
    }
}
