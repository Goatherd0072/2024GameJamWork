using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    [Header("Spawn Area")]
    public float startX;
    public float endX;
    public float MaxY;
    public float MinY;
    public float offsetX = 3f;
    public float offsetY = 0.8f;
    public bool isSpawning = false;

    [Header("Spawn Prafabs")]
    const string prefabPath = "Prefabs/Comment/";
    public GameObject normalComment = null;
    public GameObject attakcComment = null;
    public GameObject bombComment = null;

    [Header("Spawn Config")]
    public int maxSpawnCount = 200;
    public List<int> categry = new();
    float[] categoryRate = new float[] { 0.4f, 0.4f, 0.2f };
    public float delayTime = 2f;
    public float spawnInterval = 1f;
    public Vector2 moveTimeRange = new Vector2(2.0f, 5.0f);
    public Queue<(float time, GameObject go)> tempQ = new();
    public float timeOffset = 4.0f;

    public SpawnManager() { }

    public SpawnManager(int max, float[] rate,Vector2 moveSpeed)
    {
        maxSpawnCount = max;
        categoryRate = rate;
        moveTimeRange = moveSpeed;
    }


    // Start is called before the first frame update
    void Start()
    {
        normalComment = Resources.Load<GameObject>(prefabPath + "NormalComment");
        attakcComment = Resources.Load<GameObject>(prefabPath + "AttackComment");
        bombComment = Resources.Load<GameObject>(prefabPath + "BombComment");

        categry = GenerateNumbers(maxSpawnCount, categoryRate);
        // delay 2s 
        //Invoke("StartSpawnComment", delayTime);

        //StartCoroutine(SpawComment());

    }

    void FixedUpdate()
    {
        //SpawComment();
        SetCommentTween(tempQ);

    }

    void SetCommentTween(Queue<(float time, GameObject go)> tq)
    {
        if (!isSpawning)
        { return; }

        if (tq.Count == 0 || tq == null)
        { return; }

        if (tq.Peek().time <= GameManager.instance.gameData.currentTime)
        {
            //Debug.Log("3");
            var temp = tq.Dequeue();
            temp.go.transform.DOMoveX(endX, Random.Range(moveTimeRange.x, moveTimeRange.y)).OnComplete(() =>
            {
                temp.go.GetComponent<Comment>().HasMissed();
            });
        }
        //Debug.Log(tq.Peek().time);
    }

    void initComment(Queue<(float time, GameObject go)> tq)
    {
        for (int i = 0; i < maxSpawnCount; i++)
        {
            float waitTime = GameManager.instance.spawnCurve.Evaluate((float)i / maxSpawnCount) * (GameManager.instance.oneDayTime - timeOffset);

            Vector3 tempV3 = new Vector3();
            tempV3.x = startX;
            tempV3.y = Random.Range(MinY, MaxY);
            //Debug.Log(tempV3);

            var go = categry[i] switch
            {
                0 => normalComment,
                1 => attakcComment,
                2 => bombComment,
                _ => null
            };

            GameObject obj = Instantiate(go, tempV3, normalComment.transform.rotation, transform);
            //obj.transform.position = tempV3;
            tq.Enqueue((waitTime, obj));
        }
        isSpawning = true;
    }

    List<int> GenerateNumbers(int count, float[] probabilities)
    {
        List<int> result = new List<int>();

        for (int i = 0; i < count; i++)
        {
            double randomNumber = Random.value;
            double cumulativeProbability = 0;

            for (int j = 0; j < probabilities.Length; j++)
            {
                cumulativeProbability += probabilities[j];

                if (randomNumber < cumulativeProbability)
                {
                    //Debug.Log(j);
                    result.Add(j);
                    break;
                }
            }
        }

        return result;
    }

    public void StartSpawnComment()
    {
        isSpawning = true;
    }

    public void SetSpawnPos(Vector3[] rect)
    {
        endX = rect[0].x - offsetX;
        startX = rect[2].x + offsetX;
        MaxY = rect[2].y - offsetY;
        MinY = rect[3].y + offsetY;
        initComment(tempQ);
        //Debug.Log(endX);

        //GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //obj.transform.position = new Vector3(endX, 0, 0);

        //GameObject obj1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //obj1.transform.position = new Vector3(startX, 0, 0);

        //GameObject obj2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //obj2.transform.position = new Vector3(0, MaxY, 0);

        //GameObject obj3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //obj3.transform.position = new Vector3(0, MinY, 0);

    }
}
