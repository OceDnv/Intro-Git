using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed = 60f; // Vitesse déplacement
    public float mouseSensitivity = 60f; // Sensibilité souris

    [Header("Camera Settings")]
    public Transform playerCamera; // Réf caméra
    public float verticalRotationLimit = 80f; // Limite de rotation verticale en degrés

    private Rigidbody playerRigidbody;
    private float verticalRotation = 0f;

    void Start()
    {
        // souris cache
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Rigidbody joeur
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement(); //déplacement
        HandleCameraRotation(); //rotation de la caméra
    }

    private void HandleMovement()
    {
        //clavier
        float moveX = Input.GetAxis("Horizontal"); // A/D ou Q/D
        float moveZ = Input.GetAxis("Vertical");   // W/S ou Z/S

        // Calcule mouvement joueur
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // déplacement
        playerRigidbody.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);
    }

    private void HandleCameraRotation()
    {
        //souris
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Gère la rotation hori
        transform.Rotate(Vector3.up * mouseX);

        //rotation verticale
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);

        // rotation verticale caméra
        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
