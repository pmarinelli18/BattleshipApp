using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LaunchHandler : MonoBehaviour
{
    private int shots;
    private bool gameHasEnded;
    public Transform reticle;
    public BoxCollider2D boat;
    public Transform boat_pos;
    public AudioSource Shot;
    public AudioSource Shell;
    public ParticleSystem explosion;
    private float hitpos;
    public Text timer;
    public Text win;
    public Text outofammo;
    public Transform continuebutton;

    private GameObject myObject;

    // Start is called before the first frame update
    void Start()
    {
        gameHasEnded = false;
        shots = 1;
        win.enabled = false;
        outofammo.enabled = false;
        continuebutton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.text == "0")
        {
            gameover(0);
        }
    }

    public void Shoot()
    {
        if (shots > 0 && timer.text != "0" && win.enabled == false)
        {
            shots--;
            Shot.Play();
            Shell.Play();
            if (boat.bounds.Contains(new Vector2(reticle.position.x, boat_pos.position.y)))
            {
                StartCoroutine(hit());
            }
            else
            {
                Debug.Log("Miss!");
            }
        }
        if (shots == 0)
        {
            outofammo.enabled = true;
            gameover(0);
        }
    }

    IEnumerator hit()
    {
        hitpos = reticle.position.x;
        yield return new WaitForSeconds(1.0f);
        explosion.transform.Translate(hitpos, boat_pos.position.y - 4, 0);
        explosion.Play();
        win.enabled = true;
        Debug.Log("Hit!");
        gameover(1);
    }

    void gameover(int score)
    {
        if (!gameHasEnded){
            gameHasEnded = true;
            if (score == 1){
                myObject = GameObject.Find("AccountManager");
                string submit = "game/hitConfirm?weaponType=1";
                if (myObject != null)
                {
                    myObject.GetComponent<AccountAuthentication>().SendMessage(submit);
                }
                else
                {
                    Debug.Log("Error: Account Manager not found");
                }
            } else{
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
