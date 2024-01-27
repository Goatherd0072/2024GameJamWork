using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorControllor : MonoSingleton<CursorControllor>
{
    const int MAX_CHECK_COLLIDER = 4;
    public GameObject cursor;
    public RectTransform gameArea;
    public Sprite spr_cursor;
    public Collider2D col2D;
    ContactFilter2D filter = new ContactFilter2D();
    Collider2D[] colA = new Collider2D[MAX_CHECK_COLLIDER];

    // Start is called before the first frame update
    void Start()
    {
        cursor = transform.Find("Cursor").gameObject;
        col2D = cursor.GetComponent<Collider2D>();
        filter.layerMask = LayerMask.GetMask("Comment");
        filter.useLayerMask = true;
    }

    private void Update()
    {
        if (!CheckIsAtArea())
        {
            Cursor.visible = true;
            return;
        }
        UpdateCursorPos(Input.mousePosition);
        CheckMouseDown();
    }

    bool CheckIsAtArea()
    {
        if (gameArea == null)
            return false;

        return RectTransformUtility.RectangleContainsScreenPoint(gameArea, Input.mousePosition);
    }

    void CheckMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {

            int l = col2D.OverlapCollider(filter, colA);
            for (int i = 0; i < l; i++)
            {
                //Debug.Log(colA[i]);
                colA[i].GetComponent<Comment>().HasClicked();
            }

        }

    }

    public void UpdateCursorPos(Vector2 pos)
    {
        Cursor.visible = false;
        pos = Camera.main.ScreenToWorldPoint(pos);
        cursor.transform.DOMove(pos, 0.1f, false);
    }

    public void SetGameArea(RectTransform area)
    {
        gameArea = area;
    }
}
