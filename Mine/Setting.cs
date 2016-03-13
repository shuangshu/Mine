using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace Mine
{
    public class Setting
    {
        private int column = 10;//水平像素
        private int row = 10;//垂直像素
        private int mineNumber = 10;//雷数
        public int Column
        {
            get { return column; }
            set { column = value; }
        }
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public int MineNumber
        {
            get { return mineNumber; }
            set { mineNumber = value; }
        }
        private bool allowVoice = false;
        public bool AllowVoice
        {
            get { return allowVoice; }
            set { allowVoice = value; }
        }
        private bool allowColor = false;
        public bool AllowColor
        {
            get { return allowColor; }
            set { allowColor = value; }
        }

        public void Load()
        {
            string element = string.Empty;
            XmlTextReader reader = null;
            if (File.Exists("Mine.xml")) reader = new XmlTextReader("Mine.xml");
            try
            {
                while (reader.Read())
                {
                    XmlNodeType nodeType = reader.NodeType;
                    if (nodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "Row":
                                element = reader.ReadElementString().Trim();
                                row = int.Parse(element);
                                break;
                            case "Column":
                                element = reader.ReadElementString().Trim();
                                column = int.Parse(element);
                                break;
                            case "MineNumber":
                                element = reader.ReadElementString().Trim();
                                mineNumber = int.Parse(element);
                                break;
                            case "AllowVoice":
                                element = reader.ReadElementString().Trim();
                                allowVoice = bool.Parse(element);
                                break;
                            case "AllowColor":
                                element = reader.ReadElementString().Trim();
                                allowColor = bool.Parse(element);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }
        public void Save()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Mine.xml");
            XmlNode root = doc.SelectSingleNode("Setting");
            root.RemoveAll();
            XmlElement xelRow = doc.CreateElement("Row");
            xelRow.InnerText = row.ToString();
            XmlElement xelColumn = doc.CreateElement("Column");
            xelColumn.InnerText = column.ToString();
            XmlElement xelMineNumber = doc.CreateElement("MineNumber");
            xelMineNumber.InnerText = mineNumber.ToString();
            XmlElement xelAllowVoice = doc.CreateElement("AllowVoice");
            xelAllowVoice.InnerText = allowVoice.ToString();
            XmlElement xelAllowColor = doc.CreateElement("AllowColor");
            xelAllowColor.InnerText = allowColor.ToString();
            root.AppendChild(xelRow);
            root.AppendChild(xelColumn);
            root.AppendChild(xelMineNumber);
            root.AppendChild(xelAllowVoice);
            root.AppendChild(xelAllowColor);
            doc.Save("Mine.xml");
        }
    }
}
