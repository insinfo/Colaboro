using SQLite;

namespace Colaboro.Data
{
    public class KeyValuePair
    {
        [PrimaryKey]
        public string Key { get; set; } = "";
        public string Value { get; set; } = "";
    }
}