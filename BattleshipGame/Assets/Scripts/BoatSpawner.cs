using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    public float border;
    private float left_border;
    private float right_border;
    public Transform ship;

    // Start is called before the first frame update
    void Start()
    {
        left_border = ship.position.x - border;
        right_border = ship.position.x + border;
        bool cont = true;
        while (cont)
        {
            float randompos = Random.Range(left_border, right_border);
            if (!(randompos >= ship.position.x - 100 && randompos <= ship.position.x + 100))
            {
                cont = false;
                ship.Translate(randompos - ship.position.x, 0, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
