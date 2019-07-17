using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyNetworkManager : NetworkManager
{
    public void HostGame()
    {
        StartHost();
    }

    public void JoinGame(InputField ip)
    {
        networkAddress = ip.text;
        StartClient();
    }
}
