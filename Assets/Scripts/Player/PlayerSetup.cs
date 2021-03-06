﻿
using UnityEngine;
using Photon.Pun;
using TMPro;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine.Events;
using Random = UnityEngine.Random;
public class PlayerSetup : MonoBehaviourPunCallbacks
{
     [SerializeField] PlayerCustomizations customizations;
    [SerializeField] PlayerRoles roles;
     [SerializeField] TMP_Text nickLabel = default;

     SpriteRenderer spriteRenderer;

    [SerializeField] UnityEvent onPlayerIsNotMine = default;
  

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        if(!photonView.IsMine){
            GetComponent<CharacterController>().enabled = false;
            
            GetComponent<PlayerInputHandler>().enabled = false;
            

            Killer killer = GetComponent<Killer>();
            if (killer != null) killer.enabled = false;

            onPlayerIsNotMine.Invoke();
        }else //its mine!
        {
           
            Hashtable savedHash = PhotonNetwork.LocalPlayer.CustomProperties;
            int index;
            if (savedHash.ContainsKey("ColorIndex"))
            {
                index = (int)savedHash["ColorIndex"];
            }
            else
            {
                index = GetUniqueRandomColorIndex();
               
                savedHash.Add("ColorIndex", index);
                PhotonNetwork.LocalPlayer.SetCustomProperties(savedHash);
            }
           
           photonView.RPC("SetColorIndex", RpcTarget.AllBuffered, index);
        }
        SetNickname();
    
    }

    [PunRPC]
   public void SetColorIndex(int index)
   {
       spriteRenderer.material.SetColor("_MainColor", customizations.GetColor(index));
     
   }

    

   public int GetUniqueRandomColorIndex()
    {
        List<int> availableColorIndexes = new List<int>();
        for (int i = 0; i < customizations.ColorCount; i++)
            availableColorIndexes.Add(i);

        Player[] players = PhotonNetwork.PlayerList;
        for(int i=0; i< players.Length; i++)
        {
            Hashtable hashtable = players[i].CustomProperties;
            if (!hashtable.ContainsKey("ColorIndex"))
                continue;
            int index = (int)hashtable["ColorIndex"];
            availableColorIndexes.Remove(index);
        }

        int randomIndex = Random.Range(0, availableColorIndexes.Count);
        return availableColorIndexes[randomIndex];

    }

   public void SetNickname()
   {
      nickLabel.text = photonView.Owner.NickName;
   }
}
