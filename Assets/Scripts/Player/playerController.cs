using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D body;

    public Transform gunTransform;
    private Master controls;

    private Vector2 moveInput;



    // Start is called before the first frame update
    
    private void Awake()
    {
        controls = new Master();
    }

    private void OnEnable(){
        controls.Enable();
    }

    private void OnDisable(){
        controls.Disable();
    }

    private void FixedUpdate(){
        Move(); 
    }

    private void Move(){
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        Vector2 movement = new Vector2(moveInput.x, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
        body.MovePosition(body.position + movement);
    }



    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot(){
        if(controls.Player.Shoot.triggered){
            Debug.Log("Shoot");
            //Luodaan ammus kutsumalla BulletPoolManagerin GetBullet metodia
            GameObject bullet = BulletPoolManager.Instance.GetBullet();
            //Laitetaan ammus pelaajan aseen kohdalle
            bullet.transform.position = gunTransform.position;
            bullet.transform.rotation = gunTransform.rotation;
        }
    }
}
