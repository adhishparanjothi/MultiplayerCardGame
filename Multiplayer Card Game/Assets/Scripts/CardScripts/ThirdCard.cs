using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ThirdCard : CardAbilities
{
    public override void OnCompile()
    {
        PlayerManager.CmdGMChangeValue(3);
    }
}
