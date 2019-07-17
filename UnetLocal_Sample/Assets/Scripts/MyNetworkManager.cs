using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(MyNetworkDiscovery))]
public class MyNetworkManager : NetworkManager
{
    //get network discovery component
    private MyNetworkDiscovery _discovery;

    private void Start()
    {
        _discovery=GetComponent<MyNetworkDiscovery>();
        //this require on network discovery
        _discovery.Initialize();
    }

    public void SearchGame()
    {
        //start search for servers over network
        _discovery.StartAsClient();
    }

    public void HostGame()
    {
        //broadcast i am server :D
        _discovery.StartAsServer();
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