using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>, ISubject
{
    public float oneDayTime = 60f;
    public float currentTime = 0f;
    public AnimationCurve spawnCurve;
    public GameData gameData;
    public List<IObserver> listObserve;

    void Start()
    {
        gameData = new();
        listObserve = new();
        UIManager.instance.InitBar();
    }

    public void AddScore(int score)
    {
        gameData.score += score;
        if (gameData.score < 0)
        {
            gameData.score = 0;
        }
    }

    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        CheckTime();
        NotifyObservers();
    }

    void CheckTime()
    {
        if (currentTime >= oneDayTime)
        {
            //Debug.Log(("Day Gone"));
            WIndowsLinker.instance.OpenNextWindows?.Invoke(true);
        }
    }

    public void AddObserver(IObserver observer)
    {
        if (!listObserve.Contains(observer))
        {
            listObserve.Add(observer);
        }

    }

    public void RemoveObserver(IObserver observer)
    {
        if (listObserve.Contains(observer))
        {
            listObserve.Remove(observer);
        }
    }

    public void NotifyObservers()
    {
        foreach (var observer in listObserve)
        {
            observer.OnNotifyGameDate(gameData);
            observer.OnNotifyCurrentTime(currentTime);
        }
    }
}
