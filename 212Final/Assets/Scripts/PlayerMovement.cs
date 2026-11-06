using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.5f;
    [SerializeField] float sprintSpeed = 11f;
    [SerializeField] float maxStamina = 100f;
    float currentStamina;
    bool isSprinting;
    [SerializeField] float stamDrain = 5f;
    [SerializeField] float stamRegen = 2.5f;
    [SerializeField] float stamRegenDelay = 1.2f;
    float stamRegenTimer;

    [SerializeField] Transform gun;
    [SerializeField] GameObject bullet;
    [SerializeField] Slider staminaSlider;

    InputAction moveAction;
    InputAction sprintAction;

    Vector3 moveVector;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        sprintAction = InputSystem.actions.FindAction("Sprint");
        currentStamina = maxStamina;
        if(staminaSlider != null)
        {
            staminaSlider.maxValue = maxStamina;
            staminaSlider.value = maxStamina;
        }
    }

    void Update()
    {
        MovePlayer();
        StaminaBar();
    }

    void StaminaBar()
    {
        staminaSlider.value = currentStamina;
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        float currentSpeed;
        bool isSprinting = sprintAction.IsPressed() && moveVector.magnitude > 0;

        if (isSprinting && currentStamina > 0)
        {
            currentSpeed = sprintSpeed;
            currentStamina -= stamDrain * Time.deltaTime;
            stamRegenTimer = 0;
        }
        else
        {
            currentSpeed = moveSpeed;
            stamRegenTimer += Time.deltaTime;
            if (stamRegenTimer >= stamRegenDelay)
            {
                currentStamina += stamRegen * Time.deltaTime;
            }
        }
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        transform.position += moveVector * currentSpeed * Time.deltaTime;

    }

    void Sprint()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        transform.position += moveVector * sprintSpeed * Time.deltaTime;
    }

    void OnAttack(InputValue value)
    {
        Instantiate(bullet, gun.position, transform.rotation);
    }
}
