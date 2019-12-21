using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMonster : Monster {
    [SerializeField]
    private float rate = 2.0F;
    [SerializeField]
    private Color bulletColor = Color.white;
    private Bullet bullet;
    private SpriteRenderer sprite;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("2dPlatformer/Bullet");
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    private void Shoot()
    {
        Vector3 position = transform.position;
        position.y += 0.5F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newBullet.Parent = gameObject;
        if (sprite.flipX == true)
        {
            newBullet.Direction = newBullet.transform.right;
        }
        if (sprite.flipX == false)
        {
            newBullet.Direction = -newBullet.transform.right;
        }
        newBullet.Color = bulletColor;
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceveDamage();
            else unit.ReceveDamage();

        }
    }
}
