using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minerender : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D rb;
    public float screenleft;
    public float screenright;
    private int ran;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        ran = Random.Range(0, 2);
        //Debug.Log(ran);
        if (ran == 1)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //screenleft = Camera.main.transform.position.x - 2.5f;
        //screenright = Camera.main.transform.position.x + 2.5f;
        if ((transform.position.x < screenleft && ran == 1) || (transform.position.x > screenright && ran == 0))
        {
            Destroy(this.gameObject);
        }
    }
}
