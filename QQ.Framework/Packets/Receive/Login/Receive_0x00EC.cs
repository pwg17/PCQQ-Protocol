﻿using QQ.Framework.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQ.Framework.Packets.Receive.Login
{
    /// <summary>
    /// 改变在线状态
    /// </summary>
    public class Receive_0x00EC : ReceivePacket
    {
        /// <summary>
        /// 改变在线状态
        /// </summary>
        public Receive_0x00EC(byte[] byteBuffer, QQUser User)
            : base(byteBuffer, User, User.QQ_SessionKey)
        {
        }

        protected override void ParseBody()
        {
            Decrypt(user.QQ_SessionKey);
        }
    }
}