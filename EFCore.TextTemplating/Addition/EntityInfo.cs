namespace EFCore.TextTemplating.Addition
{
    using System;
    using System.Linq;
    using System.Text.Json;
    using System.Text.RegularExpressions;

    public static class EntityInfo
    {
        public static string Delimiter = "|*|";

        public static bool TryGetInfo<T>(ref string info, out T entityInfo)
        {
            if (string.IsNullOrEmpty(info))
            {
                entityInfo = default;
                return false;
            }

            var infos = info.Split(new[] { Delimiter }, StringSplitOptions.RemoveEmptyEntries);
            var type = typeof(T);

            var regexInfo = new Regex($"^{type.Name}\\s*[:：]\\s*(\\{{.*\\}})$");
            var firstInfo = infos.Select((item, index) => (index, regexInfo.Match(item.Trim()))).FirstOrDefault(item => item.Item2.Success);
            if (firstInfo == default)
            {
                entityInfo = default;
                return false;
            }

            try
            {
                entityInfo = JsonSerializer.Deserialize<T>(firstInfo.Item2.Groups[1].Value);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(info, exception);
            }

            var regexBlank = new Regex("^\\s+|\\s+$");
            info = string.Join(Delimiter,
                infos.Select((item, index) => (item, index)).Where(item => item.index != firstInfo.index)
                    .Select(item => regexBlank.Replace(item.item, string.Empty)).Where(item => !string.IsNullOrEmpty(item)));
            return true;
        }
    }
}
