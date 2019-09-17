using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ShootingPlaneBehavior : MonoBehaviour
{
    public Collider coll;
    public GameObject bullet;
    public float coolDownTime = 0.6f;
    private Camera arCamera;
    private float lastFired;

    void Start()
    {
        arCamera = GetComponent<ARSessionOrigin>().camera;
    }

    void Update()
    {
        // Move this object to the position clicked by the mouse.
        if (GameManager.isGameStarted() && Input.touchCount > 0 && Time.time - lastFired > coolDownTime)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            // Convert the 2d screen point into a ray.
            Ray ray = arCamera.ScreenPointToRay(touchPosition);
            // Check if this hits an object within 100m of the user.
            RaycastHit hit;

            if (coll.Raycast(ray, out hit, 100.0f))
            {
                Object.Instantiate(bullet, ray.origin, Quaternion.LookRotation(ray.direction));
                lastFired = Time.time;

            }
        }
    }
}
