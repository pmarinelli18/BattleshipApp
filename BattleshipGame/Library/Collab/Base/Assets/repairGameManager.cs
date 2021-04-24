using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class repairGameManager : Element
{ //ref to script im accessing
    //public Element E;

    public int GC = 4;

    public Text guessText;
    public int rand_X;
    public int rand_Y;
    public int check;
    public GameObject AccountManager;
    

    


    //int vars for color converter method
    

    Vector2 winCoord;

    //UI Elements variable containers
    public Text countHeader;
    public Text gameDesc;
    public Text guessNum;
    public Text winText;
    public Text lossText;
    public Transform returnButton;
    public GameObject gridAxis;
    public Text xLabel;
    public Text yLabel;
    public Text xAxis1;
    public Text xAxis2;
    public Text xAxis3;
    public Text xAxis4;
    
    public Text yAxis1;
    public Text yAxis2;
    public Text yAxis3;
    public Text yAxis4;
    

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
        rand_X = Random.Range(1,4);
        rand_Y = Random.Range(1,4);

        winCoord = new Vector2(rand_X,rand_Y);
        
        

        print("(statement from manager script) win coord is: " +winCoord);
        print("(_)x value = " +rand_X);
        print("(_)y value = "+rand_Y);
        //print("from manager, x_ pos "+x_pos);


        // if(spriteRenderer.sprite == null)
        // {// spriteRenderer.sprite = repairSprite;}
        // x = Random.Range(-8.6981f, 0.304300f);
        // y = Random.Range(-2.362f, 6.633289f);
        // pos1 = new Vector2 (x,y);
        
    }

  //function to handle the comparison
    public int CheckCoordinates(int x_pos, int y_pos){
        GC -= 1;
        guessText.text = GC.ToString();
        
      
        //Variable for distance calculation
        int distX = 0;
        int distY = 0;

        //Variable for the red case hues
        int redCase1 = 100;
        int redCase2 = 101;
        int redCase3 = 111;
         
    // blue3 is darkest then blue2 then blue1
        int blue1 = 200;
        int blue2 = 201;
        int blue3 = 202;

        int outLier = 3;

        int win = 777;

        int posVal = 1;
        int negVal = 77;
        distX = Mathf.Abs(rand_X - x_pos);
        distY = Mathf.Abs(rand_Y - y_pos);
        print("x distance = " +distX);
        print("y distance = "+distY);

          if( GC == 0 & distX != 0 & distY != 0){
            endGame(false);
         }

            

        if(distX == 0 & distY != 0 & distY == 3){      
            return blue3;
        }

        else if(distX == 0 & distY != 0 & distY == 2){
                        // GC -= 1;
                        // guessText.text = GC.ToString(); 
            return blue2;
        }

        else if(distX == 0 & distY != 0 & distY == 1){
                        // GC -= 1;
                        // guessText.text = GC.ToString();
            return blue1;
        }

        else if(distY == 0 & distX != 0 & distX == 3){
                        // GC -= 1;
                        // guessText.text = GC.ToString();
            return redCase3;
         }

        else if(distY == 0 & distX != 0 & distX == 2){
                        // GC -= 1;
                        // guessText.text = GC.ToString();
            return redCase2;
        }

         else if(distY == 0 & distX != 0 & distX == 1){
                        // GC -= 1;
                        // guessText.text = GC.ToString();
            return redCase1;
         }


         else if(distY == 0 & distX != 0){
            if(distX == 3){
                        // GC -= 1;
                        // guessText.text = GC.ToString();
                return redCase3;
            }
            else if(distY == 2){
                        //     GC -= 1;
                        // guessText.text = GC.ToString();
                 return redCase2;
            }

            else if(distY == 1){
                        //     GC -= 1;
                        // guessText.text = GC.ToString();
                return redCase1;
            }
                        // GC -= 1;
                        // guessText.text = GC.ToString();
        }

                    else if(distX == distY & distX != 0 & distY != 0){
                        if(distX == 3)
                        {
                        //     GC -= 1;
                        // guessText.text = GC.ToString();
                            return redCase3;
                        }
                        else if(distX == 2){
                        //     GC -= 1;
                        // guessText.text = GC.ToString();
                            return redCase2;
                        }
                        else if(distX == 1){
                        //     GC -= 1;
                        // guessText.text = GC.ToString();
                        //     return redCase1;
                        }
                        // GC -= 1;
                        // guessText.text = GC.ToString();
                    }
                    
                    else if(distX > distY & distX != 0 & distY != 0)
                    {
                        if(distX == 3)
                        {
                        //     GC -= 1;
                        // guessText.text = GC.ToString();
                            return redCase3;
                        }
                        else if(distX == 2){
                        //     GC -= 1;
                        // guessText.text = GC.ToString();
                            return redCase2;
                        }
                        else if(distX == 1){
                        //     GC -= 1;
                        // guessText.text = GC.ToString();
                            return redCase1;
                        }
                        // GC -= 1;
                        // guessText.text = GC.ToString();
                    }
                    else if(distY> distX & distX != 0 & distY != 0)
                    {
                        if(distY == 3)
                        {
                        //     GC -= 1;
                        // guessText.text = GC.ToString();
                            return blue3;
                        }
                        else if(distY == 2){
                        //     GC -= 1;
                        // guessText.text = GC.ToString();
                            return blue2;
                        }
                        else if(distX == 1){
                        //     GC -= 1;
                        // guessText.text = GC.ToString();
                            return blue1;
                        }
                        // GC -= 1;
                        // guessText.text = GC.ToString();
                    }
                    else if(distX == 0 & distY == 0)
                    {
                        endGame(true);
                        print("win!!!");

                        return win;
                    }
                    
                    

                


        

        
        // if(distX == 0 & distY != 0 & distY == 3){
        //    return blue3;
        // }

        // else if(distX == 0 & distY != 0 & distY == 2){
        //    return blue2;
        // }

        //  else if(distX == 0 & distY != 0 & distY == 1){
        //    return blue1;
        // }

        //  else if(distY == 0 & distX != 0 & distX == 3){
        //    return redCase3;
        // }

        //  else if(distY == 0 & distX != 0 & distX == 2){
        //    return redCase2;
        // }

        //  else if(distY == 0 & distX != 0 & distX == 1){
        //    return redCase1;
        // }


        // else if(distY == 0 & distX != 0){
        //     if(distX == 3){
        //         return redCase3;
        //     }
        //     else if(distY == 2){
        //         return redCase2;
        //     }
        //     else if(distY == 1){
        //         return redCase1;
        //     }
        // }

        // else if(distX == distY & distX != 0 & distY != 0){
        //      if(distX == 3)
        //     {
        //         return redCase3;
        //     }
        //     else if(distX == 2){
        //         return redCase2;
        //     }
        //     else if(distX == 1){
        //         return redCase1;
        //     }
        // }
        
        // else if(distX > distY & distX != 0 & distY != 0)
        // {
        //     if(distX == 3)
        //     {
        //         return redCase3;
        //     }
        //     else if(distX == 2){
        //         return redCase2;
        //     }
        //     else if(distX == 1){
        //         return redCase1;
        //     }
        // }
        // else if(distY> distX & distX != 0 & distY != 0)
        // {
        //     if(distY == 3)
        //     {
        //         return blue3;
        //     }
        //     else if(distY == 2){
        //         return blue2;
        //     }
        //     else if(distX == 1){
        //         return blue1;
        //     }
        // }

        // else if(distX == 0 & distY == 0)
        // {
        //     endGame(true);
        //     print("win!!!");

        //     return win;
        // }
        
        return distX;
    }

    void endGame(bool win){
        gridAxis.gameObject.SetActive(false);
        xAxis1.gameObject.SetActive(false);
        xAxis2.gameObject.SetActive(false);
        xAxis3.gameObject.SetActive(false);
        xAxis4.gameObject.SetActive(false);
        yAxis1.gameObject.SetActive(false);
        yAxis2.gameObject.SetActive(false);
        yAxis3.gameObject.SetActive(false);
        yAxis4.gameObject.SetActive(false);
        guessNum.gameObject.SetActive(false);
        gameDesc.gameObject.SetActive(false);
        xLabel.gameObject.SetActive(false);
        yLabel.gameObject.SetActive(false);
        countHeader.gameObject.SetActive(false);
        map.gameObject.SetActive(false);
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


    void Update(){

        if(Input.GetMouseButtonUp(0))
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0; 


            //  GC -= 1;
            // guessText.text = GC.ToString();

           // print("x_pos from manager = "+x_pos);
            
            //  if ( GC == 0 )
            // {
            //     endGame(false);
            // }
            
            
            

            
        }

    }



    // Start is called before the first frame update
    

    // Update is called once per frame
    
   
}
