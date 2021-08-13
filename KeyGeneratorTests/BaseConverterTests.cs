using KeyGenerator;
using Xunit;

namespace KeyGeneratorTests
{
    public class BaseConverterTests
    {
        private const string Custom = "ACDEFGHKLMNPRTXYZ234579";
        private const string Hex = "0123456789ABCDEF";
        private const string Decimal = "0123456789";


        [Fact]
        public void ConverterReturnsCorrectValues()
        {
            var hexConverter = new BaseConverter(Hex);
            Assert.Equal("0", hexConverter.Convert(0));
            Assert.Equal("F", hexConverter.Convert(15));
            Assert.Equal("FF", hexConverter.Convert(255));

            var decimalConverter = new BaseConverter(Decimal);
            Assert.Equal("0", decimalConverter.Convert(0));
            Assert.Equal("15", decimalConverter.Convert(15));
            Assert.Equal("255", decimalConverter.Convert(255));
            Assert.Equal("130", decimalConverter.Convert(130));
            Assert.Equal("30000", decimalConverter.Convert(30000));

            var customConverter = new BaseConverter(Custom);
            Assert.Equal("A", customConverter.Convert(0));
            Assert.Equal("Y", customConverter.Convert(15));
            Assert.Equal("99999999", customConverter.Convert(78310985280));
            
        }

        [Theory]
        [InlineData(0)]
        [InlineData(15)]
        [InlineData(255)]
        [InlineData(30000)]
        [InlineData(123123123)]
        public void ConverterConvertsBackReturnsCorrectValues(long number)
        {
            var hexConverter = new BaseConverter(Hex);
            var hexValue = hexConverter.Convert(number);
            Assert.Equal(number, hexConverter.Convert(hexValue));

            var decimalConverter = new BaseConverter(Decimal);
            var decimalValue = decimalConverter.Convert(number);
            Assert.Equal(number, decimalConverter.Convert(decimalValue));

            var customConverter = new BaseConverter(Custom);
            var customValue = customConverter.Convert(number);
            Assert.Equal(number, customConverter.Convert(customValue));
        }
    }
}
