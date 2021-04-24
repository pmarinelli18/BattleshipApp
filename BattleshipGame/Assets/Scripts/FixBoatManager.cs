using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixBoatManager : MonoBehaviour
{
    public Text timer;
    public int startCount;
    public int dangerZone;
    public GameObject Wait;
    private float countdown;
    public Text endgametext;
    public Text healthEarned;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    public GameObject fire5;
    public GameObject fire6;
    public GameObject fire7;
    public GameObject fire8;
    public GameObject fire9;
    public GameObject fire10;
    private float totalHealth = 0;
    private int healthSection;
    public GameObject AccountManager;
    bool gameEnd;
    public float waitCount;
    public Text waitTimer;
    public bool gameStart;
    public GameObject Instuctions;


    // Start is called before the first frame update
    void Start()
    {
        gameEnd = false;
        countdown = (float)startCount;
        endgametext.enabled = false;
        healthEarned.enabled = false;
        Wait.SetActive(false);
        UpdateText();
        AccountManager = GameObject.Find("AccountManager");
        int health = AccountManager.GetComponent<GlobalVariables>().getPlayerHealth();
        //int health = 09;
        if (health > 90)
            healthSection = 9;
        else if (health > 80)
            healthSection = 8;
        else if (health > 70)
            healthSection = 7;
        else if (health > 60)
            healthSection = 6;
        else if (health > 50)
            healthSection = 5;
        else if (health > 40)
            healthSection = 4;
        else if (health > 30)
            healthSection = 3;
        else if (health > 20)
            healthSection = 2;
        else if (health > 10)
            healthSection = 1;
        else if (health > 0)
            healthSection = 0;
        else
            healthSection = -1;
        
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
                switch (healthSection)
                {
                    case 0:
                        fire10.GetComponent<TapFire>().setActive(true);
                        fire9.GetComponent<TapFire>().setActive(true);
                        fire8.GetComponent<TapFire>().setActive(true);
                        fire7.GetComponent<TapFire>().setActive(true);
                        fire6.GetComponent<TapFire>().setActive(true);
                        fire5.GetComponent<TapFire>().setActive(true);
                        fire4.GetComponent<TapFire>().setActive(true);
                        fire3.GetComponent<TapFire>().setActive(true);
                        fire2.GetComponent<TapFire>().setActive(true);
                        fire1.GetComponent<TapFire>().setActive(true);
                        break;
                    case 1:
                        fire10.GetComponent<TapFire>().setActive(true);
                        fire9.GetComponent<TapFire>().setActive(true);
                        fire8.GetComponent<TapFire>().setActive(true);
                        fire7.GetComponent<TapFire>().setActive(true);
                        fire6.GetComponent<TapFire>().setActive(true);
                        fire4.GetComponent<TapFire>().setActive(true);
                        fire3.GetComponent<TapFire>().setActive(true);
                        fire2.GetComponent<TapFire>().setActive(true);
                        fire1.GetComponent<TapFire>().setActive(true);
                        break;
                    case 2:
                        fire10.GetComponent<TapFire>().setActive(true);
                        fire8.GetComponent<TapFire>().setActive(true);
                        fire7.GetComponent<TapFire>().setActive(true);
                        fire6.GetComponent<TapFire>().setActive(true);
                        fire5.GetComponent<TapFire>().setActive(true);
                        fire4.GetComponent<TapFire>().setActive(true);
                        fire2.GetComponent<TapFire>().setActive(true);
                        fire1.GetComponent<TapFire>().setActive(true);
                        break;
                    case 3:
                        fire9.GetComponent<TapFire>().setActive(true);
                        fire7.GetComponent<TapFire>().setActive(true);
                        fire6.GetComponent<TapFire>().setActive(true);
                        fire5.GetComponent<TapFire>().setActive(true);
                        fire4.GetComponent<TapFire>().setActive(true);
                        fire3.GetComponent<TapFire>().setActive(true);
                        fire1.GetComponent<TapFire>().setActive(true);
                        break;
                    case 4:
                        fire10.GetComponent<TapFire>().setActive(true);
                        fire7.GetComponent<TapFire>().setActive(true);
                        fire6.GetComponent<TapFire>().setActive(true);
                        fire5.GetComponent<TapFire>().setActive(true);
                        fire4.GetComponent<TapFire>().setActive(true);
                        fire1.GetComponent<TapFire>().setActive(true);
                        break;
                    case 5:
                        fire9.GetComponent<TapFire>().setActive(true);
                        fire8.GetComponent<TapFire>().setActive(true);
                        fire5.GetComponent<TapFire>().setActive(true);
                        fire4.GetComponent<TapFire>().setActive(true);
                        fire2.GetComponent<TapFire>().setActive(true);
                        break;
                    case 6:
                        fire10.GetComponent<TapFire>().setActive(true);
                        fire6.GetComponent<TapFire>().setActive(true);
                        fire2.GetComponent<TapFire>().setActive(true);
                        fire1.GetComponent<TapFire>().setActive(true);
                        break;
                    case 7:
                        fire9.GetComponent<TapFire>().setActive(true);
                        fire7.GetComponent<TapFire>().setActive(true);
                        fire1.GetComponent<TapFire>().setActive(true);
                        break;
                    case 8:
                        fire9.GetComponent<TapFire>().setActive(true);
                        fire5.GetComponent<TapFire>().setActive(true);
                        break;
                    case 9:
                        fire4.GetComponent<TapFire>().setActive(true);
                        break;
                }
            }
            if (timer.text != "0")
            {
                countdown -= Time.deltaTime;
                if ((int)countdown <= dangerZone)
                {
                    timer.color = new Color(1.0f, 0.0f, 0.0f);
                }
                UpdateText();
            }

            if (timer.text == "0" && !gameEnd)
            {
                gameEnd = true;
                endgametext.enabled = true;
                healthEarned.enabled = true;
                timer.color = new Color(1.0f, 0.0f, 0.0f);
                totalHealth = fire1.GetComponent<TapFire>().endGame() +
                    fire2.GetComponent<TapFire>().endGame() +
                    fire3.GetComponent<TapFire>().endGame() +
                    fire4.GetComponent<TapFire>().endGame() +
                    fire5.GetComponent<TapFire>().endGame() +
                    fire6.GetComponent<TapFire>().endGame() +
                    fire7.GetComponent<TapFire>().endGame() +
                    fire8.GetComponent<TapFire>().endGame() +
                    fire9.GetComponent<TapFire>().endGame() +
                    fire10.GetComponent<TapFire>().endGame();

                healthEarned.text = "Plus " + (totalHealth / 10).ToString() + " Health";
                string submit = "game/repairShip?healthValue=" + (totalHealth / 10).ToString();
                Wait.SetActive(true);
                AccountManager.GetComponent<AccountAuthentication>().SendMessage(submit);

            }
        }
    }
}
