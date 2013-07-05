/*	WebSiteAdvantage KeePass to Firefox 
 *	Copyright (C) 2008 - 2012 Anthony James McCreath
 *
 *	This library is free software; you can redistribute it and/or
 *	modify it under the terms of the GNU Lesser General Public
 *	License as published by the Free Software Foundation; either
 *	version 2.1 of the License, or (at your option) any later version.
 *
 *	This library is distributed in the hope that it will be useful,
 *	but WITHOUT ANY WARRANTY; without even the implied warranty of
 *	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *	Lesser General Public License for more details.
 *
 *	You should have received a copy of the GNU Lesser General Public
 *	License along with this library; if not, write to the Free Software
 *	Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.Collections.Generic;
using System.Text;
using KeePassLib;
using System.Windows.Forms;
using KeePassLib.Collections;

namespace WebSiteAdvantage.KeePass.Firefox.Importer
{
	/// <summary>
	/// common methods to help use keepass. 
	/// these use the 2.0 dll so are specific to this project
	/// </summary>
	public class KeePassHelper
	{
		/// <summary>
		/// Seaches a KeePass group and its children for an entry with the same Url and UserName
		/// </summary>
		/// <param name="group"></param>
		/// <param name="url"></param>
		/// <param name="username"></param>
		/// <returns>The matched enrty</returns>
		public static PwEntry FindMatchingEntry(PwGroup group, string url, string username)
		{
			// Chech the current group
			foreach (PwEntry entry in group.Entries)
			{

				if (entry.Strings !=null && 
					entry.Strings.Get(PwDefs.UrlField) != null &&
					entry.Strings.Get(PwDefs.UrlField).ReadString() == url &&
					entry.Strings.Get(PwDefs.UserNameField)!=null &&
					entry.Strings.Get(PwDefs.UserNameField).ReadString() == username)
					return entry;
			}
			// Check each child group usinbg recursion
			foreach (PwGroup subGroup in group.Groups)
			{
				PwEntry subEntry = FindMatchingEntry(subGroup, url, username);

				if (subEntry != null)
					return subEntry;
			}
			return null;
		}

		/// <summary>
		/// recursuve search for a group
		/// </summary>
		/// <param name="group"></param>
		/// <param name="groupName"></param>
		/// <returns></returns>
		public static PwGroup FindGroup(PwGroup group, string groupName)
		{
			if (group.Name == groupName)
				return group;


			// Check each child group using recursion
			foreach (PwGroup subGroup in group.Groups)
			{
				PwGroup subSubGroup = FindGroup(subGroup, groupName);

				if (subSubGroup != null)
					return subSubGroup;
			}
			return null;
		}

		/// <summary>
		/// Item for use in combo boxes so Groups get displayed in a nice way
		/// </summary>
		public class GroupItem
		{
			/// <summary>
			/// The Group this item represents
			/// </summary>
			public PwGroup Group;
			/// <summary>
			/// The depth this group is in the heirachy
			/// </summary>
			public Int32 Level = 0;

			/// <summary>
			/// How to display the item in the combo box
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				string tab = new String(' ', Level * 2); // add two spaces per level

				return tab + Group.Name;
			}

			/// <summary>
			/// Create and initialise an item
			/// </summary>
			/// <param name="group"></param>
			/// <param name="level"></param>
			public GroupItem(PwGroup group, Int32 level)
			{
				Group = group;
				Level = level;
			}
		}
		/// <summary>
		/// Populates the Group based combo and sets the selected item to the last one selected in KeePass
		/// </summary>
		/// <param name="comboBox"></param>
		/// <param name="pwStorage"></param>
		public static void InitialiseGroupComboBox(ComboBox comboBox, PwDatabase pwStorage)
		{
			KeePassHelper.AddGroupToComboBox(comboBox, pwStorage.RootGroup, 0);

			KeePassHelper.SetComboBoxGroup(comboBox, pwStorage.RootGroup.FindGroup(pwStorage.LastSelectedGroup, true));
		}
		/// <summary>
		/// Adds a group and its sub groups to a combo box
		/// Sub groups get displayed indented
		/// </summary>
		/// <param name="comboBox"></param>
		/// <param name="group"></param>
		/// <param name="level"></param>
		private static void AddGroupToComboBox(ComboBox comboBox, PwGroup group, Int32 level)
		{
			comboBox.Items.Add(new GroupItem(group, level));
			Int32 level2 = level + 1;

			foreach (PwGroup subGroup in group.Groups)
			{
				AddGroupToComboBox(comboBox, subGroup, level2);
			}
		}

		/// <summary>
		/// Sets the selected item of the combo to the one matching the supplied group
		/// </summary>
		/// <param name="comboBox"></param>
		/// <param name="group"></param>
		private static void SetComboBoxGroup(ComboBox comboBox, PwGroup group)
		{
			if (group == null)
				comboBox.SelectedIndex = 0;
			else
			{
				foreach (KeePassHelper.GroupItem item in comboBox.Items)
				{
					if (item.Group == group)
					{
						comboBox.SelectedItem = item;
						return;
					}
				}
			}
		}

        public static void InsertAutoType(PwEntry pwEntry, string window, string sequence)
        {
            bool found = false;


            foreach (AutoTypeAssociation aas in pwEntry.AutoType.Associations)
            {
                if (aas.WindowName == window)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                pwEntry.AutoType.Add(new AutoTypeAssociation(window, sequence));
        }

	}
}
