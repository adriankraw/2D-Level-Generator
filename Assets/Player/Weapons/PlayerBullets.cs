using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    private Queue<Bullets> bullets = new Queue<Bullets>();

    private Bullets firstQueueBullet;

    private void Awake() {
        foreach(Bullets bullet in GetComponentsInChildren<Bullets>())
        {
            bullets.Enqueue(bullet);
            bullet.gameObject.SetActive(false);
        }
    }
    public Bullets GetBullets()
    {
        firstQueueBullet = bullets.Peek();
        bullets.Enqueue(bullets.Dequeue());
        return firstQueueBullet;
    }
    public void ShootBullet(Vector3 position, Vector3 direction)
    {
        firstQueueBullet = bullets.Peek();
        firstQueueBullet.reset();
        bullets.Enqueue(bullets.Dequeue());
        firstQueueBullet.gameObject.SetActive(true);
        firstQueueBullet.transform.position = position;
        direction.z = 0;
        firstQueueBullet.move = direction;
    }
}
