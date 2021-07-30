using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Building
{
    public override string Name => "Bean Farm";
    public override float Cost => 1100;
    public override float CPS => 8f;
}
