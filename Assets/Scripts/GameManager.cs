using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public float oneDayTime = 60f;
    public float currentTime = 0f;
    public AnimationCurve spawnCurve;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime >= oneDayTime)
        {
            Debug.Log(("Day Gone"));
        }
    }
}
