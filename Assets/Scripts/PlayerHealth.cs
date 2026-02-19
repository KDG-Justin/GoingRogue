using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3;
    private int currentHearts;

    [SerializeField] GameObject fullHeart;
    [SerializeField] GameObject emptyHeart;
    [SerializeField] Transform heartsContainer;
    [SerializeField] Animator animator;

    void Start()
    {
        currentHearts = maxHearts;
        CreateHearts(maxHearts, currentHearts);
    }

    public void CreateHearts(int maxHearts, int currentHearts)
    {
        foreach (Transform child in heartsContainer)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < maxHearts; i++)
        {
            if (i + 1 <= currentHearts)
            {
                GameObject heart = Instantiate(fullHeart, heartsContainer.position, Quaternion.identity);
                heart.transform.parent = heartsContainer;
            }
            else
            {
                GameObject heart = Instantiate(emptyHeart, heartsContainer.position, Quaternion.identity);
                heart.transform.parent = heartsContainer;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHearts -= damage;
        animator.Play("HeartContainer");
        if (currentHearts < 0)
            currentHearts = 0;
        CreateHearts(maxHearts, currentHearts);
        if (currentHearts == 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHearts += healAmount;
        if (currentHearts > maxHearts)
            currentHearts = maxHearts;
        CreateHearts(maxHearts, currentHearts);
    }

    public void IncreaseMaxHearts(int amount)
    {
        maxHearts += amount;
        CreateHearts(maxHearts, currentHearts);
    }

    void Die()
    {
        Debug.Log("Player Died");
    }
}