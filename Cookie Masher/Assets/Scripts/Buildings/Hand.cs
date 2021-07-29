using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : Building
{
    public override string Name => "Extra Hand";
    public override float Cost => 15;
    public override float CPS => 0.1f;
}
