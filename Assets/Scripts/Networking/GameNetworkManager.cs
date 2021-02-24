using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine.UI;
public class GameNetworkManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab = default;
    [SerializeField] Transform spawnPoint = default;
    [SerializeField] GameObject ghostPrefab;
    [SerializeField] Button ReportButton;
    public GameObject MyPlayer { get; private set; }
   
    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
           MyPlayer = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
            

        }


        if (PhotonNetwork.IsMasterClient)
        StartCoroutine(StartGameDelay());
       
    }

    public void SpawnGhost(Vector3 position)
    {
       MyPlayer= PhotonNetwork.Instantiate(ghostPrefab.name, position, transform.rotation);
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
