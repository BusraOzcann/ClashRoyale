using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaitMenuNetwork : MonoBehaviourPunCallbacks
{
    [SerializeField] private int maxPlayers;
    [SerializeField] private Text playerCountText;
    [SerializeField] private Text waitText;
    private int playerCount;
    private PhotonView pw;

    private void Start()
    {
        pw = GetComponent<PhotonView>();
        PlayerCount();
    }

    private void PlayerCount()
    {
        playerCount = PhotonNetwork.PlayerList.Length;

        if (playerCount < maxPlayers)
        {
            waitText.gameObject.SetActive(true);
            playerCountText.text = "Oyuncu bekleniyor:" + playerCount + "/" + maxPlayers;
        }
        else if(playerCount == maxPlayers)
        {
            playerCountText.text = "Oyuncular hazır. Oyun başlıyor !";
            PhotonNetwork.LoadLevel(2);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PlayerCount();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PlayerCount();
    }

    public void LeftRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(0);
    }

    
}