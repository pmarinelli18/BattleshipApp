using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public Text timer;
    public int startCount;
    public int dangerZone;
    private float countdown;
    public Text endgametext;
    public Text win;
    public Text outOfBullets;

    // Start is called before the first frame update
    void Start()
    {
        countdown = (float)startCount;
        endgametext.enabled = false;
        UpdateText();
    }

    void UpdateText()
    {
        timer.text = ((int)countdown).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0 && win.enabled == false && outOfBullets.enabled == false)
        {
            countdown -= Time.deltaTime;
            if ((int)countdown <= dangerZone)
            {
                timer.color = new Color(1.0f, 0.0f, 0.0f);
            }
        }
        UpdateText();
        if (countdown < 1)
        {
            endgametext.enabled = true;
        }
    }
}
