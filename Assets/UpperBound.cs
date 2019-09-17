using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpperBound : MonoBehaviour
{
    public Text messageText;
    public Text recordText;
    public GameObject front;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy" && !GameManager.isGameEnded())
        {
            front.SetActive(true);
            recordText.text = messageText.text;
            messageText.text = "GAME OVER!";
            GameManager.gameEnded();

        }
        Destroy(col.gameObject);
    }
}
