using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMines : MonoBehaviour
{
    public GameObject mine;
    public float spawnInterval;
    public float screenleft;
    public float screenright;
    public Text timeup;

    // Start is called before the first frame update
    public void StartGame()
    {
        StartCoroutine(spawn());
    }

    private void spawnL(float spawny)
    {
        GameObject new_mine = Instantiate(mine) as GameObject;
        new_mine.transform.position = new Vector3(Camera.main.transform.position.x - (Camera.main.aspect * Camera.main.orthographicSize), spawny, 0);
    }

    private void spawnR(float spawny)
    {
        GameObject new_mine = Instantiate(mine) as GameObject;
        new_mine.transform.position = new Vector3(Camera.main.transform.position.x + (Camera.main.aspect * Camera.main.orthographicSize), spawny, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawn()
    {
        while (true)
        {
            if (timeup.enabled == false)
            {
                yield return new WaitForSeconds(spawnInterval);
                
                float val2 = Camera.main.transform.position.y;
                float val1 = (float)((int)(Camera.main.transform.position.y + 0.01f) + (2 * Random.Range(0,7)));
                int ran = (int)val1 % 4;
                if ((int)val1 % 2 == 1)
                {
                    val1 = val1 + 1.0f;
                }
                Debug.Log("Spawn: " + val1 + "; Camera: " + val2);
                if (ran == 0)
                {
                    spawnL(val1);
                }
                else
                {
                    spawnR(val1);
                }
            }
            else
            {
                break;
            }
        }
    }
}