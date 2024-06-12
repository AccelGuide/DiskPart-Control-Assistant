using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace DiskPart_Control_Assistant
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialize UI components
            this.Text = "DiskPart Control Assistant";
            Update_Disks_button.Text = "Update Disks";
            Main_treeView.Nodes.Clear();
        }

        private void Update_Disks_button_Click(object sender, EventArgs e)
        {
            UpdateDiskList();
        }

        private void UpdateDiskList()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "diskpart.exe";
                process.StartInfo.Arguments = "/s scriptListe.txt";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;;
                process.Start();
;
                File.WriteAllText("scriptListe.txt", "list disk");

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();





                //// Weiterverarbeitung des Outputs
                //ParseDiskListOutput(output);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void ParseDiskListOutput(string output)
        {
            Main_treeView.Nodes.Clear();
            string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                if (line.StartsWith("  Disk"))
                {
                    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 2 && parts[1] != "0") // Exclude Disk 0
                    {
                        TreeNode diskNode = new TreeNode($"Disk {parts[1]} - {parts[3]} {parts[4]}");
                        diskNode.Tag = parts[1]; // Store disk number for later use
                        Main_treeView.Nodes.Add(diskNode);

                        // Now retrieve partitions for this disk
                        RetrieveAndAddPartitions(diskNode);
                    }
                }
            }
        }

        private void RetrieveAndAddPartitions(TreeNode diskNode)
        {
            string diskNumber = diskNode.Tag.ToString();

            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "diskpart.exe";
                process.StartInfo.Arguments = $"/c select disk {diskNumber} & list part";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                foreach (string line in lines)
                {
                    if (line.StartsWith("  Partition"))
                    {
                        string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length > 2)
                        {
                            TreeNode partNode = new TreeNode($"{parts[1]} - {parts[2]} {parts[3]} {parts[4]}");
                            diskNode.Nodes.Add(partNode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}