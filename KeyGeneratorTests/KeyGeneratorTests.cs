using KeyGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace KeyGeneratorTests
{
    public class KeyGeneratorTests
    {
        private const string PrivateKey = "-KaPdSgVkXp2s5v8y/B?E(H+MbQeThWmZq3t6w9z$C&F)J@NcRfUjXn2r5u7x!A%D*G-KaPdSgVkYp3s6v9y/B?E(H+MbQeThWmZq4t7w!z%C&F)J@NcRfUjXn2r5u8x";
        private const string Digits = "ACDEFGHKLMNPRTXYZ234579";
        private const int CodeLength = 40;
        private const int SeedLength = 24;

        [Fact(Skip = "Takes too long")]
        public void GenerateSeedsSecureReturnsUniqueSeeds()
        {
            var keyEngine = new KeyEngine(PrivateKey, Digits, CodeLength, SeedLength);
            var seeds = keyEngine.GenerateSeedsSecure(10000000, 12);
            var set = new HashSet<string>();
            for (int i = 0; i < 10000000 * 12; i+= 12)
            {
                var hash = Convert.ToBase64String(seeds, i, 12);
                set.Add(hash);
            }
            Assert.Equal(10000000, set.Count);
        }

        [Fact(Skip = "Takes too long")]
        public void GenerateSeedsReturnsUniqueSeeds()
        {
            var keyEngine = new KeyEngine(PrivateKey, Digits, CodeLength, SeedLength);
            var seeds = keyEngine .GenerateSeeds(10000000, 12);
            var set = new HashSet<string>();
            for (int i = 0; i < 10000000 * 12; i += 12)
            {
                var hash = Convert.ToBase64String(seeds, i, 12);
                var r = set.Add(hash);
                
            }
            Assert.Equal(10000000, set.Count);
        }

        [Fact(Skip = "Takes too long")]
        public void GeneratePossibleSeedsReturnsUniqueSeeds()
        {
            var keyEngine = new KeyEngine(PrivateKey, Digits, CodeLength, SeedLength);
            var seeds = keyEngine.GenerateSeeds3Byte(10000000);
            var set = new HashSet<uint>();
            for (int i = 0; i < 10000000; i++)
                set.Add(seeds[i]);
            Assert.Equal(10000000, set.Count);
        }

        [Fact]
        public void GeneratedKeysAreValid()
        {
            var keyEngine = new KeyEngine(PrivateKey, Digits, CodeLength, SeedLength);
            var keys = keyEngine.GenerateKeys(10000000);
            for(int i = 0; i < keys.Count; i++)
                Assert.True(keyEngine.ValidateKey(keys[i]));
        }

        [Theory]
        [InlineData("ABCD-EMBD")]
        [InlineData("S23N-RBDJ")]
        public void ValidateKeysReturnsFalseForInvalidKeys(string value)
        {
            var keyEngine = new KeyEngine(PrivateKey, Digits, CodeLength, SeedLength);
            Assert.False(keyEngine.ValidateKey(value));
        }

        [Fact]
        public void ValidateKeysReturnsFalseForRandomlyGeneratedValues()
        {
            var random = new Random();
            var keyEngine = new KeyEngine(PrivateKey, Digits, CodeLength, SeedLength);
            var failedValidations = 0;
            for(int i = 0; i < 10000000; i++)
            {
                var key = "";
                for(int j = 0; j < 8; j++)
                    key += Digits[random.Next(0, Digits.Length)].ToString();
                var res = keyEngine.ValidateKey(key);
                if(res)
                    failedValidations++;
            }
            Assert.True(failedValidations < 10);
        }
    }
}
