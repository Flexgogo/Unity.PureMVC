
/*=========================================
* Author: Administrator
* DateTime:2017/6/20 19:20:37
* Description:$safeprojectname$
==========================================*/

using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace OrderSystem
{
    public class ClientMediator : Mediator
    {
        private ClientProxy clientProxy = null;
        public new const string NAME = "ClientMediator";
        private ClientView View
        {
            get { return (ClientView)ViewComponent; }
        }

        public ClientMediator( ClientView view ) : base(NAME , view)
        {
            view.CallWaiter += data => {
                SendNotification(ClientEvent.CLIENT_CALL_WAITER, data);
            };
        }

        public override void OnRegister()
        {
            base.OnRegister();

            SendNotification(ClientEvent.GET_CLIENT_LIST);
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> notifications = new List<string>();
            notifications.Add(OrderSystemEvent.ORDER);
            notifications.Add(OrderSystemEvent.PAY); 
            notifications.Add(ClientEvent.GET_CLIENT_LIST_BACK); 
            return notifications;
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case OrderSystemEvent.ORDER: 
                    Order order1 = notification.Body as Order;
                    if(null == order1)
                        throw new Exception("order1 is null ,please check it!");
                    order1.client.state++;
                    View.UpdateState(order1.client);
                    break;
                case OrderSystemEvent.PAY:
                    Order finishOrder = notification.Body as Order;
                    if ( null == finishOrder )
                        throw new Exception("finishOrder is null ,please check it!");
                    finishOrder.client.state++;
                    View.UpdateState(finishOrder.client);
                    SendNotification(OrderSystemEvent.GET_PAY, finishOrder);
                    break;

                case ClientEvent.GET_CLIENT_LIST_BACK:
                    View.UpdateClient(notification.Body as IList<ClientItem>);
                    break;
            }
        }
    }
}