using DG.Tweening;
using UnityEngine;

public class NormalComment : Comment
{
    public Vector2 randomX = new(0.3f, 1.0f);
    public Vector2 randomY = new(0.3f, 1.0f);

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
        GameManager.instance.AddScore(-10);
        //Debug.Log("NormalComment HasMissed");
        Destroy(gameObject);
    }
}