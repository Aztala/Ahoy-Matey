using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class NetworkManagerHUD : NetworkManager {

    private GameObject HUDStartHost,HUDStopHost;
    private void Start()
    {
        HUDStartHost = GameObject.Find("StartHost");
        HUDStopHost = GameObject.Find( "StopHost" );
        HUDControl( true, false );
    }
    public void HostStart()
    {
        Debug.Log( Time.timeSinceLevelLoad + " : Starting host");
        StartHost();
    }
    public override void OnStartHost()
    {
        Debug.Log( Time.timeSinceLevelLoad + " : Host as started.");
        HUDControl( false, true );
        
    }
    public override void OnStopHost()
    {
        HUDControl( true, false );
    }
    public override void OnStartClient(NetworkClient myClient)
    {
        Debug.Log( Time.timeSinceLevelLoad + " : client start requested." );
        InvokeRepeating("DotWait",0f,1f);
    }
    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log( Time.timeSinceLevelLoad + " : client(" + conn.address + ") is connected");
        CancelInvoke();
    }
    public override void OnClientError(NetworkConnection conn, int errorCode)
    {
        Debug.Log( Time.timeSinceLevelLoad + " : client(" + conn.address + ") connection error #" + errorCode);
    }
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log( Time.timeSinceLevelLoad + " : client(" + conn.address + ") diconnected from server " );
    }

    private void DotWait()
    {
        Debug.Log(".");
    }

    //Set the display of button
    private void HUDControl(bool starthost, bool stophost)
    {
        HUDStartHost.SetActive( starthost );
        HUDStopHost.SetActive( stophost );
    }
}
