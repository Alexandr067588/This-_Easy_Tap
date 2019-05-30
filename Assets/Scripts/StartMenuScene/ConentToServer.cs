using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConentToServer : MonoBehaviour
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings("1.0");
    }
    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("StartMenu");
    }

}
