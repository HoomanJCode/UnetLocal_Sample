using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerManager : NetworkBehaviour
{
    //we need  access to our player from camera Manager
    public static PlayerManager MyPlayer;

    //access to rigidbody component
    private Rigidbody Rigidbody
    {
        get { return GetComponent<Rigidbody>(); }
    }

    //player speed
    [Tooltip("Player movement Speed.")]
    [SerializeField] private float speed = 8;

    private void Awake()
    {
        //if is my player
        if(isLocalPlayer)
            MyPlayer = this;
    }

    private void Start()
    {
        //my player on other devices not need rigidbody
        if (!isLocalPlayer && Rigidbody != null)
            Rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    private void Update()
    {
        //player movement * speed and deltatime
        if (isLocalPlayer)
            transform.position += Time.deltaTime * speed * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}