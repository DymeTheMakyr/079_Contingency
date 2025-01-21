using Exiled.API.Features;

namespace _079_Contingency;

public class PluginCore : Plugin<Config> {
    public PluginCore Instance;

    public override void OnEnabled() {
        Instance = new PluginCore();
        RegisterEvents();
        
        base.OnEnabled();
    }

    public override void OnDisabled() {
        UnregisterEvents();
        Instance = null;
        
        base.OnDisabled();
    }

    void RegisterEvents() {
        
    }

    void UnregisterEvents() {
        
    }
}