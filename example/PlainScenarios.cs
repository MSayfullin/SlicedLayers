namespace dokas.SlicedLayers.Example
{
    using Xunit;
    using System;
    using System.Data;
    using System.Collections.Generic;

    public class PlainScenarios
    {
        [Fact]
        public void LoadFromDb()
        {
            // Simple scenario with mapping created from materializers only

            var intValue = 1;
            var stringValue = "test";
            var dateTimeValue = DateTime.Now;
            var decimalValue = 0.02m;

            var model = new Model();
            var dataReaderMock = new DataReaderMock(intValue, stringValue, dateTimeValue, decimalValue);
            foreach (var materializer in GetMaterializers())
            {
                materializer.Run(model, dataReaderMock);
            }

            Assert.Equal(intValue, model.IntProperty);
            Assert.Equal(stringValue, model.StringProperty);
            Assert.Equal(dateTimeValue, model.DateTimeProperty);
            Assert.Equal(decimalValue, model.DecimalProperty);
        }

        private List<Materializer<Model, IDataReader>> GetMaterializers()
        {
            // Mapping based on Column repository and plain setters and getters
            var materializers = new List<Materializer<Model, IDataReader>>();

            var materializer = new Materializer<Model, IDataReader>();
            materializer.Init(
                (model, val) => model.IntProperty = val,
                reader => reader.GetInt32(1));
            materializers.Add(materializer);

            materializer = new Materializer<Model, IDataReader>();
            materializer.Init(
                (model, val) => model.StringProperty = val,
                reader => reader.GetString(2));
            materializers.Add(materializer);

            materializer = new Materializer<Model, IDataReader>();
            materializer.Init(
                (model, val) => model.DateTimeProperty = val,
                reader => reader.GetDateTime(3));
            materializers.Add(materializer);

            materializer = new Materializer<Model, IDataReader>();
            materializer.Init(
                (model, val) => model.DecimalProperty = val,
                reader => reader.GetDecimal(4));
            materializers.Add(materializer);

            return materializers;
        }
    }
}