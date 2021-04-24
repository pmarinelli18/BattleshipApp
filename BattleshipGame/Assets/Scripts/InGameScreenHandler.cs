using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InGameScreenHandler : MonoBehaviour
{
	private GameObject accountManager;
    public GameObject radar;
    public GameObject torpedo;
    public GameObject cannon;
    public Text cannonNumber;
    public GameObject hack;
    public GameObject repair;
    public GameObject navigate;
    public GameObject radarIcon;
    public GameObject torpedoIcon;
    public GameObject cannonIcon;
    public GameObject hackIcon;
    public GameObject repairIcon;
    public GameObject navigateIcon;
    public GameObject oponentTorpedoIcon;
    public Text Player1Health;
    public Text Player2Health;
    [SerializeField] private HealthBar Player1HealthBar;
    [SerializeField] private HealthBar Player2HealthBar;

    // Start is called before the first frame update
    void Start()
    {
		accountManager = GameObject.Find("AccountManager");
        string submit = "get/boatState";
        accountManager.GetComponent<AccountAuthentication>().SendMessage(submit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setBoat(string playerHealth, string oponentHealth, string radarEnabled, string torpedoEnabled, string cannonsEnabled, string numCannons, string incomingTorpedo)
    {
        Debug.Log("change health");
        Player1HealthBar.SetSize((float)int.Parse(playerHealth) / 100);  //.GetComponent<Transform>().localScale = myHealthVector;
        Player2HealthBar.SetSize((float)int.Parse(oponentHealth) / 100);
        Player1Health.text = playerHealth;
        Player2Health.text = oponentHealth;
        cannonNumber.text = numCannons;
        Debug.Log("After change health");
        if (String.Compare(radarEnabled, "Enabled") == 0)
        {
            radar.GetComponent<SpriteRenderer>().enabled = false;
            radarIcon.GetComponent<Image>().color = new Color32(159, 159, 159, 255);
        }
        else
        {
            radar.GetComponent<SpriteRenderer>().enabled = true;
            radarIcon.GetComponent<Image>().color = new Color32(0, 255, 23, 255);
        }
        if((float)int.Parse(playerHealth) != 100)
        {
            repair.GetComponent<SpriteRenderer>().enabled = true;
            repairIcon.GetComponent<Image>().color = new Color32(0, 255, 23, 255);
        }
        else
        {
            repair.GetComponent<SpriteRenderer>().enabled = false;
            repairIcon.GetComponent<Image>().color = new Color32(159, 159, 159, 255);
        }
        if (String.Compare(torpedoEnabled, "Standby") == 0)
        {
            torpedo.GetComponent<SpriteRenderer>().enabled = true;
            torpedoIcon.GetComponent<Image>().color = new Color32(0, 255, 23, 255);
        }
        else
        {
            torpedo.GetComponent<SpriteRenderer>().enabled = false;
            torpedoIcon.GetComponent<Image>().color = new Color32(159, 159, 159, 255);
        }
        if (String.Compare(cannonsEnabled, "Enabled") == 0 )
        {
            cannon.GetComponent<SpriteRenderer>().enabled = true;
            cannonIcon.GetComponent<Image>().color = new Color32(0, 255, 23, 255);
        }
        else
        {
            cannon.GetComponent<SpriteRenderer>().enabled = false;
            cannonIcon.GetComponent<Image>().color = new Color32(159, 159, 159, 255);
        }
        if (String.Compare(incomingTorpedo, "true") == 0)
        {
            oponentTorpedoIcon.GetComponent<Image>().color = new Color32(0, 255, 23, 255);
        }
        else
        {
            oponentTorpedoIcon.GetComponent<Image>().color = new Color32(159, 159, 159, 255);
        }
    }
}
