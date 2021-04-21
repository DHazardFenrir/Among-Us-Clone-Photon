using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageUI : MonoBehaviour
{
    [SerializeField] Image playerIconImage = default;
    [SerializeField] TMP_Text nicknameLabel = default;
    [SerializeField] TMP_Text messageLabel = default;

  

    public void SetMessage(Color playerColor, string nickname, string message)
    {
        Material material = new Material(playerIconImage.material);
        material.SetColor("_MainColor", playerColor);

        playerIconImage.material = material;

        nicknameLabel.text = nickname;
        messageLabel.text = message;
    }


}
