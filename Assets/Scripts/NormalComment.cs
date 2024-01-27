using DG.Tweening;
using UnityEngine;

public class NormalComment : Comment
{
    public override void HasBanned()
    {
        Debug.Log("NormalComment HasBanned");
    }

    public override void HasClicked()
    {
        Debug.Log("NormalComment HasClicked");
        isClicked = true;
        if (DOTween.IsTweening(transform))
            DOTween.Kill(transform);
        Destroy(gameObject);
    }

    public override void HasMissed()
    {
        Debug.Log("NormalComment HasMissed");
        Destroy(gameObject);
    }
}