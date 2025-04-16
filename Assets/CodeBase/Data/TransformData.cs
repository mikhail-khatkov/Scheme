using System;

namespace CodeBase.Data
{
    [Serializable]
    public class TransformData
    {
        public Vector3Data Position;
        public Vector4Data Rotation;
        public Vector3Data LocalScale;

        public TransformData(Vector3Data position, Vector4Data rotation, Vector3Data localScale)
        {
            Position = position;
            Rotation = rotation;
            LocalScale = localScale;
        }
    }
}