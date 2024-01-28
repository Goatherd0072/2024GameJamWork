using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBar : Bar
{
    public Button btnClose;

    public override void Init()
    {
        btnClose = transform.Find("Button").GetComponent<Button>();
        btnClose.onClick.AddListener(() =>
        {
            WIndowsLinker.instance.OpenEixtWindows?.Invoke(true);
        });

        base.Init();
    }

    public override void OnNotifyCurrentTime(float time)
    {

    }

    public override void OnNotifyGameDate(GameData data)
    {

    }
}
