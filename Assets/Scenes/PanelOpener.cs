using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;

    public GameObject Button; // Reference to the button you want to hide/show

    public GameObject Image;

    void Update()
    {
        bool isCurrentlyActive = Panel.activeSelf; //UI uses different SetActives from GameObjects
        // Check if J is pressed
        if (Input.GetKeyDown(KeyCode.J))
        {
            // Toggle the active state of both the panel and button
            
            Panel.SetActive(!isCurrentlyActive);
            Button.SetActive(!isCurrentlyActive);
            Image.SetActive(!isCurrentlyActive);
        }
        /* if (Input.GetKeyDown(KeyCode.I))
         * {
         *      show the whole item inventory
         *      activate the canvas 
         *      activate the panel
         *      activate all the buttons in their respective locations
         * }
         */
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            Debug.Log("Button clicked");
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
  
     
}
    
    
    


