using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateMe : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TimerCountdown;
    void Start()
    {
        TimerCountdown = GameObject.Find("TimerController");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(TimerCountdown.GetComponent<TimerCountdown>().isStart())
            gameObject.transform.rotation = Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z + 90);
    }
}
