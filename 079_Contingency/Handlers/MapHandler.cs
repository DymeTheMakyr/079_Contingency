using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.Events.EventArgs.Map;
using PlayerRoles;
using MEC;
using UnityEngine;

namespace Contingency_079.Handlers;

public class MapHandler {
    public void OnAnnouncingScpTermination(AnnouncingScpTerminationEventArgs ev) {
        Player[] scps = Player.Get(Team.SCPs).ToArray();
        if (scps.Length > 1) return;
        if (scps[0].Role != RoleTypeId.Scp079) return;
        Timing.CallDelayed(5f, () => {
            Cassie.MessageTranslated("SCP - 0 7 9 has initiated pitch_0.9 Big Red Surprise pitch_1.00 Protocol. All personnel be on high alert.", "SCP-079 has initiated Big Red Surprise pitch_1.00 Protocol. All personnel be on high alert.",  false, true, true);
            switch (Warhead.IsDetonated) {
                case false:
                    scps[0].Role.Set(RoleTypeId.Scp939, RoleSpawnFlags.All);
                    break;
                case true:
                    Door d = Door.Get(DoorType.EscapeFinal);
                    scps[0].Role.Set(RoleTypeId.Scp939, RoleSpawnFlags.AssignInventory);
                    scps[0].Teleport(d);
                    d.Unlock();
                    break;
            }
        });
    }
}