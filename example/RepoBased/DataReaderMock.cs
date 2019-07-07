namespace dokas.SlicedLayers.Example
{
    using System;
    using System.Data;

    public class DataReaderMock : IDataReader
    {
        private readonly int? _intValue;
        private readonly string _stringValue;
        private readonly DateTime? _dateTimeValue;
        private readonly decimal? _decimalValue;

        public DataReaderMock(int intValue, DateTime dateTimeValue)
        {
            _intValue = intValue;
            _dateTimeValue = dateTimeValue;
        }

        public DataReaderMock(int intValue, string stringValue, DateTime dateTimeValue, decimal decimalValue)
        {
            _intValue = intValue;
            _stringValue = stringValue;
            _dateTimeValue = dateTimeValue;
            _decimalValue = decimalValue;
        }

        public object this[string name]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object this[int i]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Depth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int FieldCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsClosed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int RecordsAffected
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            if (_dateTimeValue == null)
            {
                throw new ArgumentNullException("DateTimeValue", "DateTime value should be set on DataReaderMock construction");
            }
            return _dateTimeValue.Value;
        }

        public decimal GetDecimal(int i)
        {
            if (_decimalValue == null)
            {
                throw new ArgumentNullException("DecimalValue", "Decimal value should be set on DataReaderMock construction");
            }
            return _decimalValue.Value;
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            if (_intValue == null)
            {
                throw new ArgumentNullException("IntValue", "Int value should be set on DataReaderMock construction");
            }
            return _intValue.Value;
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            if (_stringValue == null)
            {
                throw new ArgumentNullException("StringValue", "String value should be set on DataReaderMock construction");
            }
            return _stringValue;
        }

        public object GetValue(int i)
        {
            throw new NotImplementedException();
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }
    }
}