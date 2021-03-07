using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getUsersOnStart : MonoBehaviour
{
    public GameObject myObject;
    // Start is called before the first frame update
    void Start()
    {
        myObject = GameObject.Find("AccountManager");
        Debug.Log(myObject.GetComponent<AccountAuthentication>().userName);
        string submit = "get/getUsers?userName=" + myObject.GetComponent<AccountAuthentication>().userName;
        myObject.GetComponent<AccountAuthentication>().SendMessage(submit);
    }
    
}
