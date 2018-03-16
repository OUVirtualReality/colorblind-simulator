using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Wilberforce;

public class ColorSwitcher : MonoBehaviour {

    public Camera vrCamera;
    public Text colorText;
    private Hand hand;
    private string[] types = new string[] {"Normal Vision", "Protanopia", "Deuteranopia", "Tritanopia"};

	// Use this for initialization
	void Start () {
        hand = this.GetComponent<Hand>();
	}
	
	// Update is called once per frame
	void Update () {
        if (hand.GetStandardInteractionButtonUp())
        {
            if (vrCamera.GetComponent<Colorblind>().Type < types.Length - 1)
            {
                vrCamera.GetComponent<Colorblind>().Type += 1;
            }
            else
            {
                vrCamera.GetComponent<Colorblind>().Type = 0;
            }

            colorText.text = types[vrCamera.GetComponent<Colorblind>().Type];
        }
	}
}
