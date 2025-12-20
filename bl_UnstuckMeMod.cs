using Den.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Mono.Security.X509.X520;
using static UnityEngine.Rendering.VolumeComponent;

namespace BitchLand//must have this namespace
{
	class bl_UnstuckMeModDoWork 
	{
		public bl_UnstuckMeModDoWork() 
		{ 
		}
		
		public void OnEnable()
		{
			doWork();
            enabled = true;
		}

        public void OnDisable()
        {
            enabled = false;
        }

		public void OnStart()
		{
			if (enabled)
			{
				this.OnEnable();
			} else
			{
				this.OnDisable();
			}
		}

		public void doWork()
		{
            try
            {
                Main.Instance.Player.RunBlockers.Clear();
            }
            catch
            {

                try
                {
                    Main.Instance.Player.RunBlockers = new List<string>();
                }
                catch (Exception ex)
                {
                }
            }

            try
            {
                Main.Instance.Player.MoveBlockers.Clear();
            }
            catch
            {

                try
                {
                    Main.Instance.Player.MoveBlockers = new List<string>();
                }
                catch (Exception ex)
                {
                }
            }

            try
            {
                Main.Instance.Player.ThisPersonInt.InteractBlockers.Clear();
            }
            catch
            {

                try
                {
                    Main.Instance.Player.ThisPersonInt.InteractBlockers = new List<string>();
                }
                catch (Exception ex)
                {
                }
            }

            try
            {
                Main.Instance.Player.CanMove = true;
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.Player.InteractingWith.CanLeave = true;
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.Player.Interacting = false;
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.Player.InCombat = false;
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.CanSaveFlags.Remove("CantMoveNow");
            }
            catch
            {
            }

            try
            {
                Main.Instance.CanSaveFlags = Main.Instance.CanSaveFlags;
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.GameplayMenu.SleepMenu.SetActive(false);
            }
            catch (Exception e)
            {
            }

            try
            {
                Main.Instance.GameplayMenu.EscMenu.SetActive(false);
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.GameplayMenu.TextInputMenu.SetActive(false);
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.GameplayMenu.TraderMenu.SetActive(false);
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.GameplayMenu.EnableMove();
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.GameplayMenu.AllowCursor();
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.GameplayMenu.ShowNotification("UNSTUCK ME!");
            }
            catch (Exception ex)
            {
            }
        }

        public static bl_UnstuckMeModDoWork Instance = new bl_UnstuckMeModDoWork();
		private bool enabled = false;
    }

	public class Mod//must have this class name
	{
		public static bl_UnstuckMeMod ThisMod;

		public static void Init() //must have this name, and MUST be static
		{
			ThisMod = Main.Instance.gameObject.AddComponent<bl_UnstuckMeMod>();
		}



		public static void EnableMod(bool value)
		{
			if(value)
			{//mod was enabled in the settings
				bl_UnstuckMeModDoWork.Instance.OnEnable();
            }
			else
			{
				bl_UnstuckMeModDoWork.Instance.OnDisable();
			}
		}
	}

	public class bl_UnstuckMeMod : MonoBehaviour
	{
		public void Start()
		{
            bl_UnstuckMeModDoWork.Instance.OnStart();
        }

	}
}

