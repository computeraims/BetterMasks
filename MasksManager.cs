using Announcer;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BetterMasks
{
    public class MasksManager : MonoBehaviour
    {
        public void Update()
        {
            foreach (SteamPlayer player in Provider.clients)
            {
                RaycastInfo thingLocated = TraceRay(player, 10f, RayMasks.PLAYER | RayMasks.PLAYER_INTERACT);

                if (thingLocated.player != null)
                {
                    if (thingLocated.player.name == player.player.name)
                    {
                        return;
                    }

                    //Console.WriteLine(thingLocated.player.clothing.mask);
                    //Console.WriteLine(thingLocated.player.name);

                    if (thingLocated.player.clothing.mask != 0)
                    {
                        //Console.WriteLine(player.player.isPluginWidgetFlagActive(EPluginWidgetFlags.ShowInteractWithEnemy));
                        if (player.player.isPluginWidgetFlagActive(EPluginWidgetFlags.ShowInteractWithEnemy))
                        {
                            if (player.isAdmin && Main.Config.adminOverride == true)
                            {
                                return;
                            }

                            player.player.disablePluginWidgetFlag(EPluginWidgetFlags.ShowInteractWithEnemy);
                        }
                    }
                    else
                    {
                        //Console.WriteLine(player.player.isPluginWidgetFlagActive(EPluginWidgetFlags.ShowInteractWithEnemy));
                        if (!player.player.isPluginWidgetFlagActive(EPluginWidgetFlags.ShowInteractWithEnemy))
                        {
                            player.player.enablePluginWidgetFlag(EPluginWidgetFlags.ShowInteractWithEnemy);
                        }
                    }
                }
            }
        }

        public RaycastInfo TraceRay(SteamPlayer player, float distance, int masks)
        {
            return DamageTool.raycast(new Ray(player.player.look.aim.position, player.player.look.aim.forward), distance, masks);
        }
    }
}