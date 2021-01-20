using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;

namespace AmongXP.UI
{
    public class StartView : MonoBehaviour
    {
       
        [SerializeField] Button connectionButton = default;
       
        public void SetNickName(string nickname)
        {
            
            PhotonNetwork.NickName = nickname;
            bool isNicknameValid = !string.IsNullOrEmpty(nickname);

            connectionButton.interactable = isNicknameValid;
        }

    }
}

