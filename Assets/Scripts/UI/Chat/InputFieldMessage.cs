using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFieldMessage : MonoBehaviour
{
    [SerializeField] GameNetworkManager gameNetworkManager = default;
    [SerializeField] Chat chat = default;
    private TMP_InputField inputTextMessage = default;
    private ChatUser chatUser;

    private void Awake()
    {
        inputTextMessage = GetComponent<TMP_InputField>();
    }

    private void OnEnable()
    {
        gameNetworkManager.onPlayerSpawned += SetPlayer;
        chat.onChatStarted += SetInputFieldStatus;
       
    }

    private void SetInputFieldStatus()
    {
        this.gameObject.SetActive(chatUser != null);
    }
   

    private void SetPlayer(GameObject playerObject)
    {
        chatUser = playerObject.GetComponent<ChatUser>();

        if(chatUser == null)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SendTextMessage(string message)
    {
        chatUser.SendRPC(message);
        inputTextMessage.text = "";
    }
}

