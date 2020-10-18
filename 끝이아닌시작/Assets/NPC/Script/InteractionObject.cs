using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionObject
{
    interactionType interType { get; }
    bool isEnable { get; set; }
    void InputKey();
    void Enter();
    void Update();
    void Exit();
}

public enum interactionType
{
    NPC,
    TreasureBox,
}
