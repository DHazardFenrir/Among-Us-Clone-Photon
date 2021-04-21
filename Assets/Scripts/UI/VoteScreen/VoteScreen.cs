using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class VoteScreen : MonoBehaviour
{
    [SerializeField] GameObject playerRow = default;
    [SerializeField] PlayerCustomizations playerCustomizations = default;
    [SerializeField] Transform rightColumn = default;
    [SerializeField] Transform leftColumn = default;

    private bool lastRowLeft;
    private Dictionary<Player, Player> submittedVotes;

    
   public void CreatePlayerRows()
    {
        submittedVotes = new Dictionary<Player, Player>(); 
        CleanTransform(leftColumn);
        CleanTransform(rightColumn);
        lastRowLeft = false;
        Player[] players = PhotonNetwork.PlayerList;

        for (int i = 0; i < players.Length; i++)
        {
            CreateRow(players[i]);
        }
    }

    private void CreateRow(Player player)
    {
        Hashtable hash = player.CustomProperties;
        int colorIndex = (int)hash["ColorIndex"];
        Transform parent = lastRowLeft ? leftColumn : rightColumn;
        lastRowLeft = !lastRowLeft;
        GameObject playerRowObject =   Instantiate(playerRow, parent);
        PlayerRowUI rowUI = playerRowObject.GetComponent<PlayerRowUI>();

        rowUI.SetData(player,playerCustomizations.GetColor(colorIndex), player.NickName);

    }

    private void CleanTransform(Transform transform)
    {
        for(int i =0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void SetVote(Player voter, Player voted)
    {
        if (!submittedVotes.ContainsKey(voter))
            submittedVotes.Add(voter, voted);
        else
            submittedVotes[voter] = voted;

        Debug.Log(voter.NickName + "voted for" + voted.NickName);
    }
}
