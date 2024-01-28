using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public RectTransform gameArea;
    public List<Bar> bars = new List<Bar>();


    // Start is called before the first frame update
    void Start()
    {
        //base.Awake();
        gameArea = transform.Find("GameUI/GameView").GetComponent<RectTransform>();
        Vector3[] gameArCorners = new Vector3[4];
        gameArea.GetWorldCorners(gameArCorners);

        for (int i = 0; i < 4; i++)
        {
            gameArCorners[i] = Camera.main.ScreenToWorldPoint(gameArCorners[i]);
        }

        SpawnManager.instance.SetSpawnPos(gameArCorners);
        CursorControllor.instance.SetGameArea(gameArea);

        var showPanel = transform.Find("ShowPanel");

        for (int i = 0; i < showPanel.childCount; i++)
        {
            showPanel.GetChild(i).gameObject.SetActive(true);
        }


    }

    public void InitBar()
    {
        Transform trans = transform.Find("GameUI");
        AddBar<StatusBar>(trans);
        AddBar<FunsVar>(trans);
        AddBar<TopBar>(trans);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddBar<T>(Transform trans) where T : Bar
    {
        var bar = trans.GetComponentInChildren<T>();
        if (bar != null)
        {
            bars.Add(bar);
            bar.Init();
        }
        else
        {
            trans.Find(typeof(T).Name).AddComponent<T>().Init();
        }
    }
}
