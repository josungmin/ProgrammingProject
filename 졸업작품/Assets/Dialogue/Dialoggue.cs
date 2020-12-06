using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Dialoggue", menuName = "Dialoggue/DialoggueInfo")]
public class Dialoggue : ScriptableObject
{
    [TextArea (1,2)]
    public string[] sentences;
}
