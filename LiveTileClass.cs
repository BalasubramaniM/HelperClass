using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace LiveTileUpdate
{
    class LiveTileClass
    {
        /*
         * Source : http://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh868253.aspx
         */
        /// <summary>
        /// Live Tiles Implementation - Universal Apps Windows
        /// Call this method LiveTiles() to create Live Tiles
        /// </summary>
        public void LiveTiles()
        {
            /// <summary>
            /// GetTemplateContent gets type of template based upon Windows 8 or Windows Phone deployment
            /// GetTemplateContent method retrieves an XmlDocument.
            /// </summary>
            /// <param name = "TileWide310x150ImageAndText01"> Returns type of template which is wide and has image and text in it.</param>
            XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150ImageAndText01);

            /// <summary>
            /// XmlNodeList - Since LiveTile Template class will be in XML format
            /// </summary>
            /// <param name = "GetElementsByTagName("text")">  Retrieves all elements in the template with a tag name of "text"</param>

            /// <param name = "Hello World! My very own tile notification">  Writes this text into the Xml document</param> 
            XmlNodeList tileTextAttributes = tileXml.GetElementsByTagName("text");
            tileTextAttributes[0].InnerText = "Hello World! My very own tile notification";

            /// <summary>
            /// Same as Text process, see above.
            /// </summary>
            XmlNodeList tileImageAttributes = tileXml.GetElementsByTagName("image");
            ((XmlElement)tileImageAttributes[0]).SetAttribute("src", "ms-appx:///Assets/wide-picture.png");

            /// <param name = "alt"> Writes text "red graphic" as an alternative text for Image </param> 
            ((XmlElement)tileImageAttributes[0]).SetAttribute("alt", "red graphic");

            /// <param name = "TileSquare150x150Text04"> Creates separate tile for Windows Phone since its for Universal Apps </param> 
            XmlDocument squareTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text04);

            /// <summary>
            /// Same as Text process, see above.
            /// </summary>
            XmlNodeList squareTileTextAttributes = squareTileXml.GetElementsByTagName("text");
            squareTileTextAttributes[0].AppendChild(squareTileXml.CreateTextNode("Hello World! My very own tile notification"));

            /// <summary>
            /// Get content of the Square Tile and binding its text to Wide Tile
            /// </summary>
            IXmlNode node = tileXml.ImportNode(squareTileXml.GetElementsByTagName("binding").Item(0), true);
            tileXml.GetElementsByTagName("visual").Item(0).AppendChild(node);

            /// <summary>
            /// Creates new Tile Notification with "tileXml"
            /// </summary>
            TileNotification tileNotification = new TileNotification(tileXml);

            /// <summary>
            /// Optional - Set ExpirationTime if you want to update tile only for certain interval
            /// </summary>
            tileNotification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);

            /// <summary>
            /// Update the Tile finally
            /// </summary>
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);

            /// <summary>
            /// Use only if you wish to clear the contents in the tile
            /// This line is commented currently, use to clear the tile contents
            /// </summary>
            //Windows.UI.Notifications.TileUpdateManager.CreateTileUpdaterForApplication().Clear();

            /// <summary>
            /// GetTemplateContent retrieves this XML document and insert data in further process
            /// </summary>
            /// <param name = "TileWide310x150ImageAndText01"> XML document of Tile "TileWide310x150ImageAndText01" </param>
            /*
               <tile>
                <visual version="2">
                    <binding template="TileWide310x150ImageAndText01" fallback="TileWideImageAndText01">
                        <image id="1" src=""/>
                        <text id="1"></text>
                    </binding>
                </visual>
               </tile>
            */
        }
    }
}
