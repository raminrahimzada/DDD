using System;

namespace DDD.Infrastructure
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this byte value) where T:struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("Invalid Usage");
            }
            foreach (T enu in Enum.GetValues(typeof(T)))
            {
                if ((byte)(object)enu==value)
                {
                    return enu;
                }
            }
            return default(T);
        }
        public static T? ToEnum<T>(this byte? value) where T:struct
        {
            if (!value.HasValue) return null;

            if (!typeof(T).IsEnum)
            {
                throw new Exception("Invalid Usage");
            }

            foreach (T enu in Enum.GetValues(typeof(T)))
            {
                if ((byte)(object)enu==value)
                {
                    return enu;
                }
            }

            return null;
        }
    }
}