using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KillButton : MonoBehaviour
{
    [SerializeField] GameNetworkManager gameNetworkManager = default;
    private Button button;
    private Killer killer;
    private KillTrigger killTrigger;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Execute);
        
    }

    private void OnEnable()
    {
        gameNetworkManager.onPlayerSpawned += SetPlayer;
    }
    private void OnDisable()
    {
        gameNetworkManager.onPlayerSpawned -= SetPlayer;

        if (killTrigger != null)
            killTrigger.onCanDoKill -= ShowButton;


    }
    private void ShowButton(bool value)
    {
        button.interactable = value;
    }

    public void SetPlayer(GameObject game)
    {
        killer = gameObject.GetComponent<Killer>();
        killTrigger = killer.GetComponentInChildren<KillTrigger>();

        killTrigger.onCanDoKill += ShowButton;
    }

    private void Execute()
    {
        killer.TryToKill();
    }
   
}
