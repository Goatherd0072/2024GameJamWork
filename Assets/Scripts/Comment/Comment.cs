using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Comment : MonoBehaviour
{
    public bool isClicked;
    public Collider2D col2D;
    public Material matOutline;
    public Color clickColor = new(0f, 1.0f, 0.5193f, 1.0f);
    public Color hoverColor = new(1f, 0.0f, 0.5193f, 1.0f);

    private void Awake()
    {
        col2D = GetComponent<Collider2D>();
        if (transform.gameObject.layer != LayerMask.NameToLayer("Comment"))
        {
            transform.gameObject.layer = LayerMask.NameToLayer("Comment");
        }

        Material newMaterialInstance = Resources.Load<Material>("Materials/OutlineComment");
        matOutline = new Material(newMaterialInstance);
        GetComponent<SpriteRenderer>().material = matOutline;

    }

    private void Update()
    {

    }

    public abstract void HasBanned();
    public abstract void HasMissed();
    public virtual void HasClicked()
    {
        SetClickTween();
    }

    public virtual void HasHovered()
    {
        SetHoverTween();
    }

    public virtual void DestroyComment()
    {
        if (DOTween.IsTweening(transform))
            DOTween.Kill(transform);
        Destroy(gameObject);
    }

    protected void SetHoverTween()
    {
        matOutline.SetColor("_lineColor", hoverColor);
        matOutline.SetFloat("_lineWidth", 0f);
        matOutline.DOFloat(23.0f, "_lineWidth", 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            matOutline.DOFloat(0.0f, "_lineWidth", 0.3f);
            ResetMat(false);
        });
    }

    protected void SetClickTween()
    {
        matOutline.SetColor("_lineColor", clickColor);
        matOutline.SetFloat("_lineWidth", 0f);
        matOutline.DOFloat(23.0f, "_lineWidth", 0.3f).SetEase(Ease.OutBack);
    }

    protected void ResetMat(bool isTween)
    {
        if (isTween)
        {
            matOutline.DOFloat(0.0f, "_lineWidth", 0.3f).SetEase(Ease.OutBack);
            matOutline.DOColor(new Color(0f, 0f, 0f, 0f), "_lineColor", 0.3f).SetEase(Ease.OutBack);
        }
        else
        {
            matOutline.SetColor("_lineColor", new Color(0, 0, 0, 0));
            matOutline.SetFloat("_lineWidth", 0f);
        }
    }

}
