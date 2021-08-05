using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SecondCard : CardAbilities
{
    public override void OnCompile()
    {
        PlayerManager.CmdGMChangeValue(2);
    }
}
