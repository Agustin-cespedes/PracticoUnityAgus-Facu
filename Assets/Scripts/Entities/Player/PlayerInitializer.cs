using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField] private float maxHealth; 
    [SerializeField] private float speed;

private void Awake() 
{
    GetComponent<HealthSystem>().Initialize(maxHealth);
   // GetComponent<PlayerMovement>().Initialize(speed);
}
}
