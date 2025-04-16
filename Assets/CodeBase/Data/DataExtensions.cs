using UnityEngine;

namespace CodeBase.Data
{
  public static class DataExtensions
  {
    public static string ToJson(this object obj) => 
      JsonUtility.ToJson(obj);

    public static T ToDeserialized<T>(this string json) =>
      JsonUtility.FromJson<T>(json);

    public static Vector4Data AsVectorData(this Quaternion quaternion) =>
      new Vector4Data(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
    
    public static Vector3Data AsVectorData(this Vector3 vector) =>
      new Vector3Data(vector.x, vector.y, vector.z);
    
    public static Vector3 AsUnityVector(this Vector3Data vector) =>
      new Vector3(vector.X, vector.Y, vector.Z);
    
    public static Quaternion AsUnityQuaternion(this Vector4Data vector) =>
      new Quaternion(vector.X, vector.Y, vector.Z, vector.W);

    public static TransformData AsTransformData(this Transform transform) =>
      new TransformData(transform.position.AsVectorData(), transform.rotation.AsVectorData(), transform.localScale.AsVectorData());
  }
}