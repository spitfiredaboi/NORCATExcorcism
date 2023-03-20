using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public SpriteRenderer SR;
    public Sprite open;
    public Sprite close;

    private Collider2D collider_;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        collider_ = GetComponent<Collider2D>();
    }

    public void Open()
    {
        collider_.enabled = false;
        SR.sprite = open;

    }
    public void Close()
    {
        collider_.enabled = true;
        SR.sprite = close;
    }
}
