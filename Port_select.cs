using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
using System.IO;

namespace LED_Race
{
    public partial class Port_select : Form
    {
        public Port_select()
        {
            InitializeComponent();
        }

        private void Port_select_Load(object sender, EventArgs e)
        {
            var deviceNameList = new System.Collections.ArrayList();
            var check = new System.Text.RegularExpressions.Regex("(COM[1-9][0-9]?[0-9]?)");

            ManagementClass mcPnPEntity = new ManagementClass("WIN32_PnPEntity");
            ManagementObjectCollection manageObjCol = mcPnPEntity.GetInstances();

            // すべてのPnPデバイスを探索しシリアル通信が行われるデバイスを随時追加する
            foreach(ManagementObject manageObj in manageObjCol)
            {
                // Nameプロパティを取得
                var namePropertyValue = manageObj.GetPropertyValue("Name");
                if(namePropertyValue == null)
                {
                    continue;
                }

                // Nameプロパティ文字列の一部が"(COM1)~(COM999)"と一致するときに追加
                string name = namePropertyValue.ToString();
                if (check.IsMatch(name))
                {
                    deviceNameList.Add(name);
                }
            }

            // COM番号の表示
            if(deviceNameList.Count > 0)
            {
                string[] deviceNames = new string[deviceNameList.Count];
                int index = 0;
                int index1 = 0;
                int index2 = 0;
                foreach(var name in deviceNameList)
                {
                    deviceNames[index] = name.ToString();
                    Console.WriteLine(deviceNames[index]);
                    comboBox1.Items.Add(deviceNames[index]);
                    comboBox2.Items.Add(deviceNames[index]);

                    // if (deviceNames[index] == "USB Serial Port (COM3)")
                    // {
                    //    index1 = index;
                    // }
                    // if (deviceNames[index] == "USB Serial Port (COM4)")
                    // {
                    //     index2 = index;
                    // }
                    if (deviceNames[index] == "USB シリアル デバイス (COM3)")
                    {
                        index1 = index;
                    }
                    if (deviceNames[index] == "USB シリアル デバイス (COM4)")
                    {
                        index2 = index;
                    }
                    index++;
                }
                comboBox1.SelectedIndex = index1;
                comboBox2.SelectedIndex = index2;
                //comboBox1.Items.AddRange(deviceNames);
                //comboBox2.Items.AddRange(deviceNames);
                //return deviceNames;
            }
            else // 使用可能なポートがない場合
            {
                MessageBox.Show("ポートが使用できません。");
                System.Threading.Thread.Sleep(5000);
                Application.Exit(); // アプリを終了
                // return null;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem1 = comboBox1.SelectedItem.ToString();
            
            for(int i = 0; i < 20; i++)
            {
                if (selectedItem1 == "USB Serial Port (COM" + i.ToString() + ")")
                {
                    Program.port1 = "COM" + i.ToString();
                    Console.WriteLine(Program.port1);
                    break;
                }
                else if (selectedItem1 == "USB シリアル デバイス (COM" + i.ToString() + ")")
                {
                    Program.port1 = "COM" + i.ToString();
                    Console.WriteLine(Program.port1);
                    break;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem2 = comboBox2.SelectedItem.ToString();
            for (int i = 0; i < 20; i++)
            {
                if (selectedItem2 == "USB Serial Port (COM" + i.ToString() + ")")
                {
                    Program.port2 = "COM" + i.ToString();
                    Console.WriteLine(Program.port2);
                    break;
                }
                else if (selectedItem2 == "USB シリアル デバイス (COM" + i.ToString() + ")")
                {
                    Program.port2 = "COM" + i.ToString();
                    Console.WriteLine(Program.port2);
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Program.port1 == Program.port2)
            {
                label2.Visible = true;
            }
            else
            {
                // txtファイルの書き込み
                DateTime dt = DateTime.Now;
                string filename2 = @"C:\Users\s2-de\Documents\LEDレース\log\log_" + dt.ToString("yyyyMMdd") + ".txt";

                StreamWriter file2 = new StreamWriter(filename2, true, Encoding.UTF8);
                file2.WriteLine(string.Format("{0}, {1}", dt.ToString("yyyyMMddHHmmss"), "Port_selected: port1: " + Program.port1.ToString() + ", port2: " + Program.port2.ToString()));
                file2.Close();

                // 待機画面の表示
                Wait_Window wait = new Wait_Window();
                wait.Show();
                // 待機画面を隠す
                Hide();
            }
        }
    }
}
