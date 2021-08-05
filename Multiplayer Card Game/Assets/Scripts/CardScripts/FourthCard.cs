using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FourthCard : CardAbilities
{
    public override void OnCompile()
    {
        PlayerManager.CmdGMChangeValue(4);
    }
}
