using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerName : MonoBehaviour
{
    public GameObject AccountManager;
    public Text Player1UserName;
    public Text Player2UserName;
    void Start()
    {
        AccountManager = GameObject.Find("AccountManager");
        //= message.userNames[0];
        //AccountManager.GetComponent<GlobalVariables>().oponentName = message.userNames[1];
        Player1UserName.text = AccountManager.GetComponent<GlobalVariables>().getPlayerName();
        Player2UserName.text = AccountManager.GetComponent<GlobalVariables>().getOponentName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
