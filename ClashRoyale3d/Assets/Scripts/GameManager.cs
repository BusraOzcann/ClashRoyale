using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        

    }

    private void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            text.text = PhotonNetwork.CurrentRoom.Name.ToString() + " odası doldu!!";
        }
    }
}
