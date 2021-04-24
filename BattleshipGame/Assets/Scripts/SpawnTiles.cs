using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnTiles : MonoBehaviour
{
    public GameObject Tile_curved;
    public GameObject Tile_straight;
    private GameObject[] tiles;
    private int[] reserved;
    public Text win;
    public Text timer;
    public Transform continuebutton;
    private GameObject AccountManager;
    private bool gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        win.enabled = false;
        continuebutton.gameObject.SetActive(false);
        AccountManager = GameObject.Find("AccountManager");
        gameEnd = false;

        int p = 0;
        tiles = new GameObject[20];
        reserved = new int[20];
        for (int i = 0; i < 20; i++)
        {
            reserved[i] = 0;
        }
        int layout = Random.Range(0, 4);
        if (layout == 0) //1 = straight; 2 = curved
        {
            reserved[0] = 2;
            reserved[1] = 1;
            reserved[2] = 1;
            reserved[3] = 2;
            reserved[4] = 1;
            reserved[8] = 1;
            reserved[12] = 1;
            reserved[16] = 1;
        }
        else if (layout == 1)
        {
            reserved[16] = 2;
            reserved[17] = 1;
            reserved[18] = 2;
            reserved[14] = 2;
            reserved[13] = 2;
            reserved[9] = 1;
            reserved[5] = 1;
            reserved[1] = 2;
            reserved[2] = 1;
            reserved[3] = 2;
        }
        else if (layout == 2)
        {
            reserved[16] = 1;
            reserved[12] = 2;
            reserved[13] = 1;
            reserved[14] = 1;
            reserved[15] = 2;
            reserved[11] = 1;
            reserved[7] = 1;
            reserved[3] = 1;
        }
        else
        {
            reserved[16] = 1;
            reserved[12] = 2;
            reserved[13] = 2;
            reserved[9] = 1;
            reserved[5] = 1;
            reserved[1] = 2;
            reserved[2] = 2;
            reserved[6] = 2;
            reserved[7] = 2;
            reserved[3] = 1;
        }
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                if (reserved[p] > 0)
                {
                    if (reserved[p] == 1)
                    {
                        GameObject new_tile_straight = Instantiate(Tile_straight) as GameObject;
                        new_tile_straight.transform.position = new Vector3((-1.5f + (float)x), (1.5f - (float)y), 0);
                        new_tile_straight.name = "straight" + x.ToString() + y.ToString();
                        int ran2 = Random.Range(0, 2);
                        if (ran2 == 0)
                        {
                            new_tile_straight.transform.rotation = Quaternion.Euler(0, 0, 90);
                        }
                        tiles[p] = new_tile_straight;
                        p++;
                    }
                    else
                    {
                        GameObject new_tile_curved = Instantiate(Tile_curved) as GameObject;
                        new_tile_curved.transform.position = new Vector3((-1.5f + (float)x), (1.5f - (float)y), 0);
                        new_tile_curved.name = "curved" + x.ToString() + y.ToString();
                        int ran2 = Random.Range(0, 4);
                        if (ran2 == 0)
                        {
                            new_tile_curved.transform.rotation = Quaternion.Euler(0, 0, 90);
                        }
                        else if (ran2 == 1)
                        {
                            new_tile_curved.transform.rotation = Quaternion.Euler(0, 0, 180);
                        }
                        else if (ran2 == 2)
                        {
                            new_tile_curved.transform.rotation = Quaternion.Euler(0, 0, 270);
                        }
                        tiles[p] = new_tile_curved;
                        p++;
                    }
                }
                else
                {
                    int ran = Random.Range(0, 2);
                    if (ran == 0)
                    {
                        GameObject new_tile_curved = Instantiate(Tile_curved) as GameObject;
                        new_tile_curved.transform.position = new Vector3((-1.5f + (float)x), (1.5f - (float)y), 0);
                        new_tile_curved.name = "curved" + x.ToString() + y.ToString();
                        int ran2 = Random.Range(0, 4);
                        if (ran2 == 0)
                        {
                            new_tile_curved.transform.rotation = Quaternion.Euler(0, 0, 90);
                        }
                        else if (ran2 == 1)
                        {
                            new_tile_curved.transform.rotation = Quaternion.Euler(0, 0, 180);
                        }
                        else if (ran2 == 2)
                        {
                            new_tile_curved.transform.rotation = Quaternion.Euler(0, 0, 270);
                        }
                        tiles[p] = new_tile_curved;
                        p++;
                    }
                    else
                    {
                        GameObject new_tile_straight = Instantiate(Tile_straight) as GameObject;
                        new_tile_straight.transform.position = new Vector3((-1.5f + (float)x), (1.5f - (float)y), 0);
                        new_tile_straight.name = "straight" + x.ToString() + y.ToString();
                        int ran2 = Random.Range(0, 2);
                        if (ran2 == 0)
                        {
                            new_tile_straight.transform.rotation = Quaternion.Euler(0, 0, 90);
                        }
                        tiles[p] = new_tile_straight;
                        p++;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int won = -1;
        if (timer.text == "0")
        {
            foreach (GameObject tile in tiles)
            {
                tile.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (gameEnd == false)
        {
            foreach (GameObject tile in tiles)
            {
                (tile.GetComponent<SpriteRenderer>()).color = new Color(1, 1, 1, 1);
            }
            won = tracepath(20, -1);
        }
        if (won == 1 && gameEnd == false)
        {
            gameEnd = true;
            win.enabled = true;
            timer.text = "0";
            string submit;
            submit = "game/hackRadar";
            continuebutton.gameObject.SetActive(true);
            AccountManager.GetComponent<AccountAuthentication>().SendMessage(submit);
        }
        else if (timer.text == "0" && gameEnd == false)
        {
            gameEnd = true;
            string submit;
            submit = "game/lostGame";
            continuebutton.gameObject.SetActive(true);
            AccountManager.GetComponent<AccountAuthentication>().SendMessage(submit);
        }
    }

    int tracepath(int from, int prev)
    {
        if (from == 20)
        {
            //start tile is 16
            GameObject tilestart = tiles[16];
            if (tilestart.name.Contains("straight"))
            {
                //Debug.Log((int)tilestart.transform.rotation.eulerAngles.z);
                if ((int)tilestart.transform.rotation.eulerAngles.z % 180 == 0)
                {
                    (tilestart.GetComponent<SpriteRenderer>()).color = new Color(0, 0, 1, 1);
                    return tracepath(16, from);
                }
                else
                {
                    (tilestart.GetComponent<SpriteRenderer>()).color = new Color(1, 1, 1, 1);
                    return -1;
                }
            }
            else if (tilestart.name.Contains("curved"))
            {
                if ((int)tilestart.transform.rotation.eulerAngles.z == 0 ||
                    (int)tilestart.transform.rotation.eulerAngles.z == 270)
                {
                    (tilestart.GetComponent<SpriteRenderer>()).color = new Color(0, 0, 1, 1);
                    return tracepath(16, from);
                }
                else
                {
                    (tilestart.GetComponent<SpriteRenderer>()).color = new Color(1, 1, 1, 1);
                    return -1;
                }
            }
        }
        else if (from >= 0 && from < 20)
        {
            //from is already filled, prev is only used for determining where the water came in
            int goal = 0;
            GameObject tilestart = tiles[from];
            //find goal
            if (tilestart.name.Contains("straight"))
            {
                if (prev == from + 4)
                {
                    goal = from - 4;
                }
                else if (prev == from - 4)
                {
                    goal = from + 4;
                }
                else if (prev == from - 1)
                {
                    goal = from + 1;
                }
                else if (prev == from + 1)
                {
                    goal = from - 1;
                }
            }
            else if (tilestart.name.Contains("curved"))
            {
                int angle = (int)tilestart.transform.rotation.eulerAngles.z;
                if (prev == from + 4) //below (0)
                {
                    if (angle == 0)
                    {
                        goal = from + 1;
                    }
                    else if (angle == 270)
                    {
                        goal = from - 1;
                    }
                }
                else if (prev == from - 4) //above (180)
                {
                    if (angle == 90)
                    {
                        goal = from + 1;
                    }
                    else if (angle == 180)
                    {
                        goal = from - 1;
                    }
                }
                else if (prev == from - 1) //left (270)
                {
                    if (angle == 180)
                    {
                        goal = from - 4;
                    }
                    else if (angle == 270)
                    {
                        goal = from + 4;
                    }
                }
                else if (prev == from + 1) //right (90)
                {
                    if (angle == 0)
                    {
                        goal = from + 4;
                    }
                    else if (angle == 90)
                    {
                        goal = from - 4;
                    }
                }
            }
            //Debug.Log(goal);
            //check if goal works
            if (adjacent(from, goal) && goal < 20 && goal >= -1)
            {
                //top right block is goal and goal works
                if (goal == -1)
                {
                    return 1;                               //WIN CONDITION
                }
                GameObject goalobj = tiles[goal];
                int goalangle = (int)goalobj.transform.rotation.eulerAngles.z;
                //Possible goal layouts
                if (goal == from - 1) //left
                {
                    if (goalobj.name.Contains("straight"))
                    {
                        if (goalangle % 180 == 90)
                        {
                            (goalobj.GetComponent<SpriteRenderer>()).color = new Color(0, 0, 1, 1);
                            return tracepath(goal, from);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        if (goalangle == 0 || goalangle == 90)
                        {
                            (goalobj.GetComponent<SpriteRenderer>()).color = new Color(0, 0, 1, 1);
                            return tracepath(goal, from);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                else if (goal == from + 1) //right
                {
                    if (goalobj.name.Contains("straight"))
                    {
                        if (goalangle % 180 == 90)
                        {
                            (goalobj.GetComponent<SpriteRenderer>()).color = new Color(0, 0, 1, 1);
                            return tracepath(goal, from);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        if (goalangle == 180 || goalangle == 270)
                        {
                            (goalobj.GetComponent<SpriteRenderer>()).color = new Color(0, 0, 1, 1);
                            return tracepath(goal, from);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                else if (goal == from + 4) //below
                {
                    if (goalobj.name.Contains("straight"))
                    {
                        if (goalangle % 180 == 0)
                        {
                            (goalobj.GetComponent<SpriteRenderer>()).color = new Color(0, 0, 1, 1);
                            return tracepath(goal, from);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        if (goalangle == 90 || goalangle == 180)
                        {
                            (goalobj.GetComponent<SpriteRenderer>()).color = new Color(0, 0, 1, 1);
                            return tracepath(goal, from);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                else if (goal == from - 4) //above
                {
                    if (goalobj.name.Contains("straight"))
                    {
                        if (goalangle % 180 == 0)
                        {
                            (goalobj.GetComponent<SpriteRenderer>()).color = new Color(0, 0, 1, 1);
                            return tracepath(goal, from);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        if (goalangle == 0 || goalangle == 270)
                        {
                            (goalobj.GetComponent<SpriteRenderer>()).color = new Color(0, 0, 1, 1);
                            return tracepath(goal, from);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            else
            {
                return -1;
            }
        }
        return -1;
    }

    bool adjacent(int me, int you)
    {
        if (me % 4 == 0) //far left
        {
            if (me - 1 == you)
            {
                return false;
            }
        }
        else if (me % 4 == 3) //far right
        {
            if (me + 1 == you)
            {
                return false;
            }
        }
        return true;
    }
}
