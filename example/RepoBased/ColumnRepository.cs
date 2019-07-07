namespace dokas.SlicedLayers.Example
{
    using System.Data;
    using System.Collections.Generic;

    public static class ColumnRepository
    {
        public static class Names
        {
            public const string Id = "column_id";
            public const string Name = "column_name";
            public const string CreatedAt = "created_at";
            public const string Price = "price";
        }

        private static Dictionary<string, ColumnInfo<IDataReader>> _columnInfos;

        static ColumnRepository()
        {
            _columnInfos = new Dictionary<string, ColumnInfo<IDataReader>>();

            var columnInfo = new ColumnInfo<IDataReader> { ColumnName = Names.Id };
            columnInfo.SetGetter(reader => reader.GetInt32(1));
            _columnInfos.Add(columnInfo.ColumnName, columnInfo);

            columnInfo = new ColumnInfo<IDataReader> { ColumnName = Names.Name };
            columnInfo.SetGetter(reader => reader.GetString(2));
            _columnInfos.Add(columnInfo.ColumnName, columnInfo);

            columnInfo = new ColumnInfo<IDataReader> { ColumnName = Names.CreatedAt };
            columnInfo.SetGetter(reader => reader.GetDateTime(3));
            _columnInfos.Add(columnInfo.ColumnName, columnInfo);

            columnInfo = new ColumnInfo<IDataReader> { ColumnName = Names.Price };
            columnInfo.SetGetter(reader => reader.GetDecimal(4));
            _columnInfos.Add(columnInfo.ColumnName, columnInfo);
        }

        public static ColumnInfo<IDataReader> GetByName(string columnName)
        {
            return _columnInfos[columnName];
        }
    }
}