using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private GameObject parent;
    public GameObject Parent { set { parent = value; } get { return parent; } }



    private float speed=10.0F;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }
    private SpriteRenderer sprite;

    public Color Color
    {
        set { sprite.color = value; }
    }


    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        Destroy(gameObject, 1.4F);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        Obstacle obstacle = collider.GetComponent<Obstacle>();
        Ground ground = collider.GetComponent<Ground>();
        Character character = FindObjectOfType<Character>();
        if(ground)
        {
            Destroy(gameObject);
        }
        if(obstacle)
        {
            Destroy(gameObject);
        }

        if ((unit && unit.gameObject != parent))
        {
            if(unit is Character)
            {
                character.ReceveDamage();
            }
            Destroy(gameObject);
        }
       
       
      
        
    }
   
}
