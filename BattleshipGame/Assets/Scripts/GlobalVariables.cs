using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    private string playerName;
    private string oponentName;
    private int playerHealth;

    private string resultAtEndOfGame;

    public void updatePlayerHealth(int health)
    {
        playerHealth = health;
    }
    public int getPlayerHealth()
    {
        return playerHealth;
    }
    public void updatePlayerName(string name)
    {
        playerName = name;
    }
    public void updateOponentName(string name)
    {
        oponentName = name;
    }
    public string getPlayerName()
    {
        return playerName;
    }
    public string getOponentName()
    {
        return oponentName;
    }

    public void updateEndOfGameResult(string result)
    {
        resultAtEndOfGame = result;
    }
    public string getEndOfGameResult()
    {
        return resultAtEndOfGame;
    }

}
