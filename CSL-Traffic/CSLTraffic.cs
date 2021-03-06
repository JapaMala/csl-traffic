using ColossalFramework.Globalization;
using ICities;
using System.Collections.Generic;
using UnityEngine;
using CSL_Traffic.Extensions;
using ColossalFramework;
using System;
using System.Text;
using ColossalFramework.Plugins;

namespace CSL_Traffic
{
	public class CSLTraffic : LoadingExtensionBase, IUserMod
	{
        public static OptionsManager.ModOptions Options = OptionsManager.ModOptions.None;
        static GameObject sm_optionsManager;
        
        GameObject m_initializer;

		public string Name
		{
			get
            {
                if (sm_optionsManager == null)
                {
                    sm_optionsManager = new GameObject("OptionsManager");
                    sm_optionsManager.AddComponent<OptionsManager>();
                }

                return "Traffic++";
            }
		}

		public string Description
		{
			get { return "Adds zonable pedestrian paths and other traffic improvements."; }
		}

		public override void OnCreated(ILoading loading)
		{
			base.OnCreated(loading);

            if (sm_optionsManager != null)
            {
                sm_optionsManager.GetComponent<OptionsManager>().Load();
            }

            if (m_initializer == null)
            {
                m_initializer = new GameObject("CSL-Traffic Custom Prefabs");
                m_initializer.AddComponent<Initializer>();
            }
		}

		public override void OnReleased()
		{
			base.OnReleased();

            GameObject.Destroy(m_initializer);
		}
	}
}
