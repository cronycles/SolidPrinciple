using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
	public class Liskov : DisplayableSample
	{
		public string RunWrongApproach()
		{
			var explanation = new StringBuilder();
			explanation.AppendLine($"--- WRONG APPROACH ---");

			var rectangle = new WrongApproach.Rectangle { Height = 10, Width = 3 };
			explanation.AppendLine($"We have created a rectangle of 10x3: Height[{rectangle.Height}] Width[{rectangle.Width}] Area[{rectangle.GetArea()}]");

			var square = new WrongApproach.Square { Height = 10, Width = 10 };
			explanation.AppendLine($"And a square of 10x10: Height[{ square.Height}] Width[{ square.Width}] Area[{ square.GetArea()}]");

			var approach = new WrongApproach();
			var rectangleTest = approach.ValidateAreaCalculation(new WrongApproach.Rectangle());
			var squareTest = approach.ValidateAreaCalculation(new WrongApproach.Square());

			explanation.AppendLine($"Using both through their base class, we test that GIVEN sides of 6x8 WHEN we get the area THEN we get 48");
			explanation.AppendLine($"\tRectangle object test: {( rectangleTest ? "passed" : "NOT passed")}");
			explanation.AppendLine($"\tSquare object test: {(squareTest ? "passed" : "NOT passed")}");
			explanation.AppendLine();
			explanation.AppendLine($"In real life a square is also a rectangle, but that scenario not be always coded that way unless that \"square\" and \"rectangle\" are treated as properties of an object called, for instance, \"shape\"");

			return explanation.ToString();
		}

		public string RunCorrectApproach()
		{
			var explanation = new StringBuilder();
			explanation.AppendLine($"--- CORRECT APPROACH ---");

			var rectangle = new CorrectApproach.Rectangle { Height = 10, Width = 3 };
			explanation.AppendLine($"We have created a rectangle of 10x3: Height[{rectangle.Height}] Width[{rectangle.Width}] Area[{rectangle.GetArea()}]");

			var square = new CorrectApproach.Square { SideLength = 10 };
			explanation.AppendLine($"And a square of 10x10: Size of sides[{ square.SideLength}] Area[{ square.GetArea()}]");

			var approach = new CorrectApproach();
			var rectangleTest = approach.ValidateAreaCalculation(rectangle, 30);
			var squareTest = approach.ValidateAreaCalculation(square, 100);

			explanation.AppendLine($"Using both through their interface, we test that GIVEN sides of 10x3 rectangle WHEN we get the area THEN we get 30");
			explanation.AppendLine($"\tRectangle object test: {(rectangleTest ? "passed" : "NOT passed")}");
			explanation.AppendLine($"...and that GIVEN a 10x10 square WHEN we get the area THEN we get 100");
			explanation.AppendLine($"\tSquare object test: {(squareTest ? "passed" : "NOT passed")}");
			explanation.AppendLine();

			return explanation.ToString();
		}

		public string GetHeader()
		{
			var result = "Liskov.cs";
			result += Environment.NewLine + "objects in a program should be replaceable with instances of their subtypes without altering the correctness of that program.";
			return result;
		}

		public string Run()
		{
			var result = this.GetHeader();
			result += Environment.NewLine + Environment.NewLine + RunWrongApproach();
			result += Environment.NewLine + Environment.NewLine + RunCorrectApproach();

			return result;
		}

		private class WrongApproach
		{
			public bool ValidateAreaCalculation(Rectangle objectToValidate)
			{
				objectToValidate.Height = 6;
				objectToValidate.Width = 8;
				return objectToValidate.GetArea() == 48;
			}

			public class Rectangle
			{
				public virtual int Height { get; set; }
				public virtual int Width { get; set; }
				public int GetArea()
				{
					return this.Height * this.Width;
				}
			}

			public class Square : Rectangle
			{
				private int _height, _width;

				public override int Height
				{
					get { return this._height; }
					set { this._height = this._width = value; }
				}

				public override int Width
				{
					get { return this._width; }
					set { this._height = this._width = value; }
				}
			}
		}

		private class CorrectApproach
		{
			public bool ValidateAreaCalculation(Shape shape, int expectedArea)
			{
				return shape.GetArea() == expectedArea;
			}

			public interface Shape
			{
				int GetArea();
			}

			public class Rectangle : Shape
			{
				public int Height { get; set; }
				public int Width { get; set; }
				public int GetArea()
				{
					return this.Height * this.Width;
				}
			}

			public class Square : Shape
			{
				public int SideLength { get; set; }
				public int GetArea()
				{
					return this.SideLength * this.SideLength;
				}
			}

		}

	}

	
}
