namespace dokas.SlicedLayers
{
    using System;

    public class ColumnInfo<T>
    {
        public string ColumnName { get; set; }

        private object _getter;

        public void SetGetter<K>(Func<T, K> getter)
        {
            _getter = getter;
        }

        public Func<T, K> GetGetter<K>()
        {
            return (Func<T, K>)_getter;
        }

        public K GetValue<K>(T dataProvider)
        {
            var func = (Func<T, K>)_getter;
            return func(dataProvider);
        }
    }
}