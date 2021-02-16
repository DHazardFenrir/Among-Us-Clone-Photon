
using UnityEngine;
using Photon.Pun;

public class Killeable : MonoBehaviourPunCallbacks
{  [SerializeField]GameObject deathbodyPrefab;
   [SerializeField]Sprite m_deadSprite;
   [SerializeField] SpriteRenderer mySprite;
    bool isKilled = false;

    void Awake()
    {
         mySprite = GetComponent<SpriteRenderer>();
    }
    
     [PunRPC]
    public void Kill()
    {
        //Destroy(this.gameObject);
        isKilled = true;
        Instantiate(deathbodyPrefab, transform.position, transform.rotation);
         mySprite.sprite = m_deadSprite;

           
        
    }

    void AutoKill()
    {
         if(Input.GetKeyDown(KeyCode.Z))
         {
              Debug.Log("aaaaaaaaaa");
              mySprite.sprite = m_deadSprite;
         }
    }

    void Update(){
         AutoKill();
    }
}

