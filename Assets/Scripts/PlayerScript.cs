using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
    // Speed at which the player moves.
    public float speed = 7;
    public bool flagMove = true;

    public int health = 100;
    private int maxHealth;

    public float distance = 2f;
    Collider2D enemyCollider;  // Добавляем переменную для коллайдера укрытия

    Collider2D shelterCollider;  // Добавляем переменную для коллайдера укрытия
    SpriteRenderer rend;

    Collider2D doorCollider;
    Collider2D itemCollider;

    // Start is called before the first frame update.
    void Start()
    {
        maxHealth = health;

        shelterCollider = null;  // Инициализируем переменную коллайдера
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per framea
    void Update()
    {
        if(flagMove)
        { 
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 position = transform.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;
            transform.position = position;
        }

        Hide();

        Take();
    }

    public void takeHit(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void setHealth(int medkit)
    {
        health += medkit;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
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
            takeHit(25);
            speed /= 3;
        }
        if (other.CompareTag("Item"))
        {
            itemCollider = other;  // Сохраняем коллайдер двери
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
        if (other == itemCollider)
        {
            itemCollider = null;  // Сбрасываем коллайдер двери
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
                if (shelterCollider != null && shelterCollider.IsTouching(GetComponent<Collider2D>()))
                {
                    GetHided.isHided = true;
                    Visability(0f);
                    flagMove = false;
                    //Вывод надписи вы спрятаны над шкафом
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //если дверь заперта и у персонажа есть ключ - дверь открыта 
            if (doorCollider != null && !doorCollider.gameObject.GetComponent<Door>().GetOpen() )
                //&& //gameObject.GetComponent<Items>().GetBools(0)) // 0 == Key
            {
                //можно сделать по стандарту через булевы переменные
                doorCollider.gameObject.GetComponent<Door>().SetOpen(true);
            }
            //иначе надпись "Найдите ключ"
            else if (doorCollider != null)
            {

            }
        }
    }

    public void Take()
    {
        if (itemCollider != null && itemCollider.IsTouching(GetComponent<Collider2D>()))
        {
            Button tempButton = itemCollider.gameObject.GetComponent<Button>();
            tempButton.onClick.AddListener(OnClickAction);
        }
    }

    public void OnClickAction()
    {
        Item item = itemCollider.gameObject.GetComponent<Item>();
        //gameObject.GetComponent<Inventory>().AddItem(item.id, item);
        Destroy(itemCollider.gameObject);
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            //если враг в радиусе атаки и есть оружие - атака
            if (enemyCollider != null && enemyCollider.IsTouching(GetComponent<Collider2D>()))
                //&& gameObject.GetComponent<Items>().GetBools(1)) // 1 == Amulet
            {
                Destroy(enemyCollider.gameObject); 

                //Добавить проверку на ранг монстра

            }
            else if (enemyCollider != null && enemyCollider.IsTouching(GetComponent<Collider2D>()))
                //&& gameObject.GetComponent<Items>().GetBools(2)) // 2 == Book
            {
                Destroy(enemyCollider.gameObject);

                //Добавить проверку на ранг монстра

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
