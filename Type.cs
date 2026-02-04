using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace $rootnamespace$
{
    [JsonConverter(typeof(SelfEnumConverter<$safeitemname$>))]
    public readonly record struct $safeitemname$ : IParsable<$safeitemname$>
    {
        // Os enums
        public const string Exemplo = "exemplo";

        public static readonly FrozenSet<string> ValidTypes = new[]
        {
            Exemplo
        }.ToFrozenSet();

        public string Value { get; } = string.Empty;

        private $safeitemname$(string value)
        {
            if (!ValidTypes.Contains(value))
                throw new ArgumentException($"your_message: [{value}]. your_message: [{Descriptions}]");

            Value = value.Trim();
        }

        public static implicit operator string($safeitemname$ tipo) => tipo.Value;
        public static implicit operator $safeitemname$(string value) => new(value);

        public static readonly string Descriptions = string.Join(", ", ValidTypes);

        public static bool Is(string s) => ValidTypes.Contains(s);

        public static $safeitemname$ Parse(string s, IFormatProvider? provider) => new(s);

        public static bool TryParse([NotNullWhen(true)] string? s, 
            IFormatProvider? provider, 
            [MaybeNullWhen(false)] out $safeitemname$ result)
        {
            if (s != null && ValidTypes.Contains(s))
            {
                result = new $safeitemname$(s);
                return true;
            }
            
            result = default;
            
            return false;
        }
    }
}