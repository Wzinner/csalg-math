﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mathematic.automatic_data_processing.modeling;
using Mathematic.utils;

namespace least_square_method
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//Создаем начальную выборку:

			List<double> X = new List<double>();
			List<double> Y = new List<double>();

			int count = 100;
			int count2 = count * count;
			double x,y;
			for (int i = 0; i < count; i++) {
				x = Math.Pow(i, 2);// (double)(i);
				y = i;// Math.Sin(i * 2 * Math.PI / 180) + GetRandom.GetNextDoubleFromRange(-0.5, 0.5);
				
				chart1.Series[0].Points.AddXY(x, y);
				
			}

			for (int i = 0; i < count2; i++) {
				x = (double)i / (double)count2+0.00001;
				X.Add(x);
				Y.Add(Math.Sqrt(x));
			}

			count = count2;

			uint order = 5;

			List<double> res = LeastSquareMethod.Solve(X, Y, order);

			//double c  =res[0];
			//Console.WriteLine(

			for (int i = 0; i < count; i++) {
				x = (double)i;
				y = 0;
				for (int j = 0; j < order; j++)
				{
					y += Math.Pow(x, j) * res[j];
				}
				//Console.WriteLine(y);
				chart1.Series[1].Points.AddXY(i, y);
			}

		}

		

	}
}