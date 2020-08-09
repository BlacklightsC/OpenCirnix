using System;
using Cirnix.JassNative.Runtime.Utilities;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct AbilityLevelData
    {
        public IntPtr field0000;
        public float CastingTime;
        public float DurationNormal;
        public float DurationHero;
        public int ManaCost;
        public float Cooldown;
        public float AreaOfEffect;
        public float CastRange;
        public IntPtr DataA;
        public IntPtr DataB;
        public IntPtr DataC;
        public IntPtr DataD;
        public IntPtr DataE;
        public IntPtr DataF;
        public IntPtr DataG;
        public IntPtr DataH;
        public IntPtr DataI;
        public IntPtr field0044;
        public IntPtr field0048;
        public IntPtr field004C;
        public IntPtr field0050;
        public ObjectIdL BuffId;
        public IntPtr field0058;
        public IntPtr field005C;
        public IntPtr field0060;
        public IntPtr field0064;

        public unsafe AbilityLevelDataPtr AsSafe()
        {
            fixed (AbilityLevelData* pointer = &this)
                return new AbilityLevelDataPtr(pointer);
        }

        public unsafe IntPtr AsIntPtr()
        {
            fixed (AbilityLevelData* abilityLevelDataPtr = &this)
                return new IntPtr((void*)abilityLevelDataPtr);
        }

        public unsafe void SetDataA<T>(T data) where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataA)
                Memory.Write(new IntPtr((void*)numPtr), data);
        }

        public unsafe T GetDataA<T>() where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataA)
                return Memory.Read<T>(new IntPtr((void*)numPtr));
        }

        public unsafe void SetDataB<T>(T data) where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataB)
                Memory.Write(new IntPtr((void*)numPtr), data);
        }

        public unsafe T GetDataB<T>() where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataB)
                return Memory.Read<T>(new IntPtr((void*)numPtr));
        }

        public unsafe void SetDataC<T>(T data) where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataC)
                Memory.Write(new IntPtr((void*)numPtr), data);
        }

        public unsafe T GetDataC<T>() where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataC)
                return Memory.Read<T>(new IntPtr((void*)numPtr));
        }

        public unsafe void SetDataD<T>(T data) where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataD)
                Memory.Write(new IntPtr((void*)numPtr), data);
        }

        public unsafe T GetDataD<T>() where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataD)
                return Memory.Read<T>(new IntPtr((void*)numPtr));
        }

        public unsafe void SetDataE<T>(T data) where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataE)
                Memory.Write(new IntPtr((void*)numPtr), data);
        }

        public unsafe T GetDataE<T>() where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataE)
                return Memory.Read<T>(new IntPtr((void*)numPtr));
        }

        public unsafe void SetDataF<T>(T data) where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataF)
                Memory.Write(new IntPtr((void*)numPtr), data);
        }

        public unsafe T GetDataF<T>() where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataF)
                return Memory.Read<T>(new IntPtr((void*)numPtr));
        }

        public unsafe void SetDataG<T>(T data) where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataG)
                Memory.Write(new IntPtr((void*)numPtr), data);
        }

        public unsafe T GetDataG<T>() where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataG)
                return Memory.Read<T>(new IntPtr((void*)numPtr));
        }

        public unsafe void SetDataH<T>(T data) where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataH)
                Memory.Write(new IntPtr((void*)numPtr), data);
        }

        public unsafe T GetDataH<T>() where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataH)
                return Memory.Read<T>(new IntPtr((void*)numPtr));
        }

        public unsafe void SetDataI<T>(T data) where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataI)
                Memory.Write(new IntPtr((void*)numPtr), data);
        }

        public unsafe T GetDataI<T>() where T : struct
        {
            if (typeof(T) == typeof(string))
                throw new ArgumentException("T cannot be String", "<T>");
            fixed (IntPtr* numPtr = &DataI)
                return Memory.Read<T>(new IntPtr((void*)numPtr));
        }
    }
}