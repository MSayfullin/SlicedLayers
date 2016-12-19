namespace dokas.SlicedLayers
{
    using System;

    public class Materializer<Tin, Tout>
    {
        private Action<Tin, Tout> _materializer;

        public void Init<K>(Action<Tin, K> setter, Func<Tout, K> getter)
        {
            _materializer = (obj, reader) => setter(obj, getter(reader));
        }

        public void Run(Tin obj, Tout reader)
        {
            _materializer.Invoke(obj, reader);
        }
    }
}