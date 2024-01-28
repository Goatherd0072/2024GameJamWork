using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>, ISubject
{
    public float oneDayTime = 60f;
    public float currentTime = 0f;
    float tempTime = 0;
    public AnimationCurve spawnCurve;
    public GameData gameData;
    public List<IObserver> listObserve;

    void Start()
    {
        gameData = new();
        gameData.init();
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

    public void AddBannedV(float value)
    {
        gameData.BannedValue += value;
        if (gameData.BannedValue < 0)
        {
            gameData.BannedValue = 0;
        }
        if (gameData.BannedValue > gameData.MaxBannedValue)
        {
            gameData.BannedValue = gameData.MaxBannedValue;
        }
    }

    private void FixedUpdate()
    {
        subBannedV();
        gameData.currentTime += Time.fixedDeltaTime;
        currentTime = gameData.currentTime;
        CheckTime();
        NotifyObservers();

    }

    void subBannedV()
    {
        tempTime += Time.fixedDeltaTime;
        if (tempTime >= 0.5f)
        {
            tempTime = 0;
            AddBannedV(-1.0f);
        }

    }

    public bool CheckIsBan()
    {
        return gameData.BannedValue >= gameData.MaxBannedValue;
    }

    void CheckTime()
    {
        if (gameData.currentTime >= oneDayTime)
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
            observer.OnNotifyCurrentTime(gameData.currentTime);
        }
    }

    public bool CheckMoney()
    {
        return gameData.Money <= 0;
    }

    public string Calculate()
    {
        var date = gameData.Calculate();


        string str = $"感谢游玩\n"+
            $"当前天数{date.days}\n" +
            $"今日增加人气{date.addScore}\n" +
            $"扣除房租贷款{date.dex}后增加{date.addMoney}\n" +
            $"还剩{gameData.Money}元\n";

        return str;
    }
}
