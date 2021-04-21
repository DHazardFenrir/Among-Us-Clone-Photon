using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class VoteScreen : MonoBehaviour
{
    [SerializeField] GameObject playerRow = default;
    private void CreatePlayerRows()
    {
        Player[] players = PhotonNetwork.PlayerList;

        for (int i = 0; i < players.Length; i++)
        {
            CreateRow(players[i]);
        }
    }

    private void CreateRow(Player player)
    {
        Hashtable hash = player.CustomProperties;

    }
}
