using UnityEngine;

public class MovementColliders
{
    private RaycastHit2D hit;
    public bool CheckSides(Vector3 move, Transform transform, LayerMask layer)
    {
        hit = Physics2D.BoxCast(transform.position, new Vector2(0.001F, 0.4F), 0, transform.TransformDirection(Vector3.left), 0.5F, layer);
        if (hit)
        {
            if (move.x < 0) return true;
        }
        hit = Physics2D.BoxCast(transform.position, new Vector2(0.001F, 0.4F), 0, transform.TransformDirection(Vector3.right), 0.5F, layer);
        if (hit)
        {
            if (move.x > 0) return true;
        }
        return false;
    }

    public bool GroundCheck(Transform transform, LayerMask layer)
    {
        hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.8F, 0, transform.TransformDirection(Vector3.down), 0.1F, layer);
        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool HeadCheck(Transform transform, LayerMask layer)
    {
        hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.8F, 0, transform.TransformDirection(Vector3.up), 0.1F, layer);
        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}