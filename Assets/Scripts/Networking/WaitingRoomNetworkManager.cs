using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WaitingRoomNetworkManager : MonoBehaviour
{
    [SerializeField]GameObject playerPrefab = default;
    [SerializeField]Transform spawnPoint = default;
    [SerializeField] GameObject[] masterOnlyObjects = default;
 
    private void Start()
    {
        if(PhotonNetwork.IsConnected)
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);

        if(!PhotonNetwork.IsMasterClient)
         DisableMasterOnlyObjects();

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = true;
            PhotonNetwork.CurrentRoom.IsVisible = true;
        }
    }


    public void StartGame()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;

        PhotonNetwork.LoadLevel(2);
    }

    private void DisableMasterOnlyObjects()
    {
        for(int i =0; i< masterOnlyObjects.Length; i++)
        {
            masterOnlyObjects[i].SetActive(false);
        }
    }
}
