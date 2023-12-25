using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed = 7;
    public bool flagMove = true;
    public float distance = 2f;
    public float timeInvincible = 2.0f;
    
    private bool isInvincible;
    private float invincibleTimer;

    public int sanity = 100;
    private int maxSanity;

    private Collider2D enemyCollider;  // Добавляем переменную для коллайдера укрытия
    private Collider2D doorCollider;
    private Collider2D shelterCollider;  // Добавляем переменную для коллайдера укрытия
    private SpriteRenderer rend;

    public Image sanityBar;

    private EventManager eventManager;

    void Start()
    {
        maxSanity = sanity;

        shelterCollider = null;  // Инициализируем переменную коллайдера
        rend = gameObject.GetComponent<SpriteRenderer>();

        eventManager = FindObjectOfType<EventManager>();
    }

    void Update()
    {
        if(flagMove)
        { 
            float horizontal = Input.GetAxis("Horizontal");
            //float vertical = Input.GetAxis("Vertical");
            Vector2 position = transform.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            //position.y = position.y + speed * vertical * Time.deltaTime;
            transform.position = position;
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        //if(eventManager.isNight)
        //{ 
            Hide();
            Attack();
        //}

        Open();
    }

    public void takeDeath()
    {
        sanityBar.fillAmount = 0;
        Destroy(gameObject);
    }

    public void takeHit(int damage)
    {
        if (GetHided.isHided || isInvincible)
            return;

        isInvincible = true;
        invincibleTimer = timeInvincible;

        sanity -= damage;
        sanityBar.fillAmount = sanity / 100.0f;

        if (sanity <= 0)
            Destroy(gameObject);
    }

    public void takeShot(int damage)
    {
        if (GetHided.isHided)
            return;

        sanity -= damage;
        sanityBar.fillAmount = sanity / 100.0f;

        if (sanity <= 0)
            Destroy(gameObject);
    }

    public void setHealth(int medkit)
    {
        sanity += medkit;

        if (sanity > maxSanity)
            sanity = maxSanity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DamageObj"))
        {
            takeHit(40);
        }
        if (other.gameObject.CompareTag("HealthObj"))
        {
            setHealth(25);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("ShelterObj"))
        {
            shelterCollider = other;  // Сохраняем коллайдер укрытия
        }
        if (other.CompareTag("Enemy"))
        {
            enemyCollider = other;  // Сохраняем коллайдер врага
        }
        if (other.CompareTag("Door"))
        {
            doorCollider = other;  // Сохраняем коллайдер двери
        }
        if (other.CompareTag("Monster"))
        {
            speed = 3;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == shelterCollider)
        {
            shelterCollider = null;  // Сбрасываем коллайдер укрытия при выходе из него
        }
        if (other == enemyCollider)
        {
            enemyCollider = null;  // Сбрасываем коллайдер врага
        }
        if (other == doorCollider)
        {
            doorCollider = null;  // Сбрасываем коллайдер двери
        }
        if (other.CompareTag("Monster"))
        {
            speed = 7;
        }
    }

    public void Hide()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!GetHided.isHided)
            {
                if (shelterCollider != null)
                {
                    GetHided.isHided = true;
                    Visability(0f);
                    flagMove = false;
                    //Вывод надписи вы "спрятаны" над шкафом
                }
            }
            else
            {
                GetHided.isHided = false;
                Visability(1f);
                flagMove = true;
            }
        }
    }

    public void Open()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //если дверь заперта и у персонажа есть ключ - дверь открыта 
            if (doorCollider != null && !doorCollider.gameObject.GetComponent<Door>().GetOpen() 
                && gameObject.GetComponent<Items>().getBools()[2]) // 2 == Key
            {
                doorCollider.gameObject.GetComponent<Door>().SetOpen(true);
            }
            //иначе надпись "Найдите ключ"
            else if (doorCollider != null)
            {

            }
            if (doorCollider != null && doorCollider.gameObject.GetComponent<Door>().GetOpen())
            {
                transform.position = doorCollider.gameObject.GetComponent<Door>().GetDestination().position;
            }
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            //если враг в радиусе атаки и есть оружие - атака
            if (enemyCollider != null && gameObject.GetComponent<Items>().getBools()[0]) // 0 == Amulet
            {
                if(enemyCollider.gameObject.GetComponent<MovingMonster>() != null 
                    || enemyCollider.gameObject.GetComponent<EnemyShooting>() != null) 
                    //MovingMonster и EnemyShooting - первый ранг
                    Destroy(enemyCollider.gameObject); 

                //Иначе у вас нет оружия против него
            }
            else if (enemyCollider != null && gameObject.GetComponent<Items>().getBools()[1]) // 1 == Book
            {
                //if (enemyCollider.gameObject.GetComponent<>() != null) //MovingMonster - первый ранг
                    Destroy(enemyCollider.gameObject);

                //Иначе у вас нет оружия против него
            }
        }
    }

    public void Visability(float alpha)
    {
        Color color = rend.color;
        color.a = alpha;
        rend.color = color;
    }
}