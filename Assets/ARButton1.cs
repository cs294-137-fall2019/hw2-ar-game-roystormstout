using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adding OnTouch3D here forces us to implement the 
// OnTouch function, but also allows us to reference this
// object through the OnTouch3D class.
public class ARButton1 : MonoBehaviour, OnTouch3D
{

    private bool touched = false;
    public GameObject front;
    void Start()
    {
    }

    void Update()
    {
        
    }

    public void OnTouch()
    {
        // If a touch is found and we are not waiting,
        if (!touched)
        {
            // Move the object up by 10cm and reset the wait counter.
            touched = true;
            this.gameObject.transform.Translate(new Vector3(0, -0.04f, 0));
            front.SetActive(false);
			TextBehavior.triggerStartGame();
			//GameManager.startGame();
		}
	}
}
