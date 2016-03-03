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
using System.Windows.Forms;

namespace VelerSoftware.SZC.WindowsDesigner
{
    public class ToolBoxService : System.Drawing.Design.IToolboxService
    {
        // ToolBox
        ListBox toolBox = null;
        // Vue du concepteur
        Control view = null;


        // On définit la toolbox
        public ListBox ToolBox { set { toolBox = value; } }

        // On définit la vue du concepteur
        public Control View { set { view = value; } } 

        // Pas utiliser
        public void AddCreator(System.Drawing.Design.ToolboxItemCreatorCallback creator, string format, System.ComponentModel.Design.IDesignerHost host)
        {
        }

        // Pas utiliser
        public void AddCreator(System.Drawing.Design.ToolboxItemCreatorCallback creator, string format)
        {
        }

        // Pas utiliser
        public void AddLinkedToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem, string category, System.ComponentModel.Design.IDesignerHost host)
        {
        }

        // Pas utiliser
        public void AddLinkedToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem, System.ComponentModel.Design.IDesignerHost host)
        {
        }

        // Ajout d'un ToolboxItem au toolBox
        public void AddToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem, string category)
        {
            AddToolboxItem(toolboxItem);
        }

        // Ajout d'un ToolboxItem au toolBox
        public void AddToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem)
        {
            toolBox.Items.Add(toolboxItem);
            toolBox.SelectedIndex = 0;
        }

        // Pas utiliser
        public System.Drawing.Design.CategoryNameCollection CategoryNames
        {
            get { return null; }
        }

        // Déserialize un toolboxitem nécessaire pour le drag and drop
        public System.Drawing.Design.ToolboxItem DeserializeToolboxItem(object serializedObject, System.ComponentModel.Design.IDesignerHost host)
        {
            return DeserializeToolboxItem(serializedObject);
        }

        // Déserialize un toolboxitem nécessaire pour le drag and drop
        public System.Drawing.Design.ToolboxItem DeserializeToolboxItem(object serializedObject)
        {
            IDataObject dataObject = serializedObject as IDataObject;

            if (dataObject == null)
            {
                return null;
            }

            System.Drawing.Design.ToolboxItem t = (System.Drawing.Design.ToolboxItem)dataObject.GetData(typeof(System.Drawing.Design.ToolboxItem));
            return t;
        }

        // Retoutrne le ToolboxItem sélectionné
        public System.Drawing.Design.ToolboxItem GetSelectedToolboxItem(System.ComponentModel.Design.IDesignerHost host)
        {
            return GetSelectedToolboxItem();
        }

        // Retoutrne le ToolboxItem sélectionné
        public System.Drawing.Design.ToolboxItem GetSelectedToolboxItem()
        {
            if(toolBox == null)
                return null;

            return (System.Drawing.Design.ToolboxItem)toolBox.SelectedItem;
        }

        // Retoutrne la liste de ToolboxItems sélectionnés
        public System.Drawing.Design.ToolboxItemCollection GetToolboxItems(string category, System.ComponentModel.Design.IDesignerHost host)
        {
            return GetToolboxItems();
        }

        // Retoutrne la liste de ToolboxItems sélectionnés
        public System.Drawing.Design.ToolboxItemCollection GetToolboxItems(string category)
        {
            return GetToolboxItems();
        }

        // Retoutrne la liste de ToolboxItems sélectionnés
        public System.Drawing.Design.ToolboxItemCollection GetToolboxItems(System.ComponentModel.Design.IDesignerHost host)
        {
            return GetToolboxItems();
        }

        // Retoutrne la liste de ToolboxItems sélectionnés
        public System.Drawing.Design.ToolboxItemCollection GetToolboxItems()
        {
            if (toolBox == null)
                return null;

            System.Drawing.Design.ToolboxItem[] t = new System.Drawing.Design.ToolboxItem[toolBox.Items.Count];
            toolBox.Items.CopyTo(t, 0);

            return new System.Drawing.Design.ToolboxItemCollection(t);
        }

        // Pas utiliser
        public bool IsSupported(object serializedObject, System.Collections.ICollection filterAttributes)
        {
            return false;
        }

        // Pas utiliser
        public bool IsSupported(object serializedObject, System.ComponentModel.Design.IDesignerHost host)
        {
            return false;
        }

        // Pas utiliser
        public bool IsToolboxItem(object serializedObject, System.ComponentModel.Design.IDesignerHost host)
        {
            return false;
        }

        // Pas utiliser
        public bool IsToolboxItem(object serializedObject)
        {
            return false;
        }

        // Pas utiliser
        public void RemoveCreator(string format, System.ComponentModel.Design.IDesignerHost host)
        {
        }

        // Pas utiliser
        public void RemoveCreator(string format)
        {
        }

        // Retire un toolboxItem du toolbox
        public void RemoveToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem, string category)
        {
            RemoveToolboxItem(toolboxItem);
        }

        // Retire un toolboxItem du toolbox
        public void RemoveToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem)
        {
            if (toolBox == null)
                return;

            toolBox.SelectedItem = null;
            toolBox.Items.Remove(toolboxItem);
        }

        // Pas utiliser
        public string SelectedCategory
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        // Indique qu'un toolboxItem a été utilisé on met la sélection de la toolbox à null
        public void SelectedToolboxItemUsed()
        {
            if (toolBox == null)
                return;

            toolBox.SelectedItem = null;
        }

        // Sérialize la toolboxItem nécessaire pour le drag and drop
        public object SerializeToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem)
        {
            DataObject dataObject = new DataObject();
            dataObject.SetData(typeof(System.Drawing.Design.ToolboxItem), toolboxItem);
            return dataObject;
        }

        // Indique si un curseur est utiliser si un toolboxItem est sélectionné
        public bool SetCursor()
        {
            if (view == null)
                return false;

            if (toolBox.SelectedItem != null)
            {
                //view.Cursor = Cursors.Cross;
                return true;
            }

            return false;
        }

        // Indique si un curseur est utiliser si un toolboxItem est sélectionné
        public bool SetCursorOff()
        {
            if (view == null)
                return false;

            if (toolBox.SelectedItem != null)
            {
                view.Cursor = Cursors.Default;
                return true;
            }

            return false;
        }

        // On définit un toolboxItem à sélectionner sur le toolBox
        public void SetSelectedToolboxItem(System.Drawing.Design.ToolboxItem toolboxItem)
        {
            if (toolBox == null)
                return;

            toolBox.SelectedItem = toolboxItem;
        }

        // rafrachit la toolbox
        public void Refresh()
        {
            toolBox.Refresh();
        }
    }
}
