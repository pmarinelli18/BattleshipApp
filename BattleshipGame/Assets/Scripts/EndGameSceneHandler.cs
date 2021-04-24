using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndGameSceneHandler : MonoBehaviour
{

	public GameObject AccountManager;
	public Text gameResultLabel;

    // Start is called before the first frame update
    void Start()
    {
        AccountManager = GameObject.Find("AccountManager");
        gameResultLabel.text = AccountManager.GetComponent<GlobalVariables>().getEndOfGameResult();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateBecausePlayerLost(){

    	gameResultLabel.text = "You Lost";
    }
}
