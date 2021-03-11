using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text text;
    float time = 180;

    private void Start()
    {
        
    }

    private void Update()
    {
        time -= Time.deltaTime;
        text.text = (int)time / 60 + " : " + (int)time % 60;
        if (time <= 0)
        {
            Debug.Log("oyun bitti");
        }
    }

}
