using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private float xFactor = 1.0f;

    //[SerializeField]
    //private float yFactor = 1.0f;

    [SerializeField]
    private bool tiedToBottom = true;


    private Camera attachedCamera;
    private SpriteRenderer background;
    private float maxY;


    // Use this for initialization
    void Start()
    {
        this.background = GetComponent<SpriteRenderer>();
        this.attachedCamera = background.transform.parent.parent.gameObject.GetComponent<Camera>();
        this.maxY = attachedCamera.transform.localPosition.y;

        //camera.aspect
    }

    void FixedUpdate()
    {
        Vector3 pos = background.transform.localPosition;
        pos.x = background.size.x / 4f - (attachedCamera.transform.position.x * xFactor) % (background.size.x / 2f);
        //pos.y = -camera.transform.position.y * yFactor;

        if (tiedToBottom)
            pos.y = Mathf.Min(pos.y, maxY);
        background.transform.localPosition = pos;

        //GetComponent<Renderer>().material.mainTextureOffset = new Vector2(pos.x, 0f);
    }
}
