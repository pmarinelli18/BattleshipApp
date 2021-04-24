using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minerender : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    public float screenleft;
    public float screenright;

    // Start is called before the first frame update
    void Start()
    {
        screenleft = Camera.main.transform.position.x - (Camera.main.aspect * Camera.main.orthographicSize) - 10;
        screenright = Camera.main.transform.position.x + (Camera.main.aspect * Camera.main.orthographicSize) + 10;
        rb = this.GetComponent<Rigidbody2D>();
        //ran = Random.Range(0, 2);
        if (transform.position.x > Camera.main.transform.position.x)
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
        if ((transform.position.x < screenleft) || (transform.position.x > screenright))
        {
            Destroy(this.gameObject);
        }
    }
}
