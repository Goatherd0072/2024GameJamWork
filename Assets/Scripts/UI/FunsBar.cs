using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FunsVar : Bar
{
    public TMP_Text tmp_FunsNum;
    public Color col_default = new Color(0.2830189f, 0.2830189f, 0.2830189f);
    public Color col_add = new Color(0.04705884f, 0.8862745f, 0.1478757f);
    public Color col_sub = new Color(0.8867924f, 0.04601282f, 0.04601282f);
    public int lastNum;

    public override void Init()
    {
        tmp_FunsNum = transform.Find("Text_PersonNum").GetComponent<TMP_Text>();
        string numberString = tmp_FunsNum.text.Replace(",", "");
        lastNum = int.Parse(numberString);
        UpdateText(GameManager.instance.gameData.score);
        tmp_FunsNum.color = col_default;
        base.Init();
    }

    public override void OnNotifyGameDate(GameData data)
    {
        UpdateText(data.score);
    }

    public override void OnNotifyCurrentTime(float time)
    {

    }

    // 调用这个方法并传入一个整数，tmpText将会更新为传入的数字，并保持逗号格式
    public void UpdateText(int number)
    {
        if (lastNum == number)
        {
            return;
        }
        bool isAdd = number >= lastNum;
        lastNum = number;
        SetTextColor(isAdd);

        string formattedNumber = FormatNumberWithCommas(number);
        tmp_FunsNum.text = formattedNumber;
        tmp_FunsNum.DOText(formattedNumber, 0.3f, true, ScrambleMode.Numerals, null).OnComplete(
            () =>
            {
                tmp_FunsNum.color = col_default;
            });

    }

    // 格式化数字为每三位一个逗号的字符串
    private string FormatNumberWithCommas(int number)
    {
        return string.Format("{0:N0}", number);
    }

    void SetTextColor(bool isAdd)
    {
        tmp_FunsNum.color = isAdd ? col_add : col_sub;
    }
}
