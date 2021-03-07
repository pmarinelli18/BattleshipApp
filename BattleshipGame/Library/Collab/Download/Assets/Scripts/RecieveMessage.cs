using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject Player1HealthBar;
    public GameObject Player2HealthBar;

    [SerializeField] BoatState boatState;


    public void HandleMessage(string data)
    {
        Debug.Log(data);
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
                    Player1.text = message.userNames[0];
                    Player2.text = message.userNames[1];
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
                Player2Health.text = health.p2Health;
                Player1Health.text = health.p1Heath;
                Player1UserName.text = userNames.p1UserName;
                Player2UserName.text = userNames.p2UserName;


                Vector3 otherHealthVector = new Vector3(int.Parse(health.p1Heath) / 100, 1, 1);
                Vector3 myHealthVector = new Vector3(int.Parse(health.p2Health) / 100, 1, 1);
                Player1HealthBar.GetComponent<Transform>().localScale = myHealthVector;
                Player2HealthBar.GetComponent<Transform>().localScale = otherHealthVector;
            }
        }

        if (SceneManager.GetActiveScene().name == "CannonMinigame"){
            if (message.id == "continueToInGameScreen"){
                SceneManager.LoadScene("InGameScreen");
            }
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
        public string p2Health;
        public string p1Heath;
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
