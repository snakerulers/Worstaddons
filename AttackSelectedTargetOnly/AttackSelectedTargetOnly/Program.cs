﻿namespace AttackSelectedTargetOnly{using System;using EloBuddy;using EloBuddy.SDK;using EloBuddy.SDK.Events;using EloBuddy.SDK.Menu;using EloBuddy.SDK.Menu.Values;class Program{public static Menu Menuini;static void Main(string[] args){Loading.OnLoadingComplete += Loading_OnLoadingComplete;}private static void Loading_OnLoadingComplete(EventArgs args){Menuini = MainMenu.AddMenu("FocusSelectedTarget", "FocusSelectedTarget");Menuini.Add("enable", new CheckBox("Attack Selected Target Only"));Player.OnIssueOrder += Player_OnIssueOrder;}private static void Player_OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args){var target = TargetSelector.SelectedTarget;if (args.Target == null || target == null || args.Target.NetworkId == target.NetworkId || !Menuini["enable"].Cast<CheckBox>().CurrentValue) return;args.Process = false;Player.IssueOrder(GameObjectOrder.AttackTo, target);}}}