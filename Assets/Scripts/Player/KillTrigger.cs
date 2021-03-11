using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KillTrigger : MonoBehaviour
{
    public bool CanKill { get; private set; }
    public event Action<bool> onCanDoKill;

    private Collider2D parentCollider;

    private List<GameObject> playersInContact;

    private void Awake()
    {
        playersInContact = new List<GameObject>();
        parentCollider = transform.parent.GetComponent<Collider2D>();
    }

  

    public GameObject GetNearerPlayer()
    {
        float minDistance = 9999;
        GameObject nearerPlayer = null;

        for(int i=0; i< playersInContact.Count; i++)
        {
            float sqrDistance = Vector3.SqrMagnitude(playersInContact[i].transform.position - transform.position);
            if(sqrDistance < minDistance)
            {
                minDistance = sqrDistance;
                nearerPlayer = playersInContact[i];
            }
        }

        return nearerPlayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || collision.Equals(parentCollider)) return;

        PlayerInputHandler playerInputHandler = collision.gameObject.GetComponent<PlayerInputHandler>();
        if (playerInputHandler.IsGhost) return;
        playersInContact.Add(collision.gameObject);
       


        if (!CanKill)
        {
            CanKill = true;
            onCanDoKill?.Invoke(CanKill);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")||collision.Equals(parentCollider)) return;
        PlayerInputHandler playerInputHandler = collision.gameObject.GetComponent<PlayerInputHandler>();
        if (playerInputHandler.IsGhost) return;
        playersInContact.Remove(collision.gameObject);
        
        if(playersInContact.Count ==0 && CanKill)
        {
            CanKill = false;
            onCanDoKill?.Invoke(CanKill);
        }
    }
}
