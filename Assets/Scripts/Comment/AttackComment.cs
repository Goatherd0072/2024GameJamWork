using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComment : Comment
{
    public Vector2 randomX = new(0.5f, 1.5f);
    public Vector2 randomY = new(0.8f, 1.5f);

    void Start()
    {
        transform.localScale = new Vector3(Random.Range(randomX.x, randomX.y), Random.Range(randomY.x, randomY.y), 1.0f);
    }
    public override void HasClicked()
    {
        base.HasClicked();
        ////Debug.Log("NormalComment HasClicked");
        isClicked = true;

        GameManager.instance.AddScore(200);
        GameManager.instance.AddBannedV(20.0f);
        DestroyComment();
    }


    public override void HasBanned()
    {
    }

    public override void HasMissed()
    {
        Destroy(gameObject);
    }
}
