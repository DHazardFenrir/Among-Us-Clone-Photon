
using UnityEngine;
using Photon.Pun;
using TMPro;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using ExitGames.Client.Photon;

public class PlayerSetup : MonoBehaviourPunCallbacks, IOnEventCallback
{
     [SerializeField] PlayerCustomizations customizations = default;
     [SerializeField] PlayerRoles roles = default;
     [SerializeField] Pets petRandom = default;
     [SerializeField] TMP_Text nickLabel = default;
     [SerializeField] GameObject petContainer;
     [SerializeField] Transform petSpawn;

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


            //Set Pets
            int petIndex;
            if (savedHash.ContainsKey("PetIndex"))
            {
               petIndex = (int)savedHash["PetIndex"];
            }
            else
            {
                petIndex = GetUniqueRandomPetIndex();
                savedHash.Add("PetIndex", petIndex);
                PhotonNetwork.LocalPlayer.SetCustomProperties(savedHash);
            }
            photonView.RPC("SetPetIndex", RpcTarget.AllBuffered, petIndex);
        }
        SetNickname();
    
    }

    private void SetRandomRol()
    {
        Hashtable savedHash = PhotonNetwork.LocalPlayer.CustomProperties;
        bool isImpostor;
        if (savedHash.ContainsKey("IsImpostor"))
        {
           isImpostor = (bool)savedHash["IsImpostor"];
        }
        else
        {
            int random = Random.Range(0, 2);
            isImpostor = random == 0;

            savedHash.Add("IsImpostor", isImpostor);
            PhotonNetwork.LocalPlayer.SetCustomProperties(savedHash);
        }

        photonView.RPC("SetRol", RpcTarget.AllBuffered, isImpostor);


    
    }

    [PunRPC]
    public void SetRol(bool isImpostor)
    {
        string message = isImpostor ? "impostor" : "crewmate";
        Debug.Log(photonView.Owner + "es" + message);
    }

    [PunRPC]
   public void SetColorIndex(int index)
   {
       spriteRenderer.material.SetColor("_MainColor", customizations.GetColor(index));
     
   }
   [PunRPC]
    public void SetPetIndex(int petIndex)
    {
        Transform petParent = this.petContainer.transform;
        Instantiate(petRandom.GetPet(petIndex), petSpawn.position, petSpawn.rotation, petParent);
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

    public int GetUniqueRandomPetIndex()
    {
        List<int> availablePetIndexes = new List<int>();
        for (int i = 0; i < petRandom.PetsCount; i++)
            availablePetIndexes.Add(i);

        Player[] players = PhotonNetwork.PlayerList;
        for (int i = 0; i < players.Length; i++)
        {
            Hashtable hashtable = players[i].CustomProperties;
            if (!hashtable.ContainsKey("PetIndex"))
                continue;
            int index = (int)hashtable["PetIndex"];
            availablePetIndexes.Remove(index);
        }

        int randomIndex = Random.Range(0, availablePetIndexes.Count);
        return availablePetIndexes[randomIndex];
    }

   public void SetNickname()
   {
      nickLabel.text = photonView.Owner.NickName;
   }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        if(eventCode == NetworkingEventsCodes.StartGameEventCode)
        {
            object data = photonEvent.CustomData;
            SetRandomRol();
        }
    }
}
