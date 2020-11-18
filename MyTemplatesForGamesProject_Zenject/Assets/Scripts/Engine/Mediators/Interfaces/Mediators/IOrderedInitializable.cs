namespace Engine.Mediators
{
    public interface IOrderedInitializable : IInitializable
    {
        EInitializationOrder InitializationOrder { get; }
    }
}