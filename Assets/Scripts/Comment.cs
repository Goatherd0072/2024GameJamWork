using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Comment : MonoBehaviour
{
    public bool isClicked;
    public Collider2D col2D;

    private void Awake()
    {
        col2D = GetComponent<Collider2D>();
        if(transform.gameObject.layer != LayerMask.NameToLayer("Comment"))
        {
            transform.gameObject.layer = LayerMask.NameToLayer("Comment");
        }
    }

    public abstract void HasBanned();
    public abstract void HasMissed();
    public abstract void HasClicked();



}
