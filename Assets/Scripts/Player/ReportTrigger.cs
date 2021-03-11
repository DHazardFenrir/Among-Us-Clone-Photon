using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;
using System;
public class ReportTrigger : MonoBehaviour
{
    public bool CanReport { get; private set; }
    public event Action<bool> onCanReport;

    

    private List<GameObject> deadBodiesInContact;

    private void Awake()
    {
        deadBodiesInContact = new List<GameObject>();
       
    }



    public GameObject GetNearerBody()
    {
        float minDistance = 9999;
        GameObject nearerPlayer = null;

        for (int i = 0; i < deadBodiesInContact.Count; i++)
        {
            float sqrDistance = Vector3.SqrMagnitude(deadBodiesInContact[i].transform.position - transform.position);
            if (sqrDistance < minDistance)
            {
                minDistance = sqrDistance;
                nearerPlayer = deadBodiesInContact[i];
            }
        }

        return nearerPlayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag("DeadBody")) return;

        DeadBody deadBody = collision.GetComponent<DeadBody>();
        if (deadBody == null) return;
        deadBodiesInContact.Add(collision.gameObject);



        if (!CanReport)
        {
            CanReport = true;
            onCanReport?.Invoke(CanReport);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("DeadBody")) return;
        DeadBody deadBody = collision.GetComponent<DeadBody>();
        if (deadBody == null) return;


        deadBodiesInContact.Remove(collision.gameObject);

        if (deadBodiesInContact.Count == 0 && CanReport)
        {
            CanReport = false;
            onCanReport?.Invoke(CanReport);
        }
    }

}
