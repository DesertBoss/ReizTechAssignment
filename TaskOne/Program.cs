using System;

namespace TaskOne {
	class Program {
		static void Main (string[] args) {
		Start:
			Console.Write ("Enter Time (hour:minute): ");
			string input = Console.ReadLine ();
			DateTime dateTime;
			bool suc = DateTime.TryParse (input, out dateTime);
			if (!suc) {
				Console.WriteLine ("Invalid input! \n");
				goto Start;
			}
			Console.WriteLine ($"Angle between hours arrow and minutes arrow is {AngleBetweenClockHands (dateTime)} degrees");
			Console.ReadKey ();
		}

		static float AngleBetweenClockHands (DateTime time) {
			int hour = time.Hour <= 12 ? time.Hour : time.Hour - 12;
			int minute = time.Minute;
			float angle = (minute * (360 / 60)) - ((hour * (360 / 12)) + (minute * (360 / 12 / 60f)));
			angle = Math.Abs (angle);
			angle = Math.Min (angle, 360 - angle);
			return angle;
		}
	}
}
