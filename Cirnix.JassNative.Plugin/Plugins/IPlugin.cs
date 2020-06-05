namespace Cirnix.JassNative.Plugin
{
    public interface IPlugin : IMapPlugin
    {
        void Initialize();

        void OnGameLoad();
    }
}
