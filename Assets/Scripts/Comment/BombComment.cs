using UnityEngine;

public class BombComment : Comment
{
    public Vector2 random = new(0.3f, 1.0f);

    void Start()
    {
        float randV = Random.Range(random.x, random.y);
        transform.localScale = new Vector3(randV, randV, randV);
    }

    public override void HasClicked()
    {
        base.HasClicked();
        ////Debug.Log("NormalComment HasClicked");
        isClicked = true;

        GameManager.instance.AddScore(0);
        GameManager.instance.AddBannedV(80.0f);
        DestroyComment();
    }

    public override void HasMissed()
    {
        //GameManager.instance.AddScore(-10);
        //Debug.Log("NormalComment HasMissed");
        Destroy(gameObject);
    }

    public override void HasBanned()
    {

    }
}
