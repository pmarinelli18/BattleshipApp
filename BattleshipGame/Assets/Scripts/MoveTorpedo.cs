using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTorpedo : MonoBehaviour
{
    public Transform torpedo;
    public float VerticalMovement;
    public float HorizontalMovement;
    public float delaytime;
    public int steps;
    public float screenbound;
    public Text timeup;
    public bool gameStart;


    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUp()
    {
        if (gameStart)
        {
            if (timeup.enabled == false)
            {
                for (int i = 0; i < steps; i++)
                {
                    StartCoroutine(MoveUpI(i));
                }
            }
        }
    }

    public IEnumerator MoveUpI(int i)
    {
        yield return new WaitForSeconds(delaytime * i);
        Vector3 temp = torpedo.position;
        temp.y += VerticalMovement / steps;
        torpedo.position = temp;
    }

    public void MoveRight()
    {
        if (gameStart)
        {
            if (timeup.enabled == false)
            {
                for (int i = 0; i < steps; i++)
                {
                    StartCoroutine(MoveRightI(i));
                    //Debug.Log("Move Right" + i);
                }
            }
        }
    }

    public IEnumerator MoveRightI(int i)
    {
        if (Camera.main.transform.position.x + 3 + (HorizontalMovement / steps) < screenbound)
        {
            yield return new WaitForSeconds(delaytime * i);
            Vector3 temp = torpedo.position;
            temp.x += HorizontalMovement / steps;
            torpedo.position = temp;
        }
    }

    public void MoveLeft()
    {
        if (gameStart)
        {
            if (timeup.enabled == false)
            {
                for (int i = 0; i < steps; i++)
                {
                    StartCoroutine(MoveLeftI(i));
                }
            }
        }
    }

    public IEnumerator MoveLeftI(int i)
    {
        if (Camera.main.transform.position.x - 3 - (HorizontalMovement / steps) > -screenbound)
        {
            yield return new WaitForSeconds(delaytime * i);
            Vector3 temp = torpedo.position;
            temp.x -= HorizontalMovement / steps;
            torpedo.position = temp;
        }
    }
    public void StartGame()
    {
        gameStart = true;
    }
}
