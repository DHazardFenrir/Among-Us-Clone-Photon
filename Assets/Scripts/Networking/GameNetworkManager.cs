using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameNetworkManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab = default;
    [SerializeField] Transform spawnPoint = default;

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);

     

       
    }
}
