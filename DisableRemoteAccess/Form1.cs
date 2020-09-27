
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tik4net;
using tik4net.Objects;
using tik4net.Objects.Interface;
using tik4net.Objects.Interface.Bridge;
using tik4net.Objects.Ip.Firewall;
using tik4net.Objects.Ip.Hotspot;
using tik4net.Objects.System;
using Color = System.Drawing.Color;

namespace DisableRemoteAccess
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string HOST = "name.server.com";
        public string USER = "apiuser";
        public string PASS = "password";
        public string route = "192.168.0.0/24";
        public string nameRule = "Demo";

        private void button1_Click(object sender, EventArgs e) 
        {
            try
            {
                using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
                {

                    connection.Open(HOST, USER, PASS);

                    int i = 0;

                    var natRule = connection.CreateCommandAndParameters("/ip/route/print", "dst-address", route).ExecuteList();
                    var value = natRule.Count();
                    if (value == i)
                    {
                        Color colorOff_n = Color.Red;
                        label1.ForeColor = colorOff_n;
                        label1.Text = ("Сервер уже отключен,\n      включите его.");
                        return;
                    }
                }
            }
            catch
            {
                Color colorOff_n = Color.Red;
                label1.ForeColor = colorOff_n;
                label1.Text = ("Возникло исключение!\nИмя сервера или порт \nне доступты!");
            }
                
            try
            {
                using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
                {
                    connection.Open(HOST, USER, PASS);

                    var natRule = connection.CreateCommandAndParameters("/ip/address/print", "comment", nameRule).ExecuteList();
                    var id = natRule.Single().GetId();

                    var disableRule = connection.CreateCommandAndParameters("/ip/address/disable", TikSpecialProperties.Id, id);
                    disableRule.ExecuteNonQuery();
                    Color colorOff = Color.Red;
                    label1.ForeColor = colorOff;
                    label1.Text = ("Вы отключили сервер.");
                }
            }
            catch
            {
                Color colorOff_n = Color.Red;
                label1.ForeColor = colorOff_n;
                label1.Text = ("Возникло исключение!\nИмя сервера или порт \nне доступты!");
            }           
        }       
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
                {
                    connection.Open(HOST, USER, PASS);

                    int n = 1;

                    var natRule = connection.CreateCommandAndParameters("/ip/route/print", "dst-address", route).ExecuteList();
                    var value = natRule.Count();
                    if (value == n)
                    {
                        Color colorOn_n = Color.Blue;
                        label1.ForeColor = colorOn_n;
                        label1.Text = ("Сервер уже включен.");
                        return;
                    }
                }
            }
            catch
            {
                Color colorOff_n = Color.Red;
                label1.ForeColor = colorOff_n;
                label1.Text = ("Возникло исключение!\nИмя сервера или порт \nне доступты!");
            }

            try
            {
                using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
                {
                    connection.Open(HOST, USER, PASS);

                    int n = 1;

                    var natRule = connection.CreateCommandAndParameters("/ip/route/print", "dst-address", route).ExecuteList();
                    var value = natRule.Count();
                    if (value == n)
                    {
                        Color colorOn_n = Color.Blue;
                        label1.ForeColor = colorOn_n;
                        label1.Text = ("Сервер уже включен.");
                        return;
                    }
                }
            }
            catch
            {
                label1.Text = ("Возникло исключение");
            }

            try
            {
                using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
                {

                    connection.Open(HOST, USER, PASS);

                    var natRule = connection.CreateCommandAndParameters("/ip/address/print", "comment", nameRule).ExecuteList();
                    var id = natRule.Single().GetId();
                    var enableRule = connection.CreateCommandAndParameters("/ip/address/enable", TikSpecialProperties.Id, id);
                    enableRule.ExecuteNonQuery();

                    Color colorOn = Color.Blue;
                    label1.ForeColor = colorOn;
                    label1.Text = ("Вы включили сервер.");
                }
            }
            catch
            {
                Color colorOff_n = Color.Red;
                label1.ForeColor = colorOff_n;
                label1.Text = ("Возникло исключение!\nИмя сервера или порт \nне доступты!");
            }           
        } 
        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
                {
                    connection.Open(HOST, USER, PASS);

                    int n = 1;

                    var natRule = connection.CreateCommandAndParameters("/ip/route/print", "dst-address", route).ExecuteList();
                    var value = natRule.Count();
                    if (value == n)
                    {
                        Color colorOn = Color.Blue;
                        label1.ForeColor = colorOn;
                        label1.Text = ("Текущий статус сервера\n          ДОСТУПЕН!");
                    }
                }
            }
            catch
            {
                Color colorOff_n = Color.Red;
                label1.ForeColor = colorOff_n;
                label1.Text = ("Возникло исключение!\n Имя сервера или порт \nне доступты!");
            }

            try
            {
                using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
                {
                    connection.Open(HOST, USER, PASS);

                    int i = 0;

                    var natRule = connection.CreateCommandAndParameters("/ip/route/print", "dst-address", route).ExecuteList();
                    var value = natRule.Count();
                    if (value == i)
                    {
                        Color colorOff_n = Color.Red;
                        label1.ForeColor = colorOff_n;
                        label1.Text = ("Текущий статус сервера\n        НЕ ДОСТУПЕН!");
                    }
                }
            }
            catch
            {
                Color colorOff_n = Color.Red;
                label1.ForeColor = colorOff_n;
                label1.Text = ("Возникло исключение!\nИмя сервера или порт \nне доступты!");
            }           
        }
    }
}
