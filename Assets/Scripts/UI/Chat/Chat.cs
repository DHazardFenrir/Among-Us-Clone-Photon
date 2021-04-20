using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Chat : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject messagePrefab = default;
    [SerializeField] Transform messageParent = default;

    public event Action onChatStarted;


    public void StartChat()
    {
        CleanChat();
        onChatStarted?.Invoke();

    }

    public void CreateMessage(Color playerColor, string nickname, string messageText)
    {
        GameObject messageObject = Instantiate(messagePrefab, messageParent);
        MessageUI messageUI = messageObject.GetComponent<MessageUI>();
        messageUI.SetMessage(playerColor, nickname, messageText);
    }

    public void CleanChat()
    {
        for(int i=0; i< messageParent.childCount; i++)
        {
            Destroy(messageParent.GetChild(i).gameObject);
        }
    }
}
