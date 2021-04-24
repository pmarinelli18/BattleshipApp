/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class colorManager : Element
{
    //Create ref to empty sprite object
    public GameObject blankTileSprite;
    // Start is called before the first frame update
    // void Start()
    // {
    //     SpriteRenderer spriteRenderer = blankTileSprite.GetComponent<SpriteRenderer>(); 
    //    // spriteRenderer.color = new Color(0,1,1,0);
    //    print("The function is working and called correctly");
    //    Debug.Log(GetColorFromString("FFFF00"));
        
    // }

    //Helper Methods to convert color value into Hexadecimal at the end
    //
    //
    //
    public int HexToDeci(string hex) {
        //reciece hex string
        deci = System.Convert.ToInt32("FF", 16);
        return deci;
    }
    
    public string DeciToHex(int value){
        return value.ToString("X2");
    }

    public string FloatNormalizedToHex(float value){
        return DeciToHex(Mathf.RoundToInt(value *255f));
    }

    public float HexToFloatNorm(string hex){
        return HexToDeci(hex)/255f;
    }

    //End result method that is called in element
    //converts string to hex with help of above functions
    public Color GetColorFromString(string hexString){
        float red = HexToFloatNorm(hexString.Substring(0,2));
        float green = HexToFloatNorm(hexString.Substring(2,2));
        float blue = HexToFloatNorm(hexString.Substring(4,2));
        return new Color(red,green,blue);
    }




}*/
