using System;

namespace CodeBase.Data
{
    [Serializable]
    public class Vector4Data
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public Vector4Data(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
}