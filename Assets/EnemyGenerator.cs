using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    public float generatingSpeed = 2.0f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameStarted() && !GameManager.isGameEnded())
        {
          
            timer += Time.deltaTime;

            // Check if we have reached beyond 2 seconds.
            // Subtracting two is more accurate over time than resetting to zero.
            if (timer > generatingSpeed)
            {
                Vector3 pos = this.transform.position;
                // Remove the recorded 2 seconds.
                timer = timer - generatingSpeed;
                pos.x += Random.Range(-0.195f, 0.195f);
                pos.z += Random.Range(0.035f, 0.095f);
                Object.Instantiate(enemy, pos, Quaternion.identity);
            }
        }
    }
}
