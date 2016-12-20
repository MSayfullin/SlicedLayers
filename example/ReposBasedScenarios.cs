namespace dokas.SlicedLayers.Example
{
    using Xunit;
    using System;
    using System.Data;
    using System.Collections.Generic;

    public class ReposBasedScenarios
    {
        [Fact]
        public void DynamicLoadFromDb()
        {
            // Load provided Model properties from DB

            var propertiesToLoad = new [] { nameof(Model.IntProperty), nameof(Model.DateTimeProperty) };

            var intValue = 1;
            var dateTimeValue = DateTime.Now;

            var model = new Model();
            var dataReaderMock = new DataReaderMock(intValue, dateTimeValue);
            var mapping = GetMapping();
            foreach (var propertyName in propertiesToLoad)
            {
                var materializer = mapping[propertyName];
                materializer.Run(model, dataReaderMock);
            }

            Assert.Equal(intValue, model.IntProperty);
            Assert.Null(model.StringProperty);
            Assert.Equal(dateTimeValue, model.DateTimeProperty);
            Assert.Equal(0.0m, model.DecimalProperty);
        }

        [Fact]
        public void StaticLoadFromDb()
        {
            // Load all Model properties set in mapping from DB

            var intValue = 1;
            var stringValue = "test";
            var dateTimeValue = DateTime.Now;
            var decimalValue = 0.02m;

            var model = new Model();
            var dataReaderMock = new DataReaderMock(intValue, stringValue, dateTimeValue, decimalValue);
            var materializers = GetMapping().Values;
            foreach (var materializer in materializers)
            {
                materializer.Run(model, dataReaderMock);
            }

            Assert.Equal(intValue, model.IntProperty);
            Assert.Equal(stringValue, model.StringProperty);
            Assert.Equal(dateTimeValue, model.DateTimeProperty);
            Assert.Equal(decimalValue, model.DecimalProperty);
        }

        private Dictionary<string, Materializer<Model, IDataReader>> GetMapping()
        {
            // Mapping based on repositories
            var mapping = new Dictionary<string, Materializer<Model, IDataReader>>();

            var materializer = new Materializer<Model, IDataReader>();
            materializer.Init(
                ModelProperties.GetByName(nameof(Model.IntProperty)).GetSetter<int>(),
                ColumnRepository.GetByName(ColumnRepository.Names.Id).GetGetter<int>());
            mapping.Add(nameof(Model.IntProperty), materializer);

            materializer = new Materializer<Model, IDataReader>();
            materializer.Init(
                ModelProperties.GetByName(nameof(Model.StringProperty)).GetSetter<string>(),
                ColumnRepository.GetByName(ColumnRepository.Names.Name).GetGetter<string>());
            mapping.Add(nameof(Model.StringProperty), materializer);

            materializer = new Materializer<Model, IDataReader>();
            materializer.Init(
                ModelProperties.GetByName(nameof(Model.DateTimeProperty)).GetSetter<DateTime>(),
                ColumnRepository.GetByName(ColumnRepository.Names.CreatedAt).GetGetter<DateTime>());
            mapping.Add(nameof(Model.DateTimeProperty), materializer);

            materializer = new Materializer<Model, IDataReader>();
            materializer.Init(
                ModelProperties.GetByName(nameof(Model.DecimalProperty)).GetSetter<decimal>(),
                ColumnRepository.GetByName(ColumnRepository.Names.Price).GetGetter<decimal>());
            mapping.Add(nameof(Model.DecimalProperty), materializer);

            return mapping;
        }
    }
}