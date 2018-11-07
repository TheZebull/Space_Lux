﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour {

    public int worth;
    public float speed;
    private bool isMoving = false;
    private AudioSource pickupSound;
    private Transform target;
    [SerializeField]
    private CapsuleCollider2D capsuleCollider;
    
    // Awake function
    private void Awake() {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        pickupSound = GetComponent<AudioSource>();
    }    

    // Update function
    public void Update() {
        if (isMoving) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);            
        }
    }

    // When player enters circle collider
    private void OnTriggerEnter2D(Collider2D other) {       
        if (other.tag.Equals("Player") && other.IsTouching(this.capsuleCollider)) {     // Check if other is player
            pickupSound.Play();
            other.gameObject.GetComponent<PlayerPickup>().IncrementResource(worth);
            Destroy(gameObject);           
        }        
    }
      
    // Function called when player enters circle collider
    public void MoveToPlayer(Transform player) {
        target = player;
        isMoving = true;
    }
}
