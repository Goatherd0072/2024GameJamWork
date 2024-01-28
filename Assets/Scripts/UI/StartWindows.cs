using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWindows : MonoBehaviour
{
    public Button btn_left;
    public Button btn_right;

    void Awake()
    {
        btn_left= transform.Find("btn_left").GetComponent<Button>();
        btn_right = transform.Find("btn_right").GetComponent<Button>();
        WIndowsLinker.instance.OpenStartWindows += Show;

        btn_left.onClick.AddListener(() =>
        {
            Show(false);
        });

        btn_right.onClick.AddListener(() =>
        {
            WIndowsLinker.instance.ExitGame?.Invoke();
        });

    }
    private void Start()
    {
        Show(true);
    }

    void Show(bool isShow)
    {
        transform.gameObject.SetActive(isShow);
        WIndowsLinker.instance.PuaseGame?.Invoke(isShow);
    }
}
