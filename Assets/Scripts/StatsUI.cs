using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class StatsUI : MonoBehaviour
{
    public GameObject[] StatsSlots;
    private bool statsOpen = false;
    private PlayerInputs inputActions;
    public Animator animator;

    private void Start()
    {
        UpdateAllStats();
    }

    private void Awake()
    {
        inputActions = new PlayerInputs();
    }

    private void OnEnable()
    {
        inputActions.UI.Enable();
        inputActions.UI.ToggleStats.performed += ToggleStats;
    }

    private void OnDisable()
    {
        inputActions.UI.ToggleStats.performed -= ToggleStats;
        inputActions.UI.Disable();
    }

    private void ToggleStats(InputAction.CallbackContext context)
    {
        statsOpen = !statsOpen;
        animator.SetBool("isOpen", statsOpen);

    }

    public void UpdateDamage()
    {
        StatsSlots[0].GetComponentInChildren<TMP_Text>().text = "Attack: " + StatsManager.Instance.attackDamage;
    }
    public void UpdateSpeed()
    {
        StatsSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatsManager.Instance.moveSpeed;
    }

    public void UpdateHearts()
    {
        StatsSlots[2].GetComponentInChildren<TMP_Text>().text = "Hearts: " + StatsManager.Instance.maxHearts;
    }

    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
        UpdateHearts();
    }

}

