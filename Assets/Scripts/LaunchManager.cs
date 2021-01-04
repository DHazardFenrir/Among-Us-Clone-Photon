using Photon.Pun;
using UnityEngine;
using System;
using Photon.Realtime;
using Random = UnityEngine.Random;

namespace AmongXP.Networking
{
    public class LaunchManager : MonoBehaviourPunCallbacks
    {
        public event Action onConnectServerStarted;
        public event Action onConnectServerSucced;
        public event Action onConnectedServerFailed;


        public event Action onJoinRoomStarted;
        public event Action onJoinRoomSucced;
        public event Action onJoinRoomFailed;
       

        public override void OnConnected()
        {
            Debug.Log("Connected to the Internet");
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log(PhotonNetwork.NickName + "Connected to Photon Servers");
            onConnectServerSucced?.Invoke();
        }

        public void ConnectToPhotonServer()
        {
            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.ConnectUsingSettings();
                onConnectServerStarted?.Invoke();
            }
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            onConnectedServerFailed?.Invoke();
        }

        public  void JoinRandomRoom()
        {
            onJoinRoomStarted?.Invoke();
            Debug.Log("Entrando a random room...");
            PhotonNetwork.JoinRandomRoom();
        }
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            onJoinRoomFailed?.Invoke();
            Debug.Log(message);
            CreateAndJoinRoom();
        }

        private void CreateAndJoinRoom()
        {
            string randomRoomName = "Room" + Random.Range(0, 10000);
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsOpen = true;
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = 10;

            PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
        }

        public override void OnJoinedRoom()
        {
            onJoinRoomSucced?.Invoke();
            Debug.Log(PhotonNetwork.NickName + "joined to" + PhotonNetwork.CurrentRoom.Name);
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.Log(newPlayer.NickName + "joined to" + PhotonNetwork.CurrentRoom.Name);
            Debug.Log("There are " + PhotonNetwork.CurrentRoom.PlayerCount + "connected players" + "("+PhotonNetwork.CurrentRoom.PlayerCount+ "/" +PhotonNetwork.CurrentRoom.MaxPlayers+")");
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Debug.Log(otherPlayer.NickName + "left the room" + PhotonNetwork.CurrentRoom.Name);
            Debug.Log("There are " + PhotonNetwork.CurrentRoom.PlayerCount + "connected players" + "(" + PhotonNetwork.CurrentRoom.PlayerCount + "/" + PhotonNetwork.CurrentRoom.MaxPlayers + ")");
        }

    }
}


