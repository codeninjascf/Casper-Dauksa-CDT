using UnityEngine;

public class Player : MonoBehaviour
{
    public static void Turn(GameObject rb, float movement)
    {
        SpriteRenderer spriteRenderer = rb.GetComponent<SpriteRenderer>();

        spriteRenderer.flipX = movement switch
        {
            > 0 => true,
            < 0 => false,
            _ => spriteRenderer.flipX
        };
    }
}
