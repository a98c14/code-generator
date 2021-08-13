﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace KeyGenerator
{
    public class Program
    {

        private const string Digits = "ACDEFGHKLMNPRTXYZ234579";
        private const string PrivateKey = "-KaPdSgVkXp2s5v8y/B?E(H+MbQeThWmZq3t6w9z$C&F)J@NcRfUjXn2r5u7x!A%D*G-KaPdSgVkYp3s6v9y/B?E(H+MbQeThWmZq4t7w!z%C&F)J@NcRfUjXn2r5u8x";

        /// <summary>
        /// How many code will be generated
        /// </summary>
        private const int CodeCount = 10000;

        /// <summary>
        /// Code length in bytes. It is actually 3 Last 4 bits will be shifted
        /// </summary>
        private const int CodeLength = 40;

        /// <summary>
        /// Seed length in bits
        /// </summary>
        private const int SeedLength = 24;


        static void Main(string[] args)
        {   
            var keyEngine = new KeyEngine(PrivateKey, Digits, CodeLength, SeedLength);
            var keys = keyEngine.GenerateKeys(CodeCount);
            var isValid = keyEngine.ValidateKey(keys[0]);
        }
    }
}
