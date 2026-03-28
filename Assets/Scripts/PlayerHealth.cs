using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{

    [SerializeField] GameObject fullHeart;
    [SerializeField] GameObject emptyHeart;
    [SerializeField] Transform heartsContainer;
    [SerializeField] Animator animator;

    void Start()
    {
        StatsManager.Instance.currentHearts = StatsManager.Instance.maxHearts;
        CreateHearts(StatsManager.Instance.maxHearts, StatsManager.Instance.currentHearts);
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
        StatsManager.Instance.currentHearts -= damage;
        animator.Play("HeartContainer");
        if (StatsManager.Instance.currentHearts < 0)
            StatsManager.Instance.currentHearts = 0;
        CreateHearts(StatsManager.Instance.maxHearts, StatsManager.Instance.currentHearts);
        if (StatsManager.Instance.currentHearts == 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        StatsManager.Instance.currentHearts += healAmount;
        if (StatsManager.Instance.currentHearts > StatsManager.Instance.maxHearts)
            StatsManager.Instance.currentHearts = StatsManager.Instance.maxHearts;
        CreateHearts(StatsManager.Instance.maxHearts, StatsManager.Instance.currentHearts);
    }

    public void IncreaseMaxHearts(int amount)
    {
        StatsManager.Instance.maxHearts += amount;
        CreateHearts(StatsManager.Instance.maxHearts, StatsManager.Instance.currentHearts);
    }

    void Die()
    {
        Debug.Log("Player Died");
    }
}