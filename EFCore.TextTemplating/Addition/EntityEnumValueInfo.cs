namespace EFCore.TextTemplating.Addition
{
    using System;

    [Serializable]
    public class EntityEnumValueInfo
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public string Comment { get; set; }
    }
}