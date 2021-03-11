using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
public class Reporter : MonoBehaviourPun
{
    [SerializeField] ReportTrigger reportTrigger = default;




    public void TryToReport()
    {
        if (!reportTrigger.CanReport) return;
        GameObject bodyToReport = reportTrigger.GetNearerBody();

        if (bodyToReport != null)
        {
            Report();
        }





    }

    private void Report()
    {
        object content = null;
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(NetworkingEventsCodes.ReportBodyEventCode, content, raiseEventOptions, SendOptions.SendReliable);
    }
}
