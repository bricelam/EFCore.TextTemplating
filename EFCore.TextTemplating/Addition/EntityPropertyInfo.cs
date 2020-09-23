namespace EFCore.TextTemplating.Addition
{
    using System;

    /// <example>
    /// this is Property1 comment. |*| EntityPropertyInfo:{"Enum":{"Name":"EnumStatus.Value","UsingNamespace":"Model.Table.CommonEnum"},"Attributes":[{"Code":"JsonIgnore","UsingNamespace":"Newtonsoft.Json"}]}
    /// </example>
    /// <example>
    /// EntityPropertyInfo: {"Enum":{"Name":"EnumWordType","Comment":"EnumWordType Comment","Values":[{"Name":"Single","Value":0,"Comment":"Single Comment"},{"Name":"Group","Comment":"Group Comment"}]}}
    /// |*|
    /// this is Property2 comment.
    /// </example>
    [Serializable]
    public class EntityPropertyInfo
    {
        public EntityEnumInfo Enum { get; set; }

        public EntityAttributeInfo[] Attributes { get; set; }

        public static bool TryGetInfo(ref string info, out EntityPropertyInfo entityPropertyInfo)
        {
            return EntityInfo.TryGetInfo(ref info, out entityPropertyInfo);
        }
    }
}