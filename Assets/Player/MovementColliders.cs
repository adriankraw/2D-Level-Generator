using UnityEngine;

public class MovementColliders
{
    private RaycastHit2D hit;
    public bool CheckSides(Vector3 move, Transform transform, LayerMask layer)
    {
        hit = Physics2D.BoxCast(new Vector3 ( transform.position.x-0.1F, transform.position.y, transform.position.z), new Vector2(0.4F, 0.4F), 0, transform.TransformDirection(Vector3.left), 0.1F, layer);
        if (hit)
        {
            if (move.x < 0 && hit.distance < 0.1F) return true;

            if (Vector3.Distance(hit.point, transform.position) < 0.3F)
            {
                transform.Translate(new Vector3(0.1F, 0, 0));
            }
        }
        hit = Physics2D.BoxCast(new Vector3(transform.position.x+0.1F, transform.position.y, transform.position.z), new Vector2(0.4F,0.4F), 0, transform.TransformDirection(Vector3.right), 0.1F, layer);
        if (hit)
        {
            if (move.x > 0 && hit.distance < 0.1F) return true;

            if (Vector3.Distance(hit.point, transform.position) < 0.3F)
            {
                transform.Translate(new Vector3(-0.1F, 0, 0));
            }
        }
        return false;
    }
    public bool GroundCheck(Transform transform, LayerMask layer)
    {
        hit = Physics2D.BoxCast(new Vector3(transform.position.x, transform.position.y-0.1F, transform.position.z), new Vector2(0.4F, 0.4F), 0, transform.TransformDirection(Vector3.down), 0.1F, layer);
        if (hit)
        {
            if (Vector3.Distance(hit.point, transform.position) < 0.3F)
            {
                transform.Translate(new Vector3(0, 0.1F, 0));
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool HeadCheck(Transform transform, LayerMask layer)
    {
        hit = Physics2D.BoxCast(new Vector3(transform.position.x, transform.position.y+0.1F, transform.position.z), new Vector2(0.4F, 0.4F), 0, transform.TransformDirection(Vector3.up), 0.1F, layer);
        if (hit && hit.distance < 0.1F)
        {
            if (Vector3.Distance(hit.point, transform.position) < 0.2F)
            {
                transform.Translate(new Vector3(0, -0.1F, 0));
            }
            return true;
        }
        else
        {
            return false;
        }
    }

}