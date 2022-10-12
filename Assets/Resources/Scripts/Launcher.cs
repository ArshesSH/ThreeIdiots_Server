using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    /*--- Public Fields ---*/
    public GameObject StartButton;
    public GameObject ShutdownButton;

    /*--- Protected Fields ---*/


    /*--- Private Fields ---*/
    string gameVersion = "1.0";
    bool isConnectedToServer = false;


    /*--- MonoBehaviour Callbacks ---*/
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Start()
    {
        TurnOffAllUI();
    }

    /*--- Monobehaviour Pun Callback ---*/
    public override void OnConnectedToMaster()
    {
        Debug.Log( "Launcher: OnConnectedToMaster 호출, 서버 연결 완료" );
        isConnectedToServer = true;

        SetStartUI();
    }
    public override void OnCreatedRoom()
    {
        Debug.Log( $"OnCreatedRoom Called, Room Name: {PhotonNetwork.CurrentRoom.Name}" );
    }
    public override void OnCreateRoomFailed( short returnCode, string message )
    {
        base.OnCreateRoomFailed( returnCode, message );
        Debug.Log( "OnCreateRoomFailed Called " + message );
    }
    public override void OnJoinedRoom()
    {
        Debug.Log( "OnJoindRoom Called" );
    }
    public override void OnJoinRoomFailed( short returnCode, string message )
    {
        base.OnJoinRoomFailed( returnCode, message );
        Debug.Log( "OnJoinRoomFailed Called " + message );
    }

    /*--- Public Methods ---*/
    public void StartServerRoom()
    {
        PhotonNetwork.CreateRoom( "ServerRoom" );
        SetShutdownUI();
    }
    public void ShutdownServerRoom()
    {
        PhotonNetwork.DestroyAll();
        PhotonNetwork.LeaveRoom();
        SetStartUI();
    }

    /*--- Protected Methods ---*/


    /*--- Private Methods ---*/

    void SetStartUI()
    {
        StartButton.SetActive( true );
        ShutdownButton.SetActive( false );
    }
    void SetShutdownUI()
    {
        StartButton.SetActive( false );
        ShutdownButton.SetActive( true );
    }
    void TurnOffAllUI()
    {
        StartButton.SetActive( false );
        ShutdownButton.SetActive( false );
    }
}