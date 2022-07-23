using System.Collections;
using UnityEngine;

public class EnemyColors : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public SpriteRenderer SpriteRenderer { get => spriteRenderer; }

    public void SetRandomColor()
    {
        Color color;

        int colorIndex = Random.Range(0, 3);

        switch (colorIndex)
        {
            case 0: color = Color.red; break;
            case 1: color = Color.green; break;
            case 2: color = Color.blue; break;
            default: color = Color.black; break;
        }

        spriteRenderer.color = color;
    }
}