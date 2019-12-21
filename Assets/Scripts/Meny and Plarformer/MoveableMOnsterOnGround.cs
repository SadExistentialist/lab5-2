using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveableMOnsterOnGround : Monster
{
    [SerializeField]
    private float speed = 2.0F;
    
    private SpriteRenderer sprite;
    private Vector3 direction;
    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        
    }
    protected override void Start()
    {
        direction = transform.right;
    }
    protected override void Update()
    {
        Move();

    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
         Unit unit = collider.GetComponent<Unit>();
         if(unit && unit is Character )
         {
             if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.5F) ReceveDamage();
             else unit.ReceveDamage();

         }

        /*Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet)

            ReceveDamage();*/
    }
    private void Move()
    {
        Collider2D[] colliders1 = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x * 0.8F, 0.2F);
        if (colliders1.Length > 0 && colliders1.All(x => !x.GetComponent<Character>())) direction *= -1.0F;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x > 0.0F;
    }

}

