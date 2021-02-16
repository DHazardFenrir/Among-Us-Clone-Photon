using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using Photon.Realtime;

public class GameNetworkManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab = default;
    [SerializeField] Transform spawnPoint = default;
   
    private void Start()
    {
        if (PhotonNetwork.IsConnected)
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);

        if(PhotonNetwork.IsMasterClient)
        StartCoroutine(StartGameDelay());
       
    }

    private IEnumerator StartGameDelay()
    {
        yield return new WaitForSeconds(2f);
        //ejecutar evento en photon
        object content = null;
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(NetworkingEventsCodes.StartGameEventCode, content, raiseEventOptions, SendOptions.SendReliable );
    }
}
