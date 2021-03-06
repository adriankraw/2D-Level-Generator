using UnityEngine;

public class MovementColliders
{
    private RaycastHit2D hit;
    private RaycastHit2D[] hitArray = new RaycastHit2D[3];
    private ContactFilter2D contactFilter = new ContactFilter2D();

    /// <summary>
    /// Checks for Collision left & right; false if no obstacle found
    /// </summary>
    /// <param name="move"></param>
    /// <param name="transform"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public bool CheckSides(Vector3 move, Transform transform, LayerMask layer)
    {
        contactFilter.layerMask = layer;
        //hit = Physics2D.BoxCast(new Vector3 ( transform.position.x-0.1F, transform.position.y, transform.position.z), new Vector2(0.4F, 0.4F), 0, transform.TransformDirection(Vector3.left), 0.1F, layer);
        if (Physics2D.BoxCast(new Vector3(transform.position.x - 0.1F, transform.position.y, transform.position.z), new Vector2(0.4F, 0.4F), 0, transform.TransformDirection(Vector3.left), contactFilter, hitArray, 0.1F) > 0)
        {
            foreach (RaycastHit2D hit in hitArray)
            {
                if (hit && hit.collider.transform != transform)
                {
                    if (move.x < 0 && hit.distance < 0.1F) return true;

                    if (Vector3.Distance(hit.point, transform.position) < 0.3F)
                    {
                        transform.Translate(new Vector3(0.1F, 0, 0));
                    }
                }
            }
        }
        //hit = Physics2D.BoxCast(new Vector3(transform.position.x+0.1F, transform.position.y, transform.position.z), new Vector2(0.4F,0.4F), 0, transform.TransformDirection(Vector3.right), 0.1F, layer);
        if (Physics2D.BoxCast(new Vector3(transform.position.x + 0.1F, transform.position.y, transform.position.z), new Vector2(0.4F, 0.4F), 0, transform.TransformDirection(Vector3.right), contactFilter, hitArray, 0.1F) > 0)
        {
            foreach (RaycastHit2D hit in hitArray)
            {
                if (hit && hit.collider.transform != transform)
                {
                    if (move.x > 0 && hit.distance < 0.1F) return true;

                    if (Vector3.Distance(hit.point, transform.position) < 0.3F)
                    {
                        transform.Translate(new Vector3(-0.1F, 0, 0));
                    }
                }
            }
        }
        return false;
    }
    /// <summary>
    /// Check if Ground detected; true = yes
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public bool GroundCheck(Transform transform, LayerMask layer)
    {
        //hit = Physics2D.BoxCast(new Vector3(transform.position.x, transform.position.y - 0.1F, transform.position.z), new Vector2(0.4F, 0.4F), 0, transform.TransformDirection(Vector3.down), 0.1F, layer);
        if (Physics2D.BoxCast(new Vector3(transform.position.x, transform.position.y - 0.1F, transform.position.z), new Vector2(0.4F, 0.4F), 0, transform.TransformDirection(Vector3.down), contactFilter, hitArray, 0.1F) > 0)
        {
            foreach (RaycastHit2D hit in hitArray)
            {
                if (hit && hit.collider.transform != transform)
                {
                    if (Vector3.Distance(hit.point, transform.position) < 0.38F)
                    {
                        transform.Translate(new Vector3(0, 0.2F, 0));
                    }
                    return true;
                }
            }
        }
        return false;
    }
    /// <summary>
    /// dont hit your head; true if you did it;
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public bool HeadCheck(Transform transform, LayerMask layer)
    {
        //hit = Physics2D.BoxCast(new Vector3(transform.position.x, transform.position.y + 0.1F, transform.position.z), new Vector2(0.4F, 0.4F), 0, transform.TransformDirection(Vector3.up), 0.1F, layer);
        if (Physics2D.BoxCast(new Vector3(transform.position.x, transform.position.y + 0.1F, transform.position.z), new Vector2(0.4F, 0.4F), 0, transform.TransformDirection(Vector3.up), contactFilter, hitArray, 0.1F) > 0)
        {
            foreach (RaycastHit2D hit in hitArray)
            {
                if (hit && hit.distance < 0.1F && hit.collider.transform != transform)
                {
                    if (Vector3.Distance(hit.point, transform.position) < 0.2F)
                    {
                        transform.Translate(new Vector3(0, -0.1F, 0));
                    }
                    return true;
                }
            }
        }
        return false;
    }

}