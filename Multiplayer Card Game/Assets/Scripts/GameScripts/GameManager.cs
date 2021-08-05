using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public PlayerManager PlayerManager;
    public UIManager UIManager;
    public int PlayerValue = 0;
    public int OpponentValue = 0;

    private void Start()
    {
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        UIManager.UpdatePlayerText();
    }

    public void ChangeValue(int value, bool hasAuthority)
    {
        if (hasAuthority)
        {
            PlayerValue += value;
        }
        else
        {
            OpponentValue += value;
        }
        UIManager.UpdatePlayerText();

        if (hasAuthority && PlayerValue>0 && OpponentValue>0)
        {
            if (PlayerValue > OpponentValue)
            {
                UIManager.WinnerText.SetActive(true);

            }
            else
            {
                UIManager.LoserText.SetActive(true);
            }
        }
        if (!hasAuthority && PlayerValue > 0 && OpponentValue > 0)
        {
            if (PlayerValue > OpponentValue)
            {
                UIManager.WinnerText.SetActive(true);

            }
            else
            {
                UIManager.LoserText.SetActive(true);
            }
        }

    }
}
