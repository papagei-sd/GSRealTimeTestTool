﻿using GameSparks.Core;
using Gui;

namespace Services
{
    public class ConnectionService
    {
        public ConnectionService(ConnectionGui connectionGui)
        {
            _connectionGui = connectionGui;
        }

        public void Initialize()
        {
            GS.GameSparksAvailable += OnGsAvailable;
            _connectionGui.UserId.text = "No User Logged In...";
            _connectionGui.ConnectionStatus.text = "Connecting To GameSparks...";
        }

        /**
         * <summary>On End Session</summary>
         **/
        public void OnEndSession()
        {
            _connectionGui.UserId.text = "No User Logged In...";
            _connectionGui.ConnectionStatus.text = "GameSparks Connected...";
        }
        
        /**
         * <summary>On Registration, display reg details</summary>
         * <param name="name">Name</param>
         * <param name="userId">User Id</param>
         **/
        public void OnRegistration(string name, string userId)
        {
            _connectionGui.UserId.text = name + " (" + userId + ")";
            _connectionGui.ConnectionStatus.text = "New User Registered...";
        }

        /**
         * <summary>On Authentication, display auth details</summary>
         * <param name="name">Name</param>
         * <param name="userId">User Id</param>
         **/
        public void OnAuthentication(string name, string userId)
        {
            _connectionGui.UserId.text = name + " (" + userId + ")";
            _connectionGui.ConnectionStatus.text = "User Authenticated...";
        }
        
        private void OnGsAvailable(bool state)
        {
            var s = "GameSparks ";
            s += state ? "Connected..." : "Disconnected...";
            _connectionGui.ConnectionStatus.text = s;
        }
        
        private readonly ConnectionGui _connectionGui;
    }
}