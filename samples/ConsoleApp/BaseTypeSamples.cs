using PlainBytes.System.Extensions.BaseTypes;

namespace ConsoleApp
{
    public class BaseTypeSamples
    {
        public void StringExamples()
        {
            const string stringValue = "some value";

            _ = stringValue.IsNullOrEmpty();
            _ = stringValue.IsNullOrWhiteSpace();

            _ = stringValue.HasValue();
            _ = stringValue.HasActualValue();

            _ = "{0} {1}".FormatWith(1, 2);
        }

        public void IntExamples()
        {
            const int intValue = 123;

            _ = intValue.Clamp(0, 100);
            _ = intValue.ToBool();

            const uint uintValue = 1234;

            _ = uintValue.Clamp(0, 100);
            _ = uintValue.ToBool();
        }

        public void LongExamples()
        {
            const long longValue = 123;

            _ = longValue.Clamp(0, 100);
            _ = longValue.ToBool();

            const ulong ulongValue = 1234;

            _ = ulongValue.Clamp(0, 100);
            _ = ulongValue.ToBool();
        }

        public void ByteExamples()
        {
            const byte byteValue = 12;

            _ = byteValue.Clamp(0, 100);
            _ = byteValue.ToBool();
        }
        
        public void DoubleExamples()
        {
            const double doubleValue = 12.34;

            _ = doubleValue.Clamp(0, 100);
            _ = doubleValue.IsInfinity();
            _ = doubleValue.IsNegativeInfinity();
            _ = doubleValue.IsPositiveInfinity();
            _ = doubleValue.IsNaN();
            _ = doubleValue.IsEqual(34.12, 0.1); // two NaNs are also evaluated as equals
        }
    }
}