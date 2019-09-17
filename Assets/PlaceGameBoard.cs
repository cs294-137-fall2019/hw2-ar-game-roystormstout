﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// These allow us to use the ARFoundation API.
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class PlaceGameBoard : MonoBehaviour
{
    // Public variables can be set from the unity UI.
    // We will set this to our Game Board object.
    public GameObject gameBoard;
    public GameObject ARcamera;
    public Text hintText;
    public Button moveBtn;
    // These will store references to our other components.
    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    // This will indicate whether the game board is set.
    private bool placed = false;


    // Start is called before the first frame update.
    void Start()
    {
        // GetComponent allows us to reference other parts of this game object.
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame.
    void Update()
    {
        if (!placed)
        {
            if (Input.touchCount > 0)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;

                // Raycast will return a list of all planes intersected by the
                // ray as well as the intersection point.
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                if (raycastManager.Raycast(
                    touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    // The list is sorted by distance so to get the location
                    // of the closest intersection we simply reference hits[0].
                    var hitPose = hits[0].pose;
                    // Now we will activate our game board and place it at the
                    // chosen location.
                    gameBoard.SetActive(true);
                    Vector3 relativePos = hitPose.position - ARcamera.transform.position;
                    Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                    rotation.x = 0;
                    rotation.z = 0;
                    gameBoard.transform.rotation = rotation;
                    gameBoard.transform.position = hitPose.position;
                    placed = true;
                    // After we have placed the game board we will disable the
                    // planes in the scene as we no longer need them.

                    SetTrackablesActive(false);

                }
            }
        }
        else
        {
            // The plane manager will set newly detected planes to active by
            // default so we will continue to disable these.
            SetTrackablesActive(false);
        }
    }

    // If the user places the game board at an undesirable location we
    // would like to allow the user to move the game board to a new location.
    public void AllowMoveGameBoard()
    {
        placed = false;
        SetTrackablesActive(true);
    }

    // Lastly we will later need to allow other components to check whether the
    // game board has been places so we will add an accessor to this.
    public bool Placed()
    {
        return placed;
    }


    private void SetTrackablesActive(bool setToState)
    {
        hintText.gameObject.SetActive(setToState);
        moveBtn.gameObject.SetActive(!setToState);
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(setToState);
        }

    }
}