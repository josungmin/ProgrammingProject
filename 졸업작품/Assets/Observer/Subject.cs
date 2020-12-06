using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject
{
    private List<Observer> observerList = new List<Observer>();

    public void Attach(Observer o)
    {
        observerList.Add(o);
    }

    public void Notify()
    {
        foreach (Observer o in observerList)
        {
            o.Update();
        }
    }
}
