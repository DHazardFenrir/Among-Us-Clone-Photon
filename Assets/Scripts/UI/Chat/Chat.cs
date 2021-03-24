using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject messagePrefab = default;
    [SerializeField] Transform messageParent = default;


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
