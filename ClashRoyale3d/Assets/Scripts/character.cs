using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;

public class character : MonoBehaviour
{
    NavMeshAgent na;

    private void Start()
    {
        na = GetComponent<NavMeshAgent>();

        if (PhotonNetwork.IsMasterClient == false)
        {
            Vector3 temp = transform.position;
            GetComponent<PhotonView>().transform.position = -temp;
        }
    }
    private void Update()
    {
        //transform.position = new Vector3((int)transform.position.x , transform.position.y, (int)transform.position.z);
        

    }

    [PunRPC]
    void run()
    {
        na.destination = new Vector3(-3, 0.13f, 0.2f);
    }


}
