using UnityEngine;
using UnityEngine.InputSystem;

public class GroundSlashShooter : MonoBehaviour
{
    public GroundSlash Projectile;
    public Transform Origin;

    private PlayerInput _playerInput;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void OnShoot(){
        var projectile = Instantiate(Projectile, Origin.position, Quaternion.identity);
        projectile.Initialize(Origin);
    }
}
