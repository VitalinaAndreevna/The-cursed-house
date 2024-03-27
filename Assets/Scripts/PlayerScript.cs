using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;


public class PlayerScript : MonoBehaviour
{
    public float speed = 7;
    public bool flagMove = true;
    public float distance = 2f;
    public float timeInvincible = 2.0f;
    
    private bool isInvincible;
    private float invincibleTimer;

    public bool deathFlag = false;

    public int sanity = 100;
    private int maxSanity;

    private Collider2D enemyCollider;
    private Collider2D doorCollider;
    private Collider2D shelterCollider;
    private SpriteRenderer rend;

    public Canvas alertsCanvas;

    public Image sanityBar;

    private Animator animator;

    private EventManager eventManager;

    void Start()
    {
        maxSanity = sanity;

        shelterCollider = null; 
        rend = gameObject.GetComponent<SpriteRenderer>();

        eventManager = FindObjectOfType<EventManager>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Hide();
        Attack();
        Open();

        if (flagMove)
        { 
            float horizontal = Input.GetAxis("Horizontal");
            Vector2 position = transform.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            transform.position = position;

            animator.SetFloat("x", horizontal);

            if (horizontal == 0)
            {
                animator.SetBool("isWalking", false);
            }
            else
            {
                animator.SetBool("isWalking", true);
            }
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (deathFlag && Input.anyKeyDown)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void takeDeath()
    {
        sanityBar.fillAmount = 0;
        Destroy(gameObject);
        alertsCanvas.enabled = true;
        alertsCanvas.gameObject.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "ВЫ УМЕРЛИ!";
        //завершение игры(Обнуление результатов дня)
        deathFlag = true;
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
            takeDeath();
    }

    public void takeShot(int damage)
    {
        if (GetHided.isHided)
            return;

        sanity -= damage;
        sanityBar.fillAmount = sanity / 100.0f;

        if (sanity <= 0)
            takeDeath();
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
            shelterCollider = other;
        }
        if (other.CompareTag("Enemy"))
        {
            enemyCollider = other;
        }
        if (other.CompareTag("Door"))
        {
            doorCollider = other;
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
            shelterCollider = null;
        }
        if (other == enemyCollider)
        {
            enemyCollider = null;
        }
        if (other == doorCollider)
        {
            doorCollider = null;
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
            if (!GetHided.isHided && eventManager.isNight)
            {
                if (shelterCollider != null)
                {
                    GetHided.isHided = true;
                    Visability(0f);
                    flagMove = false;
                    //Вывод надписи вы "спрятаны" над шкафом
                    alertsCanvas.enabled = true;
                    alertsCanvas.gameObject.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "Вы спрятаны";
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
            if (doorCollider != null && doorCollider.gameObject.GetComponent<Door>().GetOpen())
            {
                transform.position = doorCollider.gameObject.GetComponent<Door>().GetDestination().position;
            }
            else if (doorCollider != null && !doorCollider.gameObject.GetComponent<Door>().GetOpen() 
                && gameObject.GetComponent<Items>().getBools()[2]) // 2 == Key
            {
                doorCollider.gameObject.GetComponent<Door>().SetOpen(true);
            }
            //дверь закрыта, вывод надписи "Найдите ключ"
            else if (doorCollider != null && !doorCollider.gameObject.GetComponent<Door>().GetOpen()
                && !gameObject.GetComponent<Items>().getBools()[2])
            {
                alertsCanvas.gameObject.SetActive(true);
                alertsCanvas.gameObject.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "Найдите ключ";
            }
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            //если враг в радиусе атаки и есть оружие - атака
            if (enemyCollider != null)
            {
                if(enemyCollider.gameObject.GetComponent<MovingMonster>() != null 
                    || enemyCollider.gameObject.GetComponent<EnemyShooting>() != null
                    || enemyCollider.gameObject.GetComponent<DamageZone>() != null) //MovingMonster, EnemyShooting и DamageZone - первый ранг 
                { 
                    if (gameObject.GetComponent<Items>().getBools()[0]) // 0 == Amulet
                        Destroy(enemyCollider.gameObject);
                    else
                    {
                        alertsCanvas.enabled = true;
                        alertsCanvas.gameObject.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "У вас нет оружия";
                        // Запускаем корутину, которая скрывает канвас после 2 секунд
                        StartCoroutine(alertsCanvas.gameObject.GetComponent<Alerts>().HideCanvasAfterDelay(2.0f));
                    }
                }
                else if (enemyCollider.gameObject.GetComponent<InstaKiller>() != null) //InstaKiller - второй ранг
                {
                    if (gameObject.GetComponent<Items>().getBools()[0] && gameObject.GetComponent<Items>().getBools()[1]) //1 == Grimuar
                        Destroy(enemyCollider.gameObject);
                    else
                    {
                        alertsCanvas.enabled = true;
                        alertsCanvas.gameObject.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "У вас нет оружия";
                        // Запускаем корутину, которая скрывает канвас после 2 секунд
                        StartCoroutine(alertsCanvas.gameObject.GetComponent<Alerts>().HideCanvasAfterDelay(2.0f));
                    }
                }
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