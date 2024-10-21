using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float cameraSmoothness;

    private PlayerController playerController;

    void Start() => playerController = FindObjectOfType<PlayerController>();

    void Update()
    {
        if(playerController.speedCurrent >= 100)
        Debug.Log("Screaming for my life: AAAAAHHHHHHHH");
    }        

    void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position + player.transform.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSmoothness * Time.deltaTime);

        transform.LookAt(player.transform.position);
    }
}
