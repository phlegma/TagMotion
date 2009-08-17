using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;


namespace Chrismo.TagMotion
{
    /// <summary>
    /// Mithilfe dieser kleinen Klasse, kann der aufbau des Treeviews in eine Xml Datei exportiert
    /// und natürlich auch wieder in einen TreeView Importiert werden.
    /// </summary>
    /// <example>
    /// <code lang="C#">
    /// TreeView tmpTreeview = new TreeView();
    /// 
    /// XmlHandler xmlHandler = new XmlHandler();
    /// //treeview TO Xml
    /// xmlHandler.ExportTreeToXmlFile(tmpTreeview, "C:\\temp\\tmpTreeView.xml");
    /// </code>
    /// </example>
    public class TreeviewHandler
    {
        XmlDocument xmlDocument;
		string Nodename = "TreeNode";
		
        /// <summary>
        /// Initialisiert eine neue Instanz der MultiClipboard Klasse.
        /// </summary>
        public TreeviewHandler()
        {
        	
        }

        /// <summary>
        /// Den inhalt des TreeViews in eine xml Datei exportieren
        /// </summary>
        /// <param name="treeView">Der TreeView der exportiert werden soll</param>
        /// <param name="path">Ein  Pfad unter dem die Xml Datei entstehen soll</param>
        public void TreeViewToXml(TreeView treeView, String path)
        {
            xmlDocument = new XmlDocument();
            xmlDocument.AppendChild(xmlDocument.CreateElement("ROOT"));
            XmlRekursivExport(xmlDocument.DocumentElement,treeView.Nodes);
            xmlDocument.Save(path);
        }

        /// <summary>
        /// Eine vorher Exportierte Xml Datei wieder in ein TreeView importieren
        /// </summary>
        /// <param name="path">Der Quellpfad der Xml Datei</param>
        /// <param name="treeView">Ein TreeView in dem der Inhalt der Xml Datei wieder angezeigt werden soll</param>
        /// <exception cref="FileNotFoundException">gibt an das die Datei nicht gefunden werden konnte</exception>
        public void XmlToTreeView(String path, TreeView treeView)
        {
            xmlDocument = new XmlDocument();
            
            xmlDocument.Load(path);
            treeView.Nodes.Clear();
            
            XmlRekursivImport(treeView.Nodes, xmlDocument.DocumentElement.ChildNodes);
        }

        private XmlNode XmlRekursivExport(XmlNode nodeElement, TreeNodeCollection treeNodeCollection)
        {
            XmlNode xmlNode = null;
                        	
            foreach (TreeNode treeNode in treeNodeCollection)
            {
            	
            	if(treeNode.Tag == null)
                    xmlNode = xmlDocument.CreateElement(Nodename);
                else
                {
                	xmlNode = xmlDocument.CreateElement(treeNode.Tag.ToString());
                	Nodename = treeNode.Tag.ToString();
                }
                
                xmlNode.Attributes.Append(xmlDocument.CreateAttribute("value"));
                xmlNode.Attributes["value"].Value = treeNode.Text;

                
                if (nodeElement != null)
                    nodeElement.AppendChild(xmlNode);

                if (treeNode.Nodes.Count > 0)
                    XmlRekursivExport(xmlNode, treeNode.Nodes);
            }
            
            return xmlNode;
        }

        private void XmlRekursivImport(TreeNodeCollection elem, XmlNodeList xmlNodeList)
        {
            TreeNode treeNode;
            
            foreach (XmlNode myXmlNode in xmlNodeList)
            {
                treeNode = new TreeNode(myXmlNode.Attributes["value"].Value);

                if (myXmlNode.ChildNodes.Count > 0)
                    XmlRekursivImport(treeNode.Nodes, myXmlNode.ChildNodes);
                
                elem.Add(treeNode);
            }
        }
    }
}
