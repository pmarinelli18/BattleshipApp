using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapFire : MonoBehaviour
{
    // Start is called before the first frame update
    private float health;
    public GameObject Fire;
    public bool active;

    void Start()
    {
        health = 0f;
        active = true;
    }
    void OnMouseUpAsButton()
    {
        if (active)
        {
            if (health < 100)
            {
                health += 10;
                //Fire.GetComponent<ParticleSystem>().main.startColor = new Color(255, 86, 30, 255 * health);
                var main = Fire.GetComponent<ParticleSystem>().main;
                Debug.Log(main.startColor);
                main.startColor = new Color(1f, .33f, .11f, ((100-health) / 100f));
                Debug.Log(255 * health / 100);
            }
            else
            {
                Fire.SetActive(false);

            }
                
        }
 
    }
    public void setActive(bool set)
    {
        Fire.SetActive(true);
        active = set;
    }
    public float endGame()
    {
        active = false;
        return health;
    }
}
