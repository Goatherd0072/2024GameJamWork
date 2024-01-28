using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EixtWindows : MonoBehaviour
{
    Button btn_confirm;
    Button btn_cancel;

    private void Awake()
    {
        btn_confirm = transform.Find("btn_confirm").GetComponent<Button>();
        btn_cancel = transform.Find("btn_cancel").GetComponent<Button>();
        WIndowsLinker.instance.OpenEixtWindows += Show;
        transform.gameObject.SetActive(false);

        btn_confirm.onClick.AddListener(() =>
        {
            WIndowsLinker.instance.ExitGame?.Invoke();
        });

        btn_cancel.onClick.AddListener(() =>
        {
            WIndowsLinker.instance.OpenEixtWindows?.Invoke(false);
        });
    }

    void Show(bool isShow)
    {
        transform.gameObject.SetActive(isShow);
        WIndowsLinker.instance.PuaseGame?.Invoke(isShow);
    }
}
