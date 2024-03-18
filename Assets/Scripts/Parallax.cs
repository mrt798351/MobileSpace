using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed = 5f;

    private float spriteHeight;
    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * parallaxSpeed * Time.deltaTime);

        if (transform.position.y < startPos.y - spriteHeight)
        {
            transform.position = startPos;
        }
    }
}
