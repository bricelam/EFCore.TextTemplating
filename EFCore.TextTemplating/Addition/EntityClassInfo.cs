namespace EFCore.TextTemplating.Addition
{
    using System;

    [Serializable]
    public class EntityClassInfo
    {
        public string Name { get; set; }

        public string ClassName { get; set; }

        public string[] UsingNamespaces { get; set; }

        //public EntityAttributeInfo[] Attributes { get; set; }

        public static bool TryGetInfo(ref string info, out EntityClassInfo entityPropertyInfo)
        {
            return EntityInfo.TryGetInfo(ref info, out entityPropertyInfo);
        }
    }
}
