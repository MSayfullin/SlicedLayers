namespace dokas.SlicedLayers
{
    using System;

    public class PropertyInfo<T>
    {
        public string PropertyName { get; set; }

        private object _setter;

        public void SetSetter<K>(Action<T, K> setter)
        {
            _setter = setter;
        }

        public Action<T, K> GetSetter<K>()
        {
            return (Action<T, K>)_setter;
        }

        public void ApplyValue<K>(T obj, K value)
        {
            var action = (Action<T, K>)_setter;
            action(obj, value);
        }
    }
}