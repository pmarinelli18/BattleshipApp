using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class guessCount : MonoBehaviour
{
    //Define variables
    //Score decrements on player count from 7 
    //initialze variable to store player clicks, var for the initial guess count
    public int playerClick;

    public int GC = 7;

    public Text guessText;

    // Update is called once per frame
    // Grab the player click and store it in the var and compare to 7; when click > 7 display 0 
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0; 
            GC -= 1; 

            guessText.text = GC.ToString();


            Debug.Log(pz);
            Debug.Log(GC);

            // if ( GC < 0 )
            // {
            //     SceneManager.LoadScene(10);
            // }

        }
        
    }
}
