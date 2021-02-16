using System;

namespace NullableTypesTask
{
    public static class NullableTypeExtensions
    {
        /// <summary>
        /// Implement for nullable types the additional possibility of determining whether
        /// the nullable variable is null or not.
        /// </summary>
        /// <param name="variable">Input variable.</param>
        /// <returns>true if variable is null, false otherwise.</returns>
        public static bool IsNull(this object variable)
        {
            if (variable == null)
            {
                return true;
            }

            return false;
        }
    }
}
