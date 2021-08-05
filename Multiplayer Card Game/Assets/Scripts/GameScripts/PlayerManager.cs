using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameManager GameManager;
    public CardValues CardValues;
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject PlayerSlot1;
    public GameObject EnemySlot1;
    public List<GameObject> PlayerSockets = new List<GameObject>();
    public List<GameObject> EnemySockets = new List<GameObject>();
    public bool hasSpawned;

    List<GameObject> cards = new List<GameObject>();
    int value1 = 1;
    int value2 = 2;
    int value3 = 3;
    int value4 = 4;
    
    public override void OnStartClient()
    {
        base.OnStartClient();


        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        PlayerArea = GameObject.Find("PlayerArea");
        EnemyArea = GameObject.Find("EnemyArea");
        PlayerSlot1 = GameObject.Find("PlayerSlot1");
        EnemySlot1 = GameObject.Find("EnemySlot1");        
    }


    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();

       Card1.GetComponent<CardValues>().valueToSet = value1;
       Card2.GetComponent<CardValues>().valueToSet = value2;
       Card3.GetComponent<CardValues>().valueToSet = value3;
       Card4.GetComponent<CardValues>().valueToSet = value4;

        cards.Add(Card1);
        cards.Add(Card2);
        cards.Add(Card3);
        cards.Add(Card4);

        

        PlayerSockets.Add(PlayerSlot1);
        EnemySockets.Add(EnemySlot1);

        
    }
    [Command]
    public void CmdDealCards()
    {
        for (int i = 0; i < 1; i++)
        { 
            if(hasSpawned == false)
            {
                GameObject card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector2(0, 0), Quaternion.identity);
                NetworkServer.Spawn(card, connectionToClient);
                RpcShowCard(card, "Dealt");
            }
            
        }
    }

    public void PlayCard(GameObject card)
    {
        card.GetComponent<CardAbilities>().OnCompile();

        CmdPlayCard(card);
    }

    [Command]
    void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card, "Played");
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, string type)
    {
        if(type == "Dealt")
        {
            if (hasAuthority)
            {
                card.transform.SetParent(PlayerArea.transform, false);
                card.GetComponent<CardFlipper>().Flip();
                hasSpawned = true;
            }
            else
            {
                card.transform.SetParent(EnemyArea.transform, false);
                card.GetComponent<CardFlipper>().Flip();
                hasSpawned = true;
            }
        }
        else if(type == "Played")
        {
            
            if (hasAuthority)
            {
                card.transform.SetParent(PlayerSlot1.transform, false);
                card.GetComponent<CardFlipper>().Flip();
               
            }
            if (!hasAuthority)
            {
                card.transform.SetParent(EnemySlot1.transform, false);
                card.GetComponent<CardFlipper>().Flip();
                
            }

            
         
        }
    }
    [Command]
    public void CmdGMChangeValue(int value)
    {
        RpcGMChangeValue(value);
    }

    [ClientRpc]
    public void RpcGMChangeValue(int value)
    {
       GameManager.ChangeValue(value, hasAuthority);
    }
  
}
