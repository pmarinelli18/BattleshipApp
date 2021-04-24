using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class repairGameManager : Element
{ //ref to script im accessing
    //public Element E;

    public int GC = 7;

    public Text guessText;
    private int rand_X;
    private int rand_Y;
    //public int check;
    public GameObject AccountManager;
    public GameObject Instructions;
    private bool gameStart = false;
    

    


    //int vars for color converter method
    

    //private Vector2 winCoord;

    //UI Elements variable containers
    //public Text countHeader;
    //public Text gameDesc;
    //public Text guessNum;
    public Text winText;
    public Text lossText;
    public Transform returnButton;
    

    //UI grid label elements
        //each a text object set to false on win loss screen
    //public Text xLabel;
    
    
    

   void Start () 
    {
        print("1st load");
        //Set win/loss ui elements to false that
        winText.gameObject.SetActive(false);
        lossText.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        AccountManager = GameObject.Find("AccountManager");
       
     

       //On game start generate the random coordinate the player clicks to win
        rand_X = Random.Range(1,6);
        rand_Y = Random.Range(1,6);

        //winCoord = new Vector2(rand_X,rand_Y);
        
        

       // print("(statement from manager script) win coord is: " +winCoord);
        //print("(_)x value = " +rand_X);
        //print("(_)y value = "+rand_Y);
        //print("from manager, x_ pos "+x_pos);


        // if(spriteRenderer.sprite == null)
        // {// spriteRenderer.sprite = repairSprite;}
        // x = Random.Range(-8.6981f, 0.304300f);
        // y = Random.Range(-2.362f, 6.633289f);
        // pos1 = new Vector2 (x,y);
        
    }

  //function to handle the comparison
    public int CheckCoordinates(int x_pos, int y_pos){
        if(!gameStart)
        {
            gameStart = true;
            Instructions.SetActive(false);
        }
        GC -= 1;
        guessText.text = GC.ToString();

        // print("x_pos from manager = "+x_pos);

        if (GC < 0)
        {
            endGame(false);
        }
         
    // blue3 is darkest then blue2 then blue1
        int distX = Mathf.Abs(rand_X - x_pos);
        int distY = Mathf.Abs(rand_Y - y_pos);
        //print("x distance = " +distX);
        //print("y distance = "+distY);

        if (distX == 0 && distY == 0)
        {
            endGame(true);
            //print("win!!!");

            return 0;
        }
        else
        {
            if (distX > distY)
                return distX;
            else
                return distY;
        }
        /*  if(distX == 0 & distY != 0){
              if(distY == 3)
              {
                  return blue3;
              }
              else if(distY == 2){
                  return blue2;
              }
              else if(distX == 1){
                  return blue1;
              }
          }

          else if(distY == 0 & distX != 0){
              if(distX == 3){
                  return redCase3;
              }
              else if(distY == 2){
                  return redCase2;
              }
              else if(distY == 1){
                  return redCase1;
              }
          }

          else if(distX == distY & distX != 0 & distY != 0){
               if(distX == 3)
              {
                  return redCase3;
              }
              else if(distX == 2){
                  return redCase2;
              }
              else if(distX == 1){
                  return redCase1;
              }
          }

          else if(distX > distY & distX != 0 & distY != 0)
          {
              if(distX == 3)
              {
                  return redCase3;
              }
              else if(distX == 2){
                  return redCase2;
              }
              else if(distX == 1){
                  return redCase1;
              }
          }
          else if(distY> distX & distX != 0 & distY != 0)
          {
              if(distY == 3)
              {
                  return blue3;
              }
              else if(distY == 2){
                  return blue2;
              }
              else if(distX == 1){
                  return blue1;
              }
          }
          */




        // if(distX == 0 & distY != 0){
        //     if(distX == 3){
        //         return blue3;
        //     }
        //     else if(distX == 2){
        //         return blue2;
        //     }
        //     else if(distX == 1){
        //         return blue1;
        //     }
        // }

        // else if(distY == 0 & distX != 0){
        //     if(distY == 3){
        //         return redCase3;
        //     }
        //     else if(distY == 2){
        //         return redCase2;
        //     }
        //     else if(distY == 1){
        //         return redCase1;
        //     }
        // }




        // if(distX > distY & distX != 0)
        // {
        //     print("Negative x and negative y");
        //     //add more checks to see by how much bigger 
        //     //return diffent num accordingly; correlates to blue hue
        //         //better visiblity to see how close they are 
        //     return redCase1;
        // }

        // else if( distX < 0 & distY >= 0 )
        // {
        //     print("Negative x and positve Y ");
        //     return redCase2;
        // }
        // //Red Case 3 color
        // //Pos distX and Neg distY
        // else if (distX >= 0 & distY < 0){
        //     print("Positive X and Negative Y");
        //     return redCase3;

        // }
        // //Red Case 4 color
        // // Both Positive values 
        // else if( distX >= 0 & distY >= 0)
        // {
        //     print("Positive x and y");
        //     if(distX > distY)
        //     {
        //         //display different green
        //         print("distX is greater than distY");
        //         return Green2;
        //     }
        //     if(distY > distX)
        //     {
        //         print("distY is greater than distX");
        //         return Green3;
        //     }
        //     else if(distX == 0 & distY == 0)
        // {
        //     endGame(true);
        //     print("win!!!");

        //     return win;
        // }
        //     return Green1;
        // }

        // else if(distX == 0 & distY == 0)
        // {
        //     endGame(true);
        //     print("win!!!");

        //     return win;
        // }
        //return distX;
    }

    void endGame(bool win){
        
        guessText.gameObject.SetActive(false);
        //gameDesc.gameObject.SetActive(false);
        //countHeader.gameObject.SetActive(false);
        //map.gameObject.SetActive(false);
        string submit;
        if(win)
        {
            winText.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(true);
            submit = "game/fixRadar";

        }
        else
        {
            lossText.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(true);
            submit = "game/lostGame";

        }

        AccountManager.GetComponent<AccountAuthentication>().SendMessage(submit);

    }


    /*void Update(){

        if(Input.GetMouseButtonUp(0))
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0; 


             GC -= 1;
            guessText.text = GC.ToString();

           // print("x_pos from manager = "+x_pos);
            
             if ( GC < 0 )
            {
                endGame(false);
            }
            
            
            

            
        }

    }*/



    // Start is called before the first frame update
    

    // Update is called once per frame
    
   
}
