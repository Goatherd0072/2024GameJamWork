using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextWindows : MonoBehaviour
{
    TMP_Text tmp_calculate;
    Button btn_left;
    Button btn_right;

    void Awake() 
    {
        tmp_calculate = transform.Find("Img_bg/Text_title").GetComponent<TMP_Text>();
        btn_left = transform.Find("btn_left").GetComponent<Button>();
        btn_right = transform.Find("btn_right").GetComponent<Button>();

        WIndowsLinker.instance.OpenNextWindows += Show;
        transform.gameObject.SetActive(false);

        btn_right.onClick.AddListener(() =>
        {
            WIndowsLinker.instance.ExitGame?.Invoke();
        });
    }

    void Show(bool isShow)
    {
        transform.gameObject.SetActive(isShow);
        WIndowsLinker.instance.PuaseGame?.Invoke(isShow);
    }
}
