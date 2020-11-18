namespace Game.Common.Data.Serializer
{
    public interface IObjectBinarySerializer
    {
        byte[] ToObject(string input);
        string ToString(byte[] input);
    }
}