using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public RectTransform gameArea;


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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
