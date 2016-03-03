// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace VelerSoftware.SZC.WindowsDesigner
{
    public class Designer : System.ComponentModel.Design.DesignSurface
    {

		// Gestion des options de design
		public System.Windows.Forms.Design.WindowsFormsDesignerOptionService designerOptionService = new System.Windows.Forms.Design.WindowsFormsDesignerOptionService();
		
		// Menu
		public MenuCommandServiceImpl Menu;

        public System.ComponentModel.Design.ServiceContainer _ServiceContainer { get { return this.ServiceContainer; } }

        public Designer()
            : this(false, true, true, true, true, true, true)
        {
           
        }

		public Designer(bool ShowGrid, bool EnableInSituEditing, bool UseSnapLines, bool UseOptimizedCodeGeneration, bool UseSmartTags, bool ObjectBoundSmartTagAutoShow, bool SnapToGrid)
		{
           	// Service de gestion du toolbox
			ServiceContainer.AddService(typeof(System.Drawing.Design.IToolboxService), new ToolBoxService());

            //ServiceContainer.AddService(typeof(System.ComponentModel.Design.IResourceService), new DesignerResourceService(this.resourceStore));
            ServiceContainer.AddService(typeof(System.Windows.Forms.AmbientProperties), new System.Windows.Forms.AmbientProperties());
     
            // Service de vue du concepteur
			//ServiceContainer.AddService(typeof(ViewService), new ViewService());
			// Service de gestion des menus
			Menu = new MenuCommandServiceImpl(this.ServiceContainer);
			Menu.OnExecuteViewCode += new MenuCommandServiceImpl.OnExecuteViewCodeEventHandler(Menu_OnExecuteViewCode);
			Menu.OnExecuteViewProperty += new MenuCommandServiceImpl.OnExecuteViewPropertyEventHandler(Menu_OnExecuteViewProperty);
            Menu.OnExecuteCreateEvent += new MenuCommandServiceImpl.OnExecuteCreateEventEventHandler(Menu_OnExecuteCreateEvent);
            Menu.OnSelectComponentEvent += new MenuCommandServiceImpl.OnSelectComponentEventEventHandler(Menu_OnSelectComponentEvent);
            Menu.Designer = this;
            ServiceContainer.AddService(typeof(System.ComponentModel.Design.IMenuCommandService), Menu);

			// On spécifie qu'on va utilser la grille pour placer les composants
			designerOptionService.CompatibilityOptions.ShowGrid = ShowGrid;
			designerOptionService.CompatibilityOptions.EnableInSituEditing = EnableInSituEditing;
			designerOptionService.CompatibilityOptions.UseSnapLines = UseSnapLines;
			designerOptionService.CompatibilityOptions.UseOptimizedCodeGeneration = UseOptimizedCodeGeneration;
			designerOptionService.CompatibilityOptions.UseSmartTags = UseSmartTags;
			designerOptionService.CompatibilityOptions.ObjectBoundSmartTagAutoShow = ObjectBoundSmartTagAutoShow;
			designerOptionService.CompatibilityOptions.SnapToGrid = SnapToGrid;
			ServiceContainer.AddService(typeof(System.ComponentModel.Design.DesignerOptionService), designerOptionService);
		}

		public void Menu_OnExecuteViewCode(object sender, EventArgs e)
		{
			if (this.OnExecuteViewCode != null)
			{
				this.OnExecuteViewCode(sender, e);
			}	
		}
		/// <summary>
		/// Declare un delegate
		/// </summary>
		public delegate void OnExecuteViewCodeEventHandler(object sender, EventArgs e);
		/// <summary>
		/// Declare un evenement qui va contenir les informations que nous souhaitons envoyer
		/// </summary>
		public event OnExecuteViewCodeEventHandler OnExecuteViewCode;





		public void Menu_OnExecuteViewProperty(object sender, EventArgs e)
		{
			if (this.OnExecuteViewProperty != null)
			{
				this.OnExecuteViewProperty(sender, e);
			}
		}
		/// <summary>
		/// Declare un delegate
		/// </summary>
		public delegate void OnExecuteViewPropertyEventHandler(object sender, EventArgs e);
		/// <summary>
		/// Declare un evenement qui va contenir les informations que nous souhaitons envoyer
		/// </summary>
		public event OnExecuteViewPropertyEventHandler OnExecuteViewProperty;





		public void Menu_OnExecuteCreateEvent(object sender, EventArgs e)
		{
			if (this.OnExecuteCreateEvent != null)
			{
				this.OnExecuteCreateEvent(sender, e);
			}
		}
		/// <summary>
		/// Declare un delegate
		/// </summary>
		public delegate void OnExecuteCreateEventEventHandler(object sender, EventArgs e);
		/// <summary>
		/// Declare un evenement qui va contenir les informations que nous souhaitons envoyer
		/// </summary>
        public event OnExecuteCreateEventEventHandler OnExecuteCreateEvent;





        public void Menu_OnSelectComponentEvent(object sender, EventArgs e)
        {
            if (this.OnSelectComponentEvent != null)
            {
                this.OnSelectComponentEvent(sender, e);
            }
        }
        /// <summary>
        /// Declare un delegate
        /// </summary>
        public delegate void OnSelectComponentEventEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Declare un evenement qui va contenir les informations que nous souhaitons envoyer
        /// </summary>
        public event OnSelectComponentEventEventHandler OnSelectComponentEvent;
    }
}
