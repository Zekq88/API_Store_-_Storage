using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lab_4___Winform
{
    internal class Logger
    {
        string filePath = Application.StartupPath + "\\Pitchko_Mater.CSV";
        public string fileXMLPath = Application.StartupPath + "\\Pitchko_Mater.xml";

        List<string> list = new List<string>();

        public Logger() { }

        public bool Write(List<object> newList)
        {
            bool saved = true;
            List<string> extendedList = new List<string>();
            if (newList != null)
            {
                foreach (object line in newList)
                {
                    extendedList.Add(line.ToString());

                }
                list.AddRange(extendedList);
            }

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filePath);
                foreach (string line in extendedList)
                {
                    writer.WriteLine(line);
                }
            }
            catch (IOException ex)
            {
                saved = false;
                MessageBox.Show("Error saving file: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                saved = false;
                MessageBox.Show("Access denied: " + ex.Message);
            }
            catch (Exception ex)
            {
                saved = false;
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                writer.Close();
            }

            return saved;
        }

       

        public bool WriteXML(List<string> newList)
        {
            bool saved = true;
            List<string> extendedList = new List<string>();
            if (newList != null)
            {
                foreach (string line in newList)
                {
                    extendedList.Add(line);
                }
                list.AddRange(extendedList);
            }

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(fileXMLPath);
                foreach (string line in extendedList)
                {
                    writer.WriteLine(line);
                }
            }
            catch (IOException ex)
            {
                saved = false;
                MessageBox.Show("Error saving file: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                saved = false;
                MessageBox.Show("Access denied: " + ex.Message);
            }
            catch (Exception ex)
            {
                saved = false;
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                writer.Close();
            }
            return saved;
        }
       
    }
}

