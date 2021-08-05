using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class UIManager : NetworkBehaviour
{
    public PlayerManager playerManager;
    public GameManager GameManager;
    public GameObject WinnerText;
    public GameObject LoserText;
    public GameObject PlayerValue;
    public GameObject OpponentValue;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void UpdatePlayerText()
    {
        PlayerValue.GetComponent<Text>().text = "Player Value: " + GameManager.PlayerValue;
        OpponentValue.GetComponent<Text>().text = "Opponent Value: " + GameManager.OpponentValue;
    }
    
}
