using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilFactory : Building
{
    public override string Name => "Evil Factory";
    public override float Cost => 130000;
    public override float CPS => 260f;
}
