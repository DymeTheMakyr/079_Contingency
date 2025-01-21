using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.Events.EventArgs.Map;
using PlayerRoles;

namespace _079_Contingency.Handlers;

public class MapHandler {
    public void OnAnnouncingScpTermination(AnnouncingScpTerminationEventArgs ev) {
        Player[] scps = Player.Get(Team.SCPs).ToArray();
        if (scps.Length > 1) return;
        if (scps[0].Role != RoleTypeId.Scp079) return;
        Cassie.Message(".g6 SCP 0 7 9 has initiated Big Red Surprise Protocol. All personnel be on high alert Bell_Start", false, true, true);
        switch (Warhead.IsDetonated) {
            case false:
                scps[0].Role.Set(RoleTypeId.Scp939, RoleSpawnFlags.All);
                break;
            case true:
                scps[0].Role.Set(RoleTypeId.Scp939, RoleSpawnFlags.AssignInventory);
                scps[0].Teleport(Door.Get(DoorType.EscapeFinal));
                break;
        }
    }
}