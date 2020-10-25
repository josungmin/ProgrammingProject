using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Quest
{
    [SerializeField]
    private string _questId;
    public string questId
    {
        get
        {
            return questId;
        }
        set
        {
            questId = value;
        }
    }

    [SerializeField]
    private string _questName;
    public string questName
    {
        get
        {
            return _questName;
        }
        set
        {
            _questName = value;
        }
    }

    [SerializeField]
    private string _questContent;
    public string questContent
    {
        get
        {
            return _questContent;
        }
        set
        {
            _questContent = value;
        }
    }

    [SerializeField]
    private string _questReward;
    public string questReward
    {
        get
        {
            return _questReward;
        }
        set
        {
            _questReward = value;
        }
    }

    [SerializeField]
    private bool _questAccept;
    public bool questAccept
    {
        get
        {
            return _questAccept;
        }
        set
        {
            _questAccept = value;
        }
    }

    [SerializeField]
    private bool _questClear;
    public bool questClear
    {
        get
        {
            return _questClear;
        }
        set
        {
            _questClear = value;
        }
    }
}
