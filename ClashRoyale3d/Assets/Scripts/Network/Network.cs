using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class Network : MonoBehaviourPunCallbacks
{
    public static Network network;
 
    private void Awake()
    {
        //if (network != null && network != this)
        //{
        //    gameObject.SetActive(false);
        //}
        //else
        //{
        //    network = this;
        //    DontDestroyOnLoad(gameObject);
        //}
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
       
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("sunucuya bağlanıldı");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Rastgele bir ordaya ulaşılamadı o yüzden oda oluşturulacak...");
        CreateRoom();
    }

    public void CreateRoom()
    {
        Debug.Log("oda oluşuyor...");
        int randomNumber = Random.Range(0, 10000);
        RoomOptions opt = new RoomOptions { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        PhotonNetwork.CreateRoom("Room" + randomNumber, opt);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("oda oluşturulamadı. Tekrar deneniyor.");
        CreateRoom();
    }


    public override void OnJoinedRoom()
    {
        Debug.Log("created room : " + PhotonNetwork.CurrentRoom.Name);
        SceneManager.LoadScene(1);
    }

}
