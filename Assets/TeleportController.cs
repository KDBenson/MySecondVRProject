using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TeleportController : MonoBehaviour
{

    //listen on thumbstick for teleport selection input
    public GameObject baseControllerGameObject;
    public GameObject teleportationGameObject;

    public InputActionReference teleportActionReference;
    [Space]
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;

    private void Start()
    {
        teleportActionReference.action.performed += TeleportModeActivate;
        teleportActionReference.action.canceled += TeleportModeCancel;
    }

    private void TeleportModeCancel(InputAction.CallbackContext obj)
    {
        Invoke("DeactivateTeleporter", .1f);
    }

    void DeactivateTeleporter()
    {
        onTeleportCancel.Invoke();
    }

    private void TeleportModeActivate(InputAction.CallbackContext obj)
    {
        onTeleportActivate.Invoke();
    }
}
