﻿using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using Settings = Nunu.Config.Modes.Harass;

// Using the config like this makes your life easier, trust me


namespace Nunu.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on harass mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            // TODO: Add harass logic here
            // See how I used the Settings.UseQ and Settings.Mana here, this is why I love
            // my way of using the menu in the Config class!
            if (Settings.UseE && E.IsReady() && Player.Instance.ManaPercent >= Settings.MinMana)
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Magical);
                if (target != null)
                {
                    E.Cast(target);
                    return;
                }
            }
        }
    }
}
