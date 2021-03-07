using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScreemHandler : MonoBehaviour
{
	private GameObject accountManager;


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
}
