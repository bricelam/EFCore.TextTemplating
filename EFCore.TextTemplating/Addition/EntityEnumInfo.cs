namespace EFCore.TextTemplating.Addition
{
    using System;

    /// <example>
    /// {"Name":"EnumWordType","Comment":"EnumWordType Comment","HasFlags":false,"Values":[{"Name":"Single","Value":0,"Comment":"Single Comment"},{"Name":"Group","Comment":"Group Comment"}]}
    /// </example>
    [Serializable]
    public class EntityEnumInfo : IEquatable<EntityEnumInfo>
    {
        public string Name { get; set; }

        public string UsingNamespace { get; set; }

        public bool HasFlags { get; set; }

        public EntityEnumValueInfo[] Values { get; set; }

        public string Comment { get; set; }

        //public EntityAttributeInfo[] Attributes { get; set; }
        public bool Equals(EntityEnumInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EntityEnumInfo)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}