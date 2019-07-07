namespace dokas.SlicedLayers.Example
{
    using System;
    using System.Collections.Generic;

    public static class ModelProperties
    {
        private static Dictionary<string, PropertyInfo<Model>> _propertyInfos;

        static ModelProperties()
        {
            _propertyInfos = new Dictionary<string, PropertyInfo<Model>>();

            var propertyInfo = new PropertyInfo<Model> { PropertyName = nameof(Model.IntProperty) };
            propertyInfo.SetSetter<int>((model, val) => model.IntProperty = val);
            _propertyInfos.Add(propertyInfo.PropertyName, propertyInfo);

            propertyInfo = new PropertyInfo<Model> { PropertyName = nameof(Model.StringProperty) };
            propertyInfo.SetSetter<string>((model, val) => model.StringProperty = val);
            _propertyInfos.Add(propertyInfo.PropertyName, propertyInfo);

            propertyInfo = new PropertyInfo<Model> { PropertyName = nameof(Model.DateTimeProperty) };
            propertyInfo.SetSetter<DateTime>((model, val) => model.DateTimeProperty = val);
            _propertyInfos.Add(propertyInfo.PropertyName, propertyInfo);

            propertyInfo = new PropertyInfo<Model> { PropertyName = nameof(Model.DecimalProperty) };
            propertyInfo.SetSetter<decimal>((model, val) => model.DecimalProperty = val);
            _propertyInfos.Add(propertyInfo.PropertyName, propertyInfo);
        }

        public static PropertyInfo<Model> GetByName(string propertyName)
        {
            return _propertyInfos[propertyName];
        }
    }
}