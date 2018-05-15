using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThoughGame
{
    public partial class Form1 : Form
    {
        StringBuilder sb = new StringBuilder();
        GamingService service;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            requestTypeCombo.SelectedIndex = 0;

            service = new GamingService();
        }

        private void BtnSubmitRequest_Click(object sender, EventArgs e)
        {


            var response = service.InvokeService(requestTypeCombo.Text);

            txtServiceResponse.Text = sb.Append(Environment.NewLine + response.jsonResponse + Environment.NewLine).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var response = service.InvokeService("Input");
            txtServiceResponse.Text = sb.Append(Environment.NewLine + response.jsonResponse + Environment.NewLine).ToString();
            response = service.InvokeService("output");
            txtServiceResponse.Text = sb.Append(Environment.NewLine + response.jsonResponse + Environment.NewLine).ToString();

            label1.Text = service.gameModelInfo.sampleInput.input.Count.ToString();
        }
    }

}
