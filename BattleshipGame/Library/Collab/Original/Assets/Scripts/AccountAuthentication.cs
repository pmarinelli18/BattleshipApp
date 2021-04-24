using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using UnityEngine.UI;



public class AccountAuthentication : MonoBehaviour
{
    public string userName;
    public GameObject GameManager;
    TcpClient client = new TcpClient("10.20.0.75", 82);
    public GameObject recieverHandler;

    Queue messages = new Queue();
    void Start()
    {
        DontDestroyOnLoad(GameManager);
        
    }
    public void Connect()
    {
        ThreadStart childref = new ThreadStart(() => AttemptConnect());
        Thread childThread = new Thread(childref);
        childThread.Start();
    }
    
    public void AttemptConnect()
    {
        try
        {
            NetworkStream stream = client.GetStream();
            Byte[] bytes = new Byte[256];
            while (true)
            {
                if (messages.Count != 0)
                {
                    String next = messages.Dequeue().ToString();
                    bytes = System.Text.Encoding.ASCII.GetBytes(next);

                    stream.Write(bytes, 0, bytes.Length);
                }
                string data = null;
                
                
                String responseData = String.Empty;
                int i;

                while (stream.DataAvailable) {
                    bytes = new Byte[256];
                    Int32 bytesNum = stream.Read(bytes, 0, bytes.Length);
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, bytesNum);
                    //Console.WriteLine("Received: {0}", data);

                    // Process the data sent by the client.
                    UnityMainThread.wkr.AddJob(() => {
                        recieverHandler = GameObject.Find("SceneConnectionManger");
                        //Debug.Log("AA");
                        Debug.Log("AA" + data);
                        recieverHandler.GetComponent<RecieveMessage>().HandleMessage(data);
                    });
                   
                    /*byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                    if (data == "Success")
                    {
                        UnityMainThread.wkr.AddJob(() => { SceneManager.LoadScene("InGameScreen"); });
                    }
                    else
                    {
                        Debug.Log("Incorrect Password");
                        //UnityMainThread.wkr.AddJob(() => { ErrorMsg.text = "Incorrect username or password"; }); 
                    }*/
                }
            }
            stream.Close();
        }
        catch (Exception e)
        {
            //UnityMainThread.wkr.AddJob(() => { ErrorMsg.text = "Having trouble connecting to server"; });
            Debug.Log(e.ToString());
        }
    }
    public void SendMessage(string submit)
    {
        messages.Enqueue(submit);
    }
}
