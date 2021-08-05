using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FirstCard : CardAbilities
{
    public override void OnCompile()
    {
        PlayerManager.CmdGMChangeValue(1);
    }
}
