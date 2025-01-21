using _079_Contingency.Handlers;
using Exiled.API.Features;
using Map = Exiled.Events.Handlers.Map;

namespace _079_Contingency;
public class PluginCore : Plugin<Config> {
    public PluginCore Instance;

    public MapHandler mapHandler;
    
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
        mapHandler = new();
        Map.AnnouncingScpTermination += mapHandler.OnAnnouncingScpTermination;
    }

    void UnregisterEvents() {
        Map.AnnouncingScpTermination -= mapHandler.OnAnnouncingScpTermination;
        mapHandler = null;
    }
}