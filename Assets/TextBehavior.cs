using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBehavior : MonoBehaviour
{
    private float countdown = 3f;
    private static float triggeredTime;
    private Text gameText;
    private static bool triggered = false;
    private static int point;
    // Start is called before the first frame update

    public static TextBehavior instance;
    void Start()
    {
        gameText = this.gameObject.GetComponent<Text>();
        point = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(triggered)
        {
            if (triggeredTime + countdown <= Time.time)
            {

                gameText.text = "Time: " + ((int)(Time.time - triggeredTime - countdown)).ToString();
                triggered = false;
                GameManager.startGame();
            }
            else
            {
                gameText.text = ((int)(countdown - (Time.time - triggeredTime))).ToString();
                //gameText.text = "ready";
            }
        }
        else if (GameManager.isGameStarted()&& !GameManager.isGameEnded())
        {
            gameText.text = "Time: " + ((int)(Time.time - triggeredTime - countdown)).ToString();
        }
    }

    public void incrPoint()
    {
        Debug.Log("incr Point");
        point += 1;
        gameText.text = "Point: "+(point);
    }

    public int getPoint()
    {
        return point;
    }

    public static void triggerStartGame()
    {
        triggered = true;
        triggeredTime = Time.time;
        Debug.Log("Entered triggerStartGame");
    }
}
