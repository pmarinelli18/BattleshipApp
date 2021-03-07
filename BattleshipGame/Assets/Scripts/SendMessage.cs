using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using UnityEngine.UI;
using System.Security.Cryptography;

public class SendMessage : MonoBehaviour
{
    // Start is called before the first frame update
    public Text UsernameTextBox;
    public Text PasswordTextBox;
    public Text ErrorMsg;
    public GameObject myObject;
    
    public void Login()
    {
        myObject = GameObject.Find("AccountManager");
        string usr = UsernameTextBox.text.ToString();
        string psw = PasswordTextBox.text.ToString();
        if (usr == "" || psw == "")
        {
            ErrorMsg.text = "Please enter a username or password";
        }
        /*byte[] data = System.Text.Encoding.ASCII.GetBytes(usr);
        data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
        usr = System.Text.Encoding.ASCII.GetString(data);
        byte[] data = System.Text.Encoding.ASCII.GetBytes(psw);
        data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
        psw = System.Text.Encoding.ASCII.GetString(data);*/
        else
        {
            var newSalt = GenerateSalt();
            var hashedPassword = ComputeHash(Encoding.UTF8.GetBytes(psw), Encoding.UTF8.GetBytes(newSalt));
            string submit = "auth/login?userName=" + usr + "&password=" + hashedPassword;
            myObject.GetComponent<AccountAuthentication>().SendMessage(submit);
            myObject.GetComponent<AccountAuthentication>().userName = usr;
        }

    }
    public void CreateAccount()
    {
        myObject = GameObject.Find("AccountManager");
        string usr = UsernameTextBox.text.ToString();
        string psw = PasswordTextBox.text.ToString();
        var newSalt = GenerateSalt();
        var hashedPassword = ComputeHash(Encoding.UTF8.GetBytes(psw), Encoding.UTF8.GetBytes(newSalt));
        if (usr == "" || psw == "")
        {
            ErrorMsg.text = "Please enter a username or password";
        }
        else
        {
            string submit = "auth/createAccount?userName=" + usr + "&password=" + hashedPassword;
            myObject.GetComponent<AccountAuthentication>().SendMessage(submit);
            myObject.GetComponent<AccountAuthentication>().userName = usr;
        }

    }

    public void StartGame()
    {
        //msg ? string = Message to print
        myObject = GameObject.Find("AccountManager");
        string submit = "game/startGame";
        myObject.GetComponent<AccountAuthentication>().SendMessage(submit);

    }

    public void SendMSG()
    {
        //msg ? string = Message to print
        myObject = GameObject.Find("AccountManager");
        string submit = "msg?string=this is the message";
        myObject.GetComponent<AccountAuthentication>().SendMessage(submit);

    }
    public string ComputeHash(byte[] bytesToHash, byte[] salt)
    {
        var byteResult = new Rfc2898DeriveBytes(bytesToHash, salt, 10000);
        return Convert.ToBase64String(byteResult.GetBytes(24));
    }
    public string GenerateSalt()
    {
        var bytes = new byte[128 / 8];
        var rng =   new RNGCryptoServiceProvider();
        var str = "thisIsTest";
        bytes = Encoding.ASCII.GetBytes(str);
        //rng.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
}
