using EXILED;
using System.Collections.Generic;
using UnityEngine;

namespace LightOFF
{
    public class LightOFF : Plugin
    {
        public override string getName { get; } = "LightOFF";

        List<FlickerableLight> Rooms = new List<FlickerableLight>();

        public override void OnEnable()
        {
            Events.WaitingForPlayersEvent += OnWaitingForPlayers;
            Events.RemoteAdminCommandEvent += OnRACommand;
        }

        public override void OnDisable()
        {

        }

        public override void OnReload()
        {

        }

        void OnWaitingForPlayers() 
        {
            FlickerableLight[] rooms = GameObject.FindObjectsOfType<FlickerableLight>();

            Rooms = new List<FlickerableLight>(rooms);
        }

        void OnRACommand(ref RACommandEvent ev) 
        {
            string[] args = ev.Command.ToUpper().Split(' ');

            if (args[0] != null)
            {
                switch (args[0])
                {
                    case "LIGHTOFF":
                        if (args[1] != null)
                        {
                            float time = float.Parse(args[1]);

                            for (int i = 0; i < Rooms.Count; i++)
                            {
                                Rooms[i].EnableFlickering(time);
                            }
                        }
                        break;
                }
            }
        }
    }
}
