using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissleGameWin : MonoBehaviour
{
    public Rigidbody2D missle;
    public ParticleSystem explosion;
    private bool gameHasEnded;
    public Text win;
    public Text dead;
    public Text timer;
    public Transform continuebutton;
    private GameObject myObject;

    // Start is called before the first frame update
    void Start()
    {
        win.enabled = false;
        dead.enabled = false;
        gameHasEnded = false;
        continuebutton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!(win.enabled == true) && !(dead.enabled == true) && !(timer.text == "0"))
        {
            Collider2D[] colliders = new Collider2D[10];
            int hits = missle.GetContacts(colliders);
            if (hits >= 1 && colliders[0].name == "mine(Clone)")
            {
                dead.enabled = true;
                timer.text = "0";

                Destroy(colliders[0].gameObject);
                missle.gameObject.SetActive(false);
                explosion.transform.Translate(Camera.main.transform.position.x, Camera.main.transform.position.y - 2, 0);
                explosion.Play();
            }
            else if (hits >= 1 && colliders[0].name == "ship")
            {
                win.enabled = true;
                timer.text = "0";

                missle.gameObject.SetActive(false);
                explosion.transform.Translate(Camera.main.transform.position.x, Camera.main.transform.position.y - 2, 0);
                explosion.Play();
            }


            if (win.enabled == true)
            {
                gameover(1);
            }

            if (dead.enabled == true || timer.text == "0")
            {
                gameover(0);
            }
        }
    }

    void gameover(int score)
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            if (score == 1)
            {
                myObject = GameObject.Find("AccountManager");
                string submit = "game/hitConfirm?weaponType=2";
                if (myObject != null)
                {
                    myObject.GetComponent<AccountAuthentication>().SendMessage(submit);
                }
                else
                {
                    Debug.Log("Error: Account Manager not found");
                }
            }
            else
            {
                myObject = GameObject.Find("AccountManager");
                string submit = "game/lostGame";
                if (myObject != null)
                {
                    myObject.GetComponent<AccountAuthentication>().SendMessage(submit);
                }
                else
                {
                    Debug.Log("Error: Account Manager not found");
                }
            }
        }
        continuebutton.gameObject.SetActive(true);
    }
}
