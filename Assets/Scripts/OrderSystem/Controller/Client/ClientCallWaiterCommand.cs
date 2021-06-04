using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using OrderSystem;
using System.Collections.Generic;

public class ClientCallWaiterCommand :SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        ClientItem client = notification.Body as ClientItem;
        if(client.state.Equals(E_ClientState.WaitMenu))
        {
            OrderProxy orderProxy = Facade.RetrieveProxy(OrderProxy.NAME) as OrderProxy;
            Order order = new Order(client, new List<MenuItem>());
            orderProxy.AddOrder(order);
            Debug.Log(" 服务员给" + client.id + "号桌顾客拿菜单和订单 ");
            SendNotification(OrderSystemEvent.UPMENU, order);
        }
        else
        {
            Debug.Log("已经下单");
        }
    }
}
