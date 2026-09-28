using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private InputAction click;
    [SerializeField] private InputAction hold;
    [SerializeField] private InputAction point;
    [SerializeField] private Camera mainCamera;

    private IHoldable CurrentHoldable;

    private void OnEnable()
    {
        click.Enable();
        hold.Enable();
        point.Enable();

        click.performed += OnClick;

        hold.started += OnHoldStarted;
        hold.canceled += OnHoldReleased;
    }

    private void OnDisable()
    {
        click.performed -= OnClick;

        hold.started -= OnHoldStarted;
        hold.canceled -= OnHoldReleased;

        click.Disable();
        hold.Disable();
        point.Disable();
    }

    private void Update()
    {
        if (CurrentHoldable != null)
        {
            Vector2 cursorPosition = point.ReadValue<Vector2>();
            CurrentHoldable.Hold(cursorPosition, Time.deltaTime);
        }
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        IClickable clickable = GetClickableUnderCursor();

        if (clickable != null)
        {
            clickable.Clicked();
        }
    }
    private IClickable GetClickableUnderCursor()
    {
        Vector2 cursorPosition = point.ReadValue<Vector2>();
        Ray ray = mainCamera.ScreenPointToRay(cursorPosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider == null)
        {
            Debug.Log("Miss Clicked");
            return null;
        }
        else
        {
            Debug.Log("Success Clicked");
            return hit.collider.GetComponent<IClickable>();
        }
    }
    private void OnHoldStarted(InputAction.CallbackContext context)
    {
        IHoldable holdable = GetHoldableUnderCursor();

        if (holdable != null)
        {
            CurrentHoldable = holdable;
        }
    }

    private void OnHoldReleased(InputAction.CallbackContext context)
    {
        if (CurrentHoldable != null)
        {
            CurrentHoldable.Release();
            CurrentHoldable = null;
        }
    }
    private IHoldable GetHoldableUnderCursor()
    {
        Vector2 cursorPosition = point.ReadValue<Vector2>();

        Ray ray = mainCamera.ScreenPointToRay(cursorPosition);

        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider == null)
            return null;

        return hit.collider.GetComponent<IHoldable>();
    }
}
    
