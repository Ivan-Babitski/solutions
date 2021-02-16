namespace CreatingMethods
{
    public static class MethodsWithRefParameters
    {
        public static bool ReturnParameterValueAndSetParameterToDefaultValue(ref bool boolValue)
        {
            bool value = boolValue;
            boolValue = default(bool);
            return value;
        }

        public static char ReturnParameterValueAndSetParameterToDefaultValue(ref char charValue)
        {
            char temp = charValue;
            charValue = default;
            return temp;
        }

        public static float ReturnParameterValueAndSetParameterToDefaultValue(ref float floatValue)
        {
            float temp = floatValue;
            floatValue = default;
            return temp;
        }

        public static int ReturnParameterValueAndSetParameterToDefaultValue(ref int intValue)
        {
            int temp = intValue;
            intValue = default;
            return temp;
        }

        public static long ReturnParameterValueAndSetParameterToDefaultValue(ref long longValue)
        {
            long temp = longValue;
            longValue = default;
            return temp;
        }
    }
}
