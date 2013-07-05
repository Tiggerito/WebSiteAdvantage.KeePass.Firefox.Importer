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
using KeePass.Plugins;
using KeePassLib.Security;
using KeePassLib;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.Diagnostics;
using KeePass.DataExchange;
using KeePass.Resources;
using KeePass;

namespace WebSiteAdvantageKeePassFirefoxImporter
{
	/// <summary>
	/// Registers the plugin/extension with KeePass
	/// </summary>
	public sealed class WebSiteAdvantageKeePassFirefoxImporterExt : Plugin
    {
        private IPluginHost m_host = null;

        public override bool Initialize(IPluginHost host)
        {
            Debug.Assert(host != null);
            if (host == null) return false;
            m_host = host;


            Program.FileFormatPool.Add(FirefoxFormatImporter.Instance);
            Program.FileFormatPool.Add(FirefoxFormatImporterXml.Instance);

            return true; // Initialization successful
        }

        public override void Terminate()
        {
            Program.FileFormatPool.Remove(FirefoxFormatImporter.Instance);
            Program.FileFormatPool.Remove(FirefoxFormatImporterXml.Instance);
        }
    }
}
