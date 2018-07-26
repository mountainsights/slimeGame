using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000; // the texture's order in the draw hierarchy. Means it will be drawn last
    private float alpha = 1.0f;
    private int fadeDir = -1; // fade in or out

    private void OnGUI()
    {
        //good for rendering different graphics.
        //fade in and out using alpha and direction. 
        // a speed and time.deltaTime to convert the operation to seconds
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        //force clamp the alpha between 0 and 1 because alpha goes from 0 to 1
        alpha = Mathf.Clamp01(alpha);
        //set color of the GUI in this case our texture which will be black
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha); //set the alpha value
        GUI.depth = drawDepth;                                               //black will be drawn last
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);   //draw the texture to fit the screen size
    }

    //Set fade direction making the scene fade in if -1 and fade out if 1
       public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed); //return the fade speed variable so its easy to time the scene change
    }
   
    // OnLevelWasLoaded is called when a level is loaded 
    void OnLevelWasLoaded()
    {
        //alpha = 1;
        BeginFade(1); 
    }

}
