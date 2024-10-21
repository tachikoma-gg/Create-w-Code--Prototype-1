using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedMax;
    [SerializeField] private float bankSpeed;
    [SerializeField] private float pitchSpeed;
    [SerializeField] private float throttleResponse;

    private float _speedCurrent;
    public float speedCurrent
    {
        get
        {
            return _speedCurrent;
        }
    }

    private Vector3 input;
    private Vector3 move;

    // private float gravity = 20;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Collider collider = GetComponent<Collider>();
        Physics.IgnoreCollision(characterController, collider);
    }

    void Update()
    {
        input.z = Input.GetAxis("Vertical");
        input.x = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.I))
        _speedCurrent += throttleResponse * Time.deltaTime;
            

        if(Input.GetKey(KeyCode.K))
        _speedCurrent -= throttleResponse * Time.deltaTime;

        _speedCurrent = Mathf.Clamp(_speedCurrent, 0, speedMax);

        move = transform.rotation * Vector3.forward * _speedCurrent;

        transform.Rotate(input.x * -bankSpeed * Time.deltaTime * Vector3.forward);
        transform.Rotate(input.z * pitchSpeed * Time.deltaTime * Vector3.right);

        // move.y = characterController.isGrounded ? -0.2f : move.y - gravity * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
    }
}
