﻿using QQ.Framework;
using QQ.Framework.Utils;
using System;
using System.IO;
namespace Struggle.Framework.PCQQ.PCLogin.PCPacket.PCTLV
{
    internal class TLV_010B : BaseTLV
    {
        public TLV_010B()
        {
            this.cmd = 0x010B;
            this.Name = "TLV_QDLoginFlag";
            this.wSubVer = 0x0002;
        }

        public byte[] get_tlv_010B(QQClient m_PCClient)
        {
            //TODO:QdData
            throw new Exception("QdData 获取失败！");
            //  var data = new BinaryWriter(new MemoryStream());
            //if (this.wSubVer == 0x0002)
            //{
            //    data.BEWrite(this.wSubVer); //wSubVer
            //    data.Write(m_PCClient.QQUser.MD51);
            //    var newbyte =  m_PCClient.QQUser.TXProtocol.bufTGT;
            //    var flag = EncodeLoginFlag(newbyte, QQGlobal.QQEXE_MD5);
            //    data.Write(flag);
            //    data.Write(0x10);
            //    data.BEWrite(0);
            //    data.BEWrite(2);
            //    byte[] qddata = null;
            //    if (m_PCClient.m_LisHelper.GetQdData((uint) m_PCClient.QQUser.QQ, m_PCClient.dwServerIP,  m_PCClient.QQUser.TXProtocol.bufComputerIDEx, out qddata))
            //    {
            //        data.Write(qddata);
            //        data.BEWrite(0);
            //        data.BEWrite(0);
            //    }
            //    else
            //    {
            //        throw new Exception("QdData 获取失败！");
            //    }
            //}
            //else
            //{
            //    throw new Exception(string.Format("{0} 无法识别的版本号 {1}", this.Name, this.wSubVer));
            //}
            //fill_head(this.cmd);
            //fill_body(data.BaseStream.ToBytesArray(), data.BaseStream.Length);
            //set_length();
            //return get_buf();
        }

        private byte EncodeLoginFlag(byte[] bufTGT/*bufTGT*/, byte[] QQEXE_MD5/*QQEXE_MD5*/, byte flag = 0x01/*固定 0x01*/)
        {
            byte RC = flag;
            for (var i = 0; i < bufTGT.Length; i++)
            {
                RC ^= bufTGT[i];
            }
            byte RCC = 0x00;
            for (var i = 0; i < 4; i++)
            {
                RCC = QQEXE_MD5[i * 4];
                RCC ^= QQEXE_MD5[(i * 4) + 1];
                RCC ^= QQEXE_MD5[(i * 4) + 3];
                RCC ^= QQEXE_MD5[(i * 4) + 2];
                RC ^= RCC;
            }
            return RC;
        }
    }
}
