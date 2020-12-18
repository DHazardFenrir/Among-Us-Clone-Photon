using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmongXP.Networking;
namespace AmongXP.UI
{
    public class LobbyView : MonoBehaviour
    {
        [SerializeField] LaunchManager launchManager = default;
        private Canvas canvas;
        void Awake()
        {
            canvas = GetComponent<Canvas>();
            canvas.enabled = false;
        }

        private void OnEnable()
        {
            launchManager.onConnectServerSucced+= ShowLobby;
        }

        private void OnDisable()
        {
            launchManager.onConnectServerSucced -= ShowLobby;
        }
        private void ShowLobby()
        {
            canvas.enabled = true;
        }
    }
}


