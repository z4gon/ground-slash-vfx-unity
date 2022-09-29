using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class GroundSlashShooter : MonoBehaviour
{
    public GroundSlash Projectile;
    public Transform FirePoint;

    private PlayerInput _playerInput;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnShoot(){
        Debug.Log("Shoot!!");
    }
}
