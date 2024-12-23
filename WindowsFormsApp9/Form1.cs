using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        private MemoryManager _memoryManager = new MemoryManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) //MC
        {
            _memoryManager.ClearMemory();
            textBox5.Text = "";
            textBox4.Text= "";
            textBox3.Text= "";
            textBox2.Text = "";
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e) //MR
        {
            double memoryValue = _memoryManager.RecallMemory();
            textBox1.Text = memoryValue.ToString();

        }

        private void button4_Click(object sender, EventArgs e)//M+
        {
            double currentValue = double.Parse(textBox1.Text);
            _memoryManager.AddToMemory(currentValue);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)//M-
        {
            double currentValue = double.Parse(textBox1.Text);
            _memoryManager.SubtractFromMemory(currentValue);
        }

        private void button6_Click(object sender, EventArgs e)//MS
        {
            double currentValue = double.Parse(textBox1.Text);
            _memoryManager.StoreToMemory(currentValue);
        }

        private void button7_Click(object sender, EventArgs e) // ML
        {
            // 메모리 값 리스트 가져오기
            List<double> memoryValues = _memoryManager.GetMemoryValues();

            // 리스트가 null이거나 비어 있으면 처리 중단
            if (memoryValues == null || memoryValues.Count == 0)
            {
                MessageBox.Show("메모리에 값이 없습니다.");
                return;
            }

            // 리스트 크기가 4개를 초과하면 마지막 값 제거
            while (memoryValues.Count > 4)
            {
                memoryValues.RemoveAt(memoryValues.Count - 1);
            }

            // 리스트박스를 초기화 및 업데이트
            listBox1.Items.Clear();
            foreach (var value in memoryValues)
            {
                listBox1.Items.Add(value.ToString());
            }

            // 리스트 크기에 따라 텍스트박스 값 업데이트
            textBox5.Text = memoryValues.Count > 0 ? memoryValues[0].ToString() : string.Empty;
            textBox4.Text = memoryValues.Count > 1 ? memoryValues[1].ToString() : string.Empty;
            textBox3.Text = memoryValues.Count > 2 ? memoryValues[2].ToString() : string.Empty;
            textBox2.Text = memoryValues.Count > 3 ? memoryValues[3].ToString() : string.Empty;
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
