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
    [SerializeField] private float CountDown = 3;
    private PhotonView pw;
    private int playerCount;
    private bool startGame;

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
            pw.RPC("StartGame", RpcTarget.All);
          
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

    [PunRPC]
    public void StartGame()
    {
        startGame = true;
        waitText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (startGame)
        {
            PhotonNetwork.LoadLevel(2);
            startGame = false;
        }
    }

    public void LeftRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(0);
    }

    
}