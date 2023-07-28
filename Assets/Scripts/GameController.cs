using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : ButtonsController
{
    private void Start()
    {
        InitializeButtons();
    }

    private void Update()
    {
        if (activeButtonCount >= 3) return;
        var rnd = Random.Range(0, buttonList.Count);
        EnableButton(rnd);
    }
}
