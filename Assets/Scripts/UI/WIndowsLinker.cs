using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIndowsLinker : Singleton<WIndowsLinker>
{
    public Action<bool> OpenEixtWindows;
    public Action<bool> OpenNextWindows;
    public Action<bool> OpenStartWindows;
    public Action<bool> PuaseGame;
    public Action ExitGame;
}
