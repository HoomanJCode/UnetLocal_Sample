using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(MyNetworkDiscovery))]
public class MyNetworkManager : NetworkManager
{
    //get network discovery component
    private MyNetworkDiscovery Discovery
    {
        get { return GetComponent<MyNetworkDiscovery>(); }   
    }

    private void Start()
    {
        //this require on network discovery
        Discovery.Initialize();
    }

    public void SearchGame()
    {
        //start search for servers over network
        Discovery.StartAsClient();
    }

    public void HostGame()
    {
        //broadcast i am server :D
        Discovery.StartAsServer();
        //start server over this ip
        StartHost();
    }

    public void JoinGame(InputField ip)
    {
        //set target ip
        networkAddress = ip.text;
        //connect to server
        StartClient();
    }
    public void JoinGame(string ip)
    {
        networkAddress = ip;
        StartClient();
    }
}
