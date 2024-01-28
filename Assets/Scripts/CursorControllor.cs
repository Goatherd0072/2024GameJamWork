using DG.Tweening;
using UnityEngine;

public class CursorControllor : MonoSingleton<CursorControllor>
{
    const int MAX_CHECK_COLLIDER = 2;
    public GameObject cursor;
    public RectTransform gameArea;
    public Sprite spr_cursor;
    public Collider2D col2D;
    ContactFilter2D filter = new ContactFilter2D();
    Collider2D[] colA = new Collider2D[MAX_CHECK_COLLIDER];

    public bool isNeedCheck;

    // Start is called before the first frame update
    void Start()
    {
        cursor = transform.Find("Cursor").gameObject;
        col2D = cursor.GetComponent<Collider2D>();
        filter.layerMask = LayerMask.GetMask("Comment");
        filter.useLayerMask = true;
        WIndowsLinker.instance.PuaseGame += SetCheck;
    }

    void SetCheck(bool isCheck)
    {
        Cursor.visible = isCheck;
        isNeedCheck = !isCheck;
    }

    private void Update()
    {
        if (!isNeedCheck)
            return;

        if (!CheckIsAtArea())
        {
            Cursor.visible = true;
            return;
        }
        UpdateCursorPos(Input.mousePosition);

        int l = col2D.OverlapCollider(filter, colA);
        for (int i = 0; i < l; i++)
        {
            //Debug.Log(colA[i]);
            colA[i].GetComponent<Comment>().HasClicked();
        }

        CheckMouseDown(colA, l);
    }

    bool CheckIsAtArea()
    {
        if (gameArea == null)
            return false;

        return RectTransformUtility.RectangleContainsScreenPoint(gameArea, Input.mousePosition);
    }

    void CheckMouseDown(Collider2D[] col, int length)
    {
        if (Input.GetMouseButtonDown(0))
        {

            for (int i = 0; i < length; i++)
            {
                col[i].GetComponent<Comment>().HasClicked();
            }

        }

    }

    public void UpdateCursorPos(Vector2 pos)
    {
        Cursor.visible = false;
        pos = Camera.main.ScreenToWorldPoint(pos);
        cursor.transform.DOMove(pos, 0.3f, false);
    }

    public void SetGameArea(RectTransform area)
    {
        gameArea = area;
    }
}
