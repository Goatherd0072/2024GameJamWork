using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextWindows : MonoBehaviour
{
    TMP_Text tmp_calculate;
    Button btn_left;
    TMP_Text tmp_left;
    Button btn_right;

    void Awake()
    {
        tmp_calculate = transform.Find("Img_bg/Text_title").GetComponent<TMP_Text>();
        btn_left = transform.Find("btn_left").GetComponent<Button>();
        tmp_left = btn_left.transform.Find("Text_btn").GetComponent<TMP_Text>();
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
        Calculate();
    }

    void Calculate()
    {
        string str = GameManager.instance.Calculate();
        if (GameManager.instance.CheckIsBan())
        {
            tmp_calculate.text = "��������ܾ���,\nֱ�����ѱ�����ˣ�";
            tmp_left.text = "����";
            btn_left.onClick.AddListener(() =>
            {
                string currentSceneName = SceneManager.GetActiveScene().name;

                // ���¼��ص�ǰ����
                SceneManager.LoadScene(currentSceneName);
            });
        }

        if (GameManager.instance.CheckMoney())
        {
            tmp_calculate.text = "ֱ�����������㣬���Ѿ��Ʋ���";
            tmp_left.text = "����";
            btn_left.onClick.AddListener(() =>
            {
                string currentSceneName = SceneManager.GetActiveScene().name;

                // ���¼��ص�ǰ����
                SceneManager.LoadScene(currentSceneName);
            });
        }

        tmp_calculate.text = str;
        tmp_left.text = "����";
        btn_left.onClick.AddListener(() =>
        {

        });

    }
}
