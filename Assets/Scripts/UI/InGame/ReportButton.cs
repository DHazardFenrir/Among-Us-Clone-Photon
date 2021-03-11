using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportButton : MonoBehaviour
{
    [SerializeField] GameNetworkManager gameNetworkManager = default;
    private Button button;
    private Reporter reporter;
    private ReportTrigger reportTrigger;

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

        if (reportTrigger != null)
            reportTrigger.onCanReport -= ShowButton;


    }
    private void ShowButton(bool value)
    {
        button.interactable = value;
    }

    public void SetPlayer(GameObject game)
    {
        reporter = game.GetComponent<Reporter>();
        reportTrigger = reporter.GetComponentInChildren<ReportTrigger>();

        reportTrigger.onCanReport += ShowButton;
    }

    private void Execute()
    {
        reporter.TryToReport();
    }
}
