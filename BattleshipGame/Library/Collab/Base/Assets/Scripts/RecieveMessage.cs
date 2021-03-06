using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class RecieveMessage: MonoBehaviour
{
    // Start is called before the first frame update
    public Text ErrorMsg;
    public GameObject Start;
    public Text Player1;
    public Text Player2;
    public GameObject Player2Name;
    public Sprite Player2Sprite;
    public Text Player1Health;
    public Text Player2Health;
    public Text Player1UserName;
    public Text Player2UserName;
    public GameObject AccountManager;
    [SerializeField] private HealthBar Player1HealthBar;
    [SerializeField] private HealthBar Player2HealthBar;
    public GameObject InGameScreenHandler;


    [SerializeField] BoatState boatState;
    

    public void HandleMessage(string data)
    {
        
        Debug.Log(data);
        try
        {
            var message = JsonUtility.FromJson<MyClass>(data);
        
        if (SceneManager.GetActiveScene().name == "LoginScreen")
        { 
            if (message.id == "login")
            {
                if (message.result)
                {
                    SceneManager.LoadScene("GameSetupScreen");
                }
                else
                {
                    //ErrorMsg.text = data;
                    UnityMainThread.wkr.AddJob(() => { ErrorMsg.text = "Incorrect username or password"; });
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "CreateScreen")
        {
            if (message.id == "createAccount")
            {
                if (message.result)
                {
                    SceneManager.LoadScene("GameSetupScreen");
                }
                else
                {
                    //ErrorMsg.text = data;
                    UnityMainThread.wkr.AddJob(() => { ErrorMsg.text = "That username already exists"; });
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "GameSetupScreen")
        {
            if (message.id == "connectedDevices")
            {
                if (message.userNames.Length == 1)
                {
                    ErrorMsg.text = "Waiting for other Player";
                    Player1.text = message.userNames[0];
                }
                else
                {
                    AccountManager = GameObject.Find("AccountManager");
                        Player1.text = message.userNames[0];
                    Player2.text = message.userNames[1];
                    AccountManager.GetComponent<GlobalVariables>().updatePlayerName(message.userNames[0]);
                    AccountManager.GetComponent<GlobalVariables>().updateOponentName(message.userNames[1]);
                    Player2Name.GetComponent<Image>().sprite= Player2Sprite;
                    ErrorMsg.text = "Game Filled";
                    Start.SetActive(true);
                }
            } else if (message.id == "startGame"){
                SceneManager.LoadScene("InGameScreen");
            }
        }

        if (SceneManager.GetActiveScene().name == "InGameScreen"){
            if (message.id == "boatState"){
                Debug.Log("Parse again");

                var boatState = JsonUtility.FromJson<BoatState>(data);
                Debug.Log(boatState);
                //BoatHealth boatStates = JsonConvert.DeserializeObject<BoatHealth>(data); 
                
                var health = boatState.boatHealth;
                var userNames = boatState.userName;
                //Player2Health.text = health.p2Health;
                //Player1Health.text = health.p1Heath;
                //Player1UserName.text = userNames.p1UserName;
                //Player2UserName.text = userNames.p2UserName;
                InGameScreenHandler = GameObject.Find("InGameScreenHandler");
                AccountManager.GetComponent<GlobalVariables>().updatePlayerHealth(int.Parse(health.p1Health));
                InGameScreenHandler.GetComponent<InGameScreenHandler>().setBoat(health.p1Health, health.p2Health, boatState.stateOfBoatFeatures.radar, boatState.stateOfBoatFeatures.torpedo, boatState.stateOfBoatFeatures.cannons.state, boatState.stateOfBoatFeatures.cannons.numberOfCannons);
                    //Vector3 otherHealthVector = new Vector3(int.Parse(health.p1Heath) / 100, 1, 1);
                    //Vector3 myHealthVector = new Vector3(int.Parse(health.p2Health) / 100, 1, 1);
                  //  Player1HealthBar.SetSize((float)int.Parse(health.p1Heath) / 100);  //.GetComponent<Transform>().localScale = myHealthVector;
                //Player2HealthBar.SetSize((float)int.Parse(health.p2Health) / 100); //.GetComponent<Transform>().localScale = otherHealthVector;
            }
        }

        if (SceneManager.GetActiveScene().name == "CannonMinigame" || SceneManager.GetActiveScene().name == "MissleMinigame")
            {
            if (message.id == "continueToInGameScreen"){
                SceneManager.LoadScene("InGameScreen");
            }
        }
        }
        catch (Exception e)
        {
            Console.WriteLine("{0} Exception caught.", e);
        }

    }
}
public class MyClass
{
    public string id;
    public bool result;
    public string[] userNames;
}


    [System.Serializable]
    public class BoatHealth    {
        public string p1Health;
        public string p2Health;
    }

    [System.Serializable]
    public class UserName   {
        public string p1UserName;
        public string p2UserName;
    }

    [System.Serializable]
    public class Cannons    {
        public string numberOfCannons;
        public string state;
    }

    [System.Serializable]
    public class StateOfBoatFeatures    {
        public Cannons cannons;
        public string radar;
        public string torpedo;
    }

    [System.Serializable]
    public class BoatState    {
        public string id;
        public UserName userName;
        public BoatHealth boatHealth;
        public string boatPosition; 
        public StateOfBoatFeatures stateOfBoatFeatures;
    }
