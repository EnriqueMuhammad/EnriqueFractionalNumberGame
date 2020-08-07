using EnriqueMath;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnriqueFractionalNumberGame
{
	public partial class FormFractionalNumberGame : Form
	{
		public FormFractionalNumberGame()
		{
			InitializeComponent();
		}

		Random rnd = new Random();
		int num1, num2, denom1, denom2,operators,score;
		string operationString;
		EnriqueFractionalNumber koreksi;

		private void GenerateRandomEquation()
		{
			num1 = rnd.Next(1, 101);
			num2 = rnd.Next(1, 101);
			denom1 = rnd.Next(1, 101);
			denom2 = rnd.Next(1, 101);
			operators = rnd.Next(1, 5);

			EnriqueFractionalNumber fract1 = new EnriqueFractionalNumber(num1, denom1);
			EnriqueFractionalNumber fract2 = new EnriqueFractionalNumber(num2, denom2);

			switch (operators)
			{
				case 1:
					operationString = "+";
					koreksi = fract1 + fract2;
					break;

				case 2:
					operationString = "-";
					koreksi = fract1 - fract2;
					break;

				case 3:
					operationString = "/";
					koreksi = fract1 / fract2;
					break;

				case 4:
					operationString = "*";
					koreksi = fract1 * fract2;
					break;
			}

			labelNum1.Text = fract1.Numerator.ToString();
			labelDenom1.Text = fract1.Denominator.ToString();
			labelNum2.Text = fract2.Numerator.ToString();
			labelDenom2.Text = fract2.Denominator.ToString();
			labelOperator.Text = operationString;
		}

		private void FormFractionalNumberGame_Load(object sender, EventArgs e)
		{
			GenerateRandomEquation();
		}

		private void buttonCek_Click(object sender, EventArgs e)
		{
			EnriqueFractionalNumber fractResult = new EnriqueFractionalNumber(int.Parse(textBoxAnswerNum.Text), int.Parse(textBoxAnswerDenom.Text));
			bool result = koreksi.IsEqual(fractResult);

			if(result)
			{
				MessageBox.Show("Jawaban benar");
				score += 10;
			}
			else
			{
				MessageBox.Show("Jawaban salah");
			}

			labelScore.Text = score.ToString();
			GenerateRandomEquation();
			textBoxAnswerNum.Text = textBoxAnswerDenom.Text = "";
		}

		private void buttonRestart_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("Are you sure to restart?", "Confirmation", MessageBoxButtons.YesNo);

			if (dr == DialogResult.Yes)
			{
				score = 0;
				labelScore.ToString();
				textBoxAnswerNum.Text = textBoxAnswerDenom.Text = "";
				GenerateRandomEquation();
			}

		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
