using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackWinController : MonoBehaviour
{
    public Text win;
    public Text timer;
    public Transform continuebutton;
    public GameObject AccountManager;
    private bool gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        gameEnd = false;
        win.enabled = false;
        continuebutton.gameObject.SetActive(false);
        AccountManager = GameObject.Find("AccountManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(int.Parse(timer.text) == 0 && gameEnd == false)
        {
            gameEnd = true;
            string submit;
            submit = "game/lostGame";
            continuebutton.gameObject.SetActive(true);
            AccountManager.GetComponent<AccountAuthentication>().SendMessage(submit);
        }
    }
}
