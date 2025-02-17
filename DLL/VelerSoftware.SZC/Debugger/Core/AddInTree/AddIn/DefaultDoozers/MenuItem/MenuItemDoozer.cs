﻿// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System;
using System.Collections;

namespace VelerSoftware.SZC.Debugger.Core
{
    /// <summary>
    /// Creates menu items from a location in the addin tree.
    /// </summary>
    /// <attribute name="label" use="required">
    /// Label of the menu item.
    /// </attribute>
    /// <attribute name="type" use="optional" enum="Separator;CheckBox;Item;Command;Menu;Builder">
    /// This attribute must be one of these values:
    /// Separator, CheckBox, Item=Command, Menu (=with subitems),
    /// Builder (=class implementing ISubmenuBuilder).
    /// Default: Command.
    /// </attribute>
    /// <attribute name="loadclasslazy" use="optional">
    /// Only for the type "Item"/"Command".
    /// When set to false, the command class is loaded
    /// immediately instead of the usual lazy-loading.
    /// </attribute>
    /// <attribute name="icon" use="optional">
    /// Icon of the menu item.
    /// </attribute>
    /// <attribute name="class" use="optional">
    /// Command class that is run when item is clicked.
    /// </attribute>
    /// <attribute name="command" use="optional">
    /// A WPF routed command that is executed when item is clicked.
    /// Currently, this property is supported only for WPF Menus.
    /// Only one of the "class" and "command" attributes can be used on a menu entry.
    /// </attribute>
    /// <attribute name="link" use="optional">
    /// Only for the type "Item"/"Command". Opens a webpage instead of running a command when
    /// clicking the item.
    /// </attribute>
    /// <attribute name="shortcut" use="optional">
    /// Shortcut that activates the command (e.g. "Control|S").
    /// </attribute>
    /// <children childTypes="MenuItem">
    /// If "type" is "Menu", the item can have sub-menuitems.
    /// </children>
    /// <usage>Any menu strip paths or context menu paths, e.g. /SharpDevelop/Workbench/MainMenu</usage>
    /// <returns>
    /// A MenuItemDescriptor object.
    /// </returns>
    /// <conditions>Conditions are handled by the item, "Exclude" maps to "Visible = false", "Disable" to "Enabled = false"</conditions>
    public class MenuItemDoozer : IDoozer
    {
        /// <summary>
        /// Gets if the doozer handles codon conditions on its own.
        /// If this property return false, the item is excluded when the condition is not met.
        /// </summary>
        public bool HandleConditions
        {
            get
            {
                return true;
            }
        }

        public object BuildItem(object caller, Codon codon, ArrayList subItems)
        {
            return new MenuItemDescriptor(caller, codon, subItems);
        }
    }

    /// <summary>
    /// Represents a menu item. These objects are created by the MenuItemDoozer and
    /// then converted into GUI-toolkit-specific objects by the MenuService.
    /// </summary>
    public sealed class MenuItemDescriptor
    {
        public readonly object Caller;
        public readonly Codon Codon;
        public readonly IList SubItems;

        public MenuItemDescriptor(object caller, Codon codon, IList subItems)
        {
            if (codon == null)
                throw new ArgumentNullException("codon");
            this.Caller = caller;
            this.Codon = codon;
            this.SubItems = subItems;
        }
    }
}