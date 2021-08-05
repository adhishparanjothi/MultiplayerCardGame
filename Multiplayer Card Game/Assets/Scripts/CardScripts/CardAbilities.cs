using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public abstract class CardAbilities : NetworkBehaviour
{
    public PlayerManager PlayerManager;
    // Start is called before the first frame update
    void Start()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();

    }

    public abstract void OnCompile();
}
