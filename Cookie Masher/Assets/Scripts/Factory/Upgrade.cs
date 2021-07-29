using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;
using UnityEngine.UI;

public abstract class Upgrade
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract string ImprovementToMake { get; }
    public abstract float Cost { get; }
    public abstract void Process();
}
