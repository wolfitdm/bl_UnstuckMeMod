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
        public GameObject getInteract()
        {
            try
            {
                if (Main.Instance.Player == null || Main.Instance.Player.WeaponInv == null || Main.Instance.Player.WeaponInv.IntLookingAt == null)
                {
                    return null;
                }

                Interactible la = Main.Instance.Player.WeaponInv.IntLookingAt;

                if (la != null)
                {
                    GameObject ga = la.gameObject;
                    return ga;
                }
            }
            catch (Exception e)
            {
            }
            return null;
        }
        public GameObject getPersonInteract()
        {
            GameObject ga = this.getInteract();

            if (ga == null)
            {
                return null;
            }

            Interactible la = ga.GetComponent<Interactible>();

            if (la != null)
            {
                if (la is int_Person)
                {
                    int_Person int_thisPerson = (int_Person)la;
                    if (int_thisPerson.ThisPerson != null)
                    {
                        Person thisPerson = int_thisPerson.ThisPerson;
                        return thisPerson.gameObject;
                    }
                }
            }

            return null;
        }
        public void doWork()
		{
            try
            {
                GameObject personGa = this.getPersonInteract();
                if (personGa != null)
                {
                    Main.Instance.GameplayMenu.ShowNotification("unstuck me from the chat");
                    Person person = personGa.GetComponent<Person>();
                    if (person != null)
                    {
                        Main.Instance.GameplayMenu.ShowNotification("unstuck me from the chat really");
                        int_Person personInt = person.ThisPersonInt;
                        if (personInt != null)
                        {
                            Main.Instance.GameplayMenu.ShowNotification("unstuck me from the chat really really");
                            personInt.EndTheChat();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.Player.UserControl.enabled = true;
            }
            catch
            {
            }

            try
            {
                Main.Instance.Player.UserControl.ThirdCamPositionType = Main.Instance.Player.UserControl.ThirdCamPositionTypeOnSettings;
            }
            catch
            {
            }

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
                Main.Instance.GameplayMenu.EndChat();
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.Player.UserControl.UnstuckPlayer();
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.Player.UserControl.m_Character.m_Animator.SetFloat("Forward", 0.5f);
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.Player.UserControl.m_Character.m_Animator.SetFloat("Turn", 0.5f);
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.Player.UserControl.m_Character.m_Rigidbody.velocity = Vector3.one;
            }
            catch (Exception ex)
            {
            }

            try
            {
                UI_Gameplay _this = (UI_Gameplay)Main.Instance.GameplayMenu;
                try
                {
                    _this.CloseStorage();
                }
                catch (Exception ex)
                {
                }

                try
                {
                    _this.CloseEscMenu();
                }
                catch (Exception ex)
                {
                }

                try
                {
                    _this.CloseJournal();
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                if (Main.Instance.PeopleFollowingPlayer.Count > 0)
                {
                    Main.Instance.GameplayMenu.ShowNotification("UNSTUCK ME 2.0 Following Player ");
                    for (int i = 0; i < Main.Instance.PeopleFollowingPlayer.Count; i++)
                    {
                        if (Main.Instance.Player.transform != null && Main.Instance.PeopleFollowingPlayer[i].transform != null)
                        {
                            Main.Instance.GameplayMenu.ShowNotification("UNSTUCK ME MINI F8 2.0 Following Player ");
                            Main.Instance.PeopleFollowingPlayer[i].transform.position = Main.Instance.Player.transform.position;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                Main.Instance.GameplayMenu.ShowNotification("UNSTUCK ME 3.0!");
            }
            catch (Exception ex)
            {
            }

            return;
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

