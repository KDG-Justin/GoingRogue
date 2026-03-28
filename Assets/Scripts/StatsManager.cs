using UnityEngine;

public class StatsManager : MonoBehaviour
{

    public static StatsManager Instance;

    [Header("Combat Stats")]
    public int attackDamage;
    public float attackRange;
    public float attackCooldown;

    [Header("Movement Stats")]
    public float moveSpeed;

    [Header("Health Stats")]
    public int maxHearts;
    public int currentHearts;
    public int armor;
    public float dodgeChance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
