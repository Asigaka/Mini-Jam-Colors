using System.Collections;
using UnityEngine;

public class EnemyColors : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
}