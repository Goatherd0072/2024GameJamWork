using DG.Tweening;
using UnityEngine;

public class NormalComment : Comment
{
    public Vector2 randomX = new(0.5f, 1.0f);
    public Vector2 randomY = new(0.8f, 1.5f);

    void Start()
    {
        transform.localScale = new Vector3(Random.Range(randomX.x, randomX.y), Random.Range(randomY.x, randomY.y), 1.0f);
    }

    public override void HasBanned()
    {
        Debug.Log("NormalComment HasBanned");
    }

    public override void HasClicked()
    {
        base.HasClicked();
        ////Debug.Log("NormalComment HasClicked");
        isClicked = true;

        GameManager.instance.AddScore(100);

        DestroyComment();
    }

    public override void HasHovered()
    {
        base.SetHoverTween();
    }

    public override void HasMissed()
    {
        if (Random.value < 0.4f)
        {
            GameManager.instance.AddScore(-(int)(10*Random.value));
        }
        //Debug.Log("NormalComment HasMissed");
        Destroy(gameObject);
    }
}