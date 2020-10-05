using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DragonState
{
    void OnEnter(Dragon dragon);
    void Update();
    void OnExit();
}

