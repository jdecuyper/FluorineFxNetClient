using System;
using FluorineFx;
using FluorineFx.Net;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Api.Service;
using FluorineFx.AMF3;
using System.Reflection;
using System.Collections.Generic;
using System.Data;

namespace FluorineFx
{
    class FluorineNetClient
    {
        public FluorineNetClient(string gateway) {
            _gateway = gateway;
            SetUp();
        }

        private string _gateway;
        private NetConnection _netConnection;

        private void SetUp(){
            _netConnection = new NetConnection();
            _netConnection.ObjectEncoding = ObjectEncoding.AMF3;
            _netConnection.NetStatus += new NetStatusHandler(_netConnection_NetStatus);
            _netConnection.Connect(_gateway);
        }

        public void Call<T>(string command, params object[] arguments)
        {
            StatusFunction errFn = new StatusFunction(ErrorOccured.ErrorReceived);
            ResultFunction<T> rsltFn = new ResultFunction<T>(ProcessResult.ResultReceived<T>);
            Responder<T> rpd = new Responder<T>(rsltFn, errFn);
            _netConnection.Call<T>(command, rpd, arguments);
        }

        private void _netConnection_NetStatus(object sender, NetStatusEventArgs e)
        {
            string level = e.Info["level"] as string;
            if (level == "error")
            {
                Console.WriteLine("Connection error occured: {0}", e.Info["code"] as string);
            }
            if (level == "status")
            {
                Console.WriteLine("Connection's status: {0}", (e.Info["code"] as string));
            }
        }
    }
}
