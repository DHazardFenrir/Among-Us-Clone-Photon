using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChatButton : MonoBehaviour
{
    [SerializeField] GameObject chatScreen = default;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(OpenChat);
    }

    private void OpenChat()
    {
        chatScreen.SetActive(!chatScreen.activeSelf);
    }
}
