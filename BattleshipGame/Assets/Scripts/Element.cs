
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Element : MonoBehaviour{
    public GameObject repairGameManager;
   
  //Var declaration for code
    public int guessCount = 11;
    //Vector2 winCoord;
    //Vector2 clickVector;
    //float dist;
    public bool endGame = false;
    
    //public int x_dist;
    //public Tilemap map;
    //used for RepairManager connection
  
    private int funcReturnVar;
    public SpriteRenderer tileSprite;
    
    //public SpriteRenderer spriteRenderer;

    //Coordinates for the tiles
    public int x_pos; 
    public int y_pos;

    //public int deci;
    

    //array for the other spritestextures and sep one for mine
    //Allows for display of different tiles 
   // public Sprite repairTexture;

    void Start(){
        tileSprite = GetComponent<SpriteRenderer>();

        // Debug.Log(HexaToDeci("FF"));
        
        //repairGameManager = GameObject.FindObjectOfType<repairGameManager>();
    }
    
    
    //public bool isCovered() {
     //   return GetComponent<SpriteRenderer>().sprite.texture.name == "Default";
    //}
    //on mouse click I need to display/reveal a tile \
    //behind the tile; is either an X for wrong or the tool if right guess

// On each mouse click we need to send the x_pos and y_pos to the manager
    //Will handle the check
    public void OnMouseUpAsButton () 
    {
        if(!endGame)
      {//pass the x_pos and the y_pos to the repair game manager script
        //call the CheckCoordinates function from manager script
            print("x coord: "+x_pos);
            print("y coord: "+y_pos);

            //Call the function in RepairGameManager
            //Grab the associated function return value 
            //from here depeding on the value set the tile to right hue color
            repairGameManager = GameObject.Find("repairGameManager");
            funcReturnVar = repairGameManager.GetComponent<repairGameManager>().CheckCoordinates(x_pos,y_pos);
            print("Return value from the function = "+funcReturnVar);

            //**Grab the color from the tileSprite 
            //Based on return value from the function call above

            //
            /*
            if(funcReturnVar == 100)
            {
                
                 GetComponent<SpriteRenderer>().sprite = emptyTextures[1];
                //tileSprite.color = new Color(1,0,0,1);

            }
            //
            else if(funcReturnVar == 101)
            {
                GetComponent<SpriteRenderer>().sprite = emptyTextures[2];
                //tileSprite.color = new Color(1,0,0,0.9f);
            }
            //
            else if(funcReturnVar == 111)
            {
                GetComponent<SpriteRenderer>().sprite = emptyTextures[3];
                 //tileSprite.color = new Color(1,0,0,0.6f);
            }
            //
            //
            else if(funcReturnVar == 200)
            {
                GetComponent<SpriteRenderer>().sprite = emptyTextures[0];

            }
        
            else if(funcReturnVar == 201)
            {
                GetComponent<SpriteRenderer>().sprite = emptyTextures[4];
            }
            else if(funcReturnVar == 202)
            {
                GetComponent<SpriteRenderer>().sprite = emptyTextures[5];
            }
            else if(funcReturnVar == 1){
                GetComponent<SpriteRenderer>().sprite = emptyTextures[1];
            }
            else if (funcReturnVar == 777)
            {
                endGame = true;
            }*/


            //placeholder


            // GetComponent<SpriteRenderer>().sprite = emptyTextures[0];

            if(funcReturnVar == 0)
            {
                tileSprite.color = new Color(0, 0, 0, 1);
                endGame = true;
            }
            if (funcReturnVar == 1)
            {
                tileSprite.color = new Color(.333f, 0, 0, 1);
            }
            if (funcReturnVar == 2)
            {
                tileSprite.color = new Color(.666f, 0, 0, 1);
            }
            if (funcReturnVar == 3)
            {
                tileSprite.color = new Color(1, 0, 0, 1);
            }
            if (funcReturnVar == 4)
            {
                tileSprite.color = new Color(1, .25f, .25f, 1);
            }
            if (funcReturnVar == 5)
            {
                tileSprite.color = new Color(1, .5f, .5f, 1);
            }


        }
    }
    
}
