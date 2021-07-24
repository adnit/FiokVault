﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FiokVaultServer
{
    class FiokVaultServerEncrypt
    {
        public byte[] Key;
        public int IVLength = 8;
        public FiokVaultServerEncrypt(byte[] Key)
        {
            this.Key = Key;
        }

        public byte[] encryptMessage(string data)
        {

            byte[] dataToEncrypt = Convert.FromBase64String(data);
            byte[] IV = new byte[IVLength];
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            provider.GetBytes(IV);

            FiokVaultDES des = new FiokVaultDES(this.Key);

            byte[] encryptedMessage = des.Encrypt(Convert.ToBase64String(dataToEncrypt));
            byte[] encryptedMessageArray = encryptedMessage;

            byte[] toBase64 = new byte[IVLength + encryptedMessage.Length];




            string IVstr = Convert.ToBase64String(IV);
            string encMsg = Convert.ToBase64String(encryptedMessageArray);
            string cipherTxt = IVstr + "//+//" + encMsg;

            byte[] cipherText = Convert.FromBase64String(cipherTxt);

            return cipherText;
        }
    }
}
