using Contingency_079.Handlers;
using Exiled.API.Features;
using Map = Exiled.Events.Handlers.Map;

namespace Contingency_079;
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