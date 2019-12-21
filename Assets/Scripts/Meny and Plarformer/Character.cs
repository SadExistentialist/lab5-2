using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit {
    [SerializeField]
    private int lives = 5;
    public int coins = 0;
    private int MonsterUpCheck;
    private int MoveableMonsterUpCheck;
    private int ObstacleUpCheck;
    public bool IsDead = false;
    public bool IsWonOnCoins = false;
    public bool IsPlay = true;
    Button_Show button_shoW;
    BackToMenu backToMenu;

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value <= 5)
            {
                lives = value;
                hearts.Refresh();
                Debug.Log(lives);
            }
        }
    }
    private Hearts hearts;
    [SerializeField]
    private float speed = 3.0F;

    [SerializeField]
    private float JumpForce = 15.0F;
    private bool isGrounded=false;

    private Bullet bullet;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Awake()
    {
        backToMenu = FindObjectOfType<BackToMenu>();
        hearts = FindObjectOfType<Hearts>();
        button_shoW = FindObjectOfType<Button_Show>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        bullet = Resources.Load<Bullet>("2dPlatformer/Bullet");
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Update()
    {
      if  (isGrounded)State = CharState.idle;

        if (!IsWonOnCoins)
        {

            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                
            }
        }
        
        if (Input.GetButton("Horizontal"))
        
            Run();
        
        if((isGrounded && Input.GetButtonDown("Jump")) &&(ObstacleUpCheck!=1 || MoveableMonsterUpCheck!=1 || MonsterUpCheck!=1))
        
            Jump();

        if (IsPlay)
        {
            if (!IsDead)
            {
                backToMenu.Button_Hide();
                button_shoW.Button_Hide();
            }
            if (!IsWonOnCoins)
            {
                backToMenu.Button_Hide();
                button_shoW.Button_Hide();
            }
        }
        if (lives==0 || coins == 7)
        {
            if (lives == 0)
            {
                Time.timeScale = 0f;
                IsDead = true;
                
            }
            if (coins == 7)
            {
                Time.timeScale = 0f;
                IsWonOnCoins = true;
                
            }
            IsPlay = false;
            button_shoW.Button_Shows();
            backToMenu.Button_Shows();
        }
        


    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX=direction.x<0.0F;
       if(isGrounded) State = CharState.Run;
    }
    private void Jump()
    {
        /*Obstacle obstacle = FindObjectOfType<Obstacle>();
        MoveableMonster moveable = FindObjectOfType<MoveableMonster>();    
        Monster monster = FindObjectOfType<Monster>();*/
        
        rigidbody.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        if (!IsDead)
        {
            Vector3 position = transform.position;
            position.y += 0.6F;
            Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
            newBullet.Parent = gameObject;
            newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
        }
    }
    public override void ReceveDamage()
    {
       // lives--;
        Lives--;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);

        //Debug.Log(lives);

    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);
        isGrounded = colliders.Length > 1;
        if(!isGrounded) State = CharState.Jump;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Obstacle obstacle = GetComponent<Obstacle>();
        MoveableMonster moveable = GetComponent<MoveableMonster>();
        Monster monster = GetComponent<Monster>();

        if(obstacle)
        {
            ObstacleUpCheck = 1;
        }
        if (moveable)
        {
            MoveableMonsterUpCheck = 1;
        }
        if (monster)
        {
            MonsterUpCheck = 1;
        }

    }
}
public enum CharState
{
    idle,
    Run,
    Jump
}
