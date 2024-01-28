using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : Bar
{
    public Slider sliderTime;
    public Slider sliderBanValue;

    public override void Init()
    {
        sliderTime = transform.Find("DayTime/Progress Bar").GetComponent<Slider>();
        sliderBanValue = transform.Find("LiveLimit/Progress Bar").GetComponent<Slider>();

        sliderTime.minValue = 0;
        sliderTime.maxValue = GameManager.instance.oneDayTime;

        sliderBanValue.minValue = 0;
        sliderBanValue.maxValue = GameManager.instance.gameData.MaxBannedValue;
        sliderBanValue.value = GameManager.instance.gameData.BannedValue;

        base.Init();
    }

    public override void OnNotifyCurrentTime(float time)
    {
        //Debug.Log(time);
        sliderTime.value = time;
    }

    public override void OnNotifyGameDate(GameData data)
    {
        sliderBanValue.value = data.BannedValue;
    }
}
