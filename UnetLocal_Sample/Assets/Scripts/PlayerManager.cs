using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour
{
    //we need  access to our player from camera Manager
    public static PlayerManager MyPlayer;

    //player speed
    [Tooltip("Player movement Speed.")] [SerializeField]
    private float speed = 8;

    //access to rigidbody component
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //if is my player
        if (isLocalPlayer)
            MyPlayer = this;
    }

    private void Start()
    {
        //my player on other devices not need rigidbody
        if (!isLocalPlayer && _rigidbody != null)
            _rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    private void Update()
    {
        //player movement * speed and deltatime
        if (isLocalPlayer)
            transform.position += Time.deltaTime * speed *
                                  new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}