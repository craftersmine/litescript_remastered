using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace craftersmine.LiteScript.Api
{
    /// <summary>
    /// Represents plugin resource manager. This class cannot be inherited
    /// </summary>
	public sealed class ResourceManager
	{
        private Logger _resLogger;
        /// <summary>
        /// Plugin ID
        /// </summary>
        public string PluginID { get; private set; }
        /// <summary>
        /// Resource dictionary in <see cref="string"/>, <see cref="byte"/>[] format
        /// </summary>
		public Dictionary<string, byte[]> Resources { get; private set; } = new Dictionary<string, byte[]>();
        /// <summary>
        /// Resources root directory
        /// </summary>
		public string ResourcesRoot { get; private set; }
		
        /// <summary>
        /// Constructs a new <see cref="ResourceManager"/> object
        /// </summary>
        /// <param name="pluginId">Plugin ID</param>
		public ResourceManager(string pluginId)
		{
            _resLogger = new Logger("ResourceManagerLog");
            PluginID = pluginId;
            _resLogger.Log("DEBUG", "PluginID is " + PluginID);
            ResourcesRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LiteScriptIDE\\Plugins\\" + PluginID + "_Res");
            _resLogger.Log("DEBUG", "ResourcesRoot is " + ResourcesRoot);
			try
			{
                _resLogger.Log("INFO", "Trying load resources...");
                foreach (string filepath in Directory.EnumerateFiles(ResourcesRoot))
				{
					Resources.Add(Path.GetFileNameWithoutExtension(filepath), File.ReadAllBytes(filepath));
                    _resLogger.Log("INFO", "Resource Loaded: " + Path.GetFileNameWithoutExtension(filepath));
                }
			}
			catch (Exception ex)
			{
                _resLogger.Log("SEVERE", "Unable load resources! " + ex.Message + "\r\n" + ex.StackTrace);
                throw new Exception("Unable load resources for plugin");
			}
		}
		
        /// <summary>
        /// Gets the image associated with the specified key
        /// </summary>
        /// <param name="resid">Resource ID (file name without extension)</param>
        /// <param name="img">Image</param>
        /// <returns>True if resource found, else false</returns>
		public bool TryGetResourceAsImage(string resid, out Image img)
        {
            _resLogger.Log("INFO", "Trying get resource with id " + resid + " as image");
            img = null;
            byte[] bytes = null;
            if (Resources.TryGetValue(resid, out bytes))
            {
                img = _byteArrayToImage(bytes);
                return true;
            }
            else return false;
		}

        /// <summary>
        /// Gets the byte array associated with the specified key
        /// </summary>
        /// <param name="resid">Resource ID (file name without extension)</param>
        /// <param name="bytes">Byte array</param>
        /// <returns>True if resource found, else false</returns>
        public bool TryGetResourceAsBytes(string resid, out byte[] bytes)
        {
            _resLogger.Log("INFO", "Trying get resource with id " + resid + " as byte array");
            if (Resources.TryGetValue(resid, out bytes))
                return true;
            else return false;
        }

        /// <summary>
        /// Gets the string associated with the specified key
        /// </summary>
        /// <param name="resid">Resource ID (file name without extension)</param>
        /// <param name="content">String value</param>
        /// <returns>True if resource found, else false</returns>
        public bool TryGetResourceAsString(string resid, out string content)
        {
            _resLogger.Log("INFO", "Trying get resource with id " + resid + " as string");
            content = "";
            byte[] bytes = null;
            if (Resources.TryGetValue(resid, out bytes))
            {
                content = Encoding.ASCII.GetString(bytes);
                return true;
            }
            else return false;
        }

        private Image _byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}