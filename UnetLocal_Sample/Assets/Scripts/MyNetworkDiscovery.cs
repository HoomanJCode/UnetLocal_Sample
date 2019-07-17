using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(MyNetworkManager))]
public class MyNetworkDiscovery : NetworkDiscovery
{
    //get network manager component
    private MyNetworkManager Manager
    {
        get { return GetComponent<MyNetworkManager>(); }
    }

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        //you searching for server
        //if your device found server that broadcasting ip, you can connect to that server from this override
        Manager.JoinGame(fromAddress);
        //after join we should stop this function.
        //if you remove this line, game scene loading for multiple time :D and connecting for multiple time.
        //this override call multiple time when searching
        StopBroadcast();
        //attention you can send maximum player and some info about your server over "data" parameter. default is "Hello" string.
    }
}