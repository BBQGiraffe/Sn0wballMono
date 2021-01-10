using System;
using ZeroFormatter;
using ZeroFormatter.Formatters;

namespace Sn0wballEngine.serializer
{
    public class SNVector2fFormatter<TTypeResolver> : Formatter<TTypeResolver, SNVector2f>
    where TTypeResolver : ITypeResolver, new()
    {
        public SNVector2fFormatter()
        {
        }

        public override int? GetLength()
        {
            // If size is variable, return null.
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, SNVector2f value)
        {
            var x = Formatter<TTypeResolver, float>.Default.Serialize(ref bytes, offset, value.x);
            var y = Formatter<TTypeResolver, float>.Default.Serialize(ref bytes, offset, value.y);
            return x + y;
        }

        public override SNVector2f Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            var x = Formatter<TTypeResolver, float>.Default.Deserialize(ref bytes, offset, tracker, out byteSize);
            var y = Formatter<TTypeResolver, float>.Default.Deserialize(ref bytes, offset, tracker, out byteSize);
            return new SNVector2f(x, y);
        
        }
    }
}
