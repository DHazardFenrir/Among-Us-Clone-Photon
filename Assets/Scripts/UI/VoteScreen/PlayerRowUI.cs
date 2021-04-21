using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
public class PlayerRowUI : MonoBehaviour
{
    [SerializeField] Image playerIconImage = default;
    [SerializeField] TMP_Text nicknameLabel = default;
    [SerializeField] Button voteButton;


    private Player player;

    private void Awake()
    {
        voteButton.onClick.AddListener(Vote);
    }

    public void SetData(Player player, Color playerColor, string nickname)
    {
        Material material = new Material(playerIconImage.material);
        material.SetColor("_MainColor", playerColor);
        playerIconImage.material = material;

        nicknameLabel.text = nickname;
        this.player = player;
        

    }

    private void Vote()
    {
        FindObjectOfType<GameNetworkManager>().MyPlayer.GetComponent<Voter>().SetVote(player);
    }
}
