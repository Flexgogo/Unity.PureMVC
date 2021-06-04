using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using OrderSystem;

public class ClientCommand :SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        ClientProxy clientProxy = Facade.RetrieveProxy(ClientProxy.NAME) as ClientProxy;
        SendNotification(ClientEvent.GET_CLIENT_LIST_BACK, clientProxy.Clients);
    }
}
