using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bar : MonoBehaviour, IObserver
{
    public abstract void OnNotifyCurrentTime(float time);

    public abstract void OnNotifyGameDate(GameData data);

    public virtual void Init()
    {
        GameManager.instance.AddObserver(this);
    }

    public virtual void Destory()
    {
        GameManager.instance.RemoveObserver(this);
    }
}
