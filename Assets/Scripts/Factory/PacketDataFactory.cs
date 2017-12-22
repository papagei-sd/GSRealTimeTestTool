﻿using System;
using GameSparks.RT;

namespace Services
{
    public static class PacketDataFactory
    {
        /**
         * <summary>Returns Empty Packet Data<summary>
         **/
        public static RTData GetEmpty()
        {
            var data = new RTData();
            data.SetInt(1, 1); // Fixes WebGL build, can't send blank data.
            return data;
        }
        
        /**
         * <summary>Returns Timestamp Ping Packet Data</summary>
         * <param name="requestId">Request Id</param>
         **/
        public static RTData GetTimestampPing(int requestId)
        {
            var data = new RTData();
            data.SetInt(1, requestId);
            data.SetLong(2, DateTime.UtcNow.Ticks);
            return data;
        }

        /**
         * <summary>Returns Timestamp Pong Packet Data</summary>
         * <param name="requestId">Request Id</param>
         * <param name="pingTime">Ping time</param>
         **/
        public static RTData GetTimestampPong(int requestId, long pingTime)
        {
            var data = new RTData();
            data.SetInt(1, requestId);
            data.SetLong(2, pingTime);
            data.SetLong(3, DateTime.UtcNow.Ticks);
            return data;
        }
    }
}