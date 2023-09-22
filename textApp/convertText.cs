using System;
namespace textApp
{
	public class convertText: userSettings
	{
		private string name;
		private string age;
		private string prolevel;

		public convertText( string name,string age, string prolevel): base (userName,userAge,proLevel) // not sure why this is not taking the base variables
			// further when changing userSettings to abstract insitalising the user did not like the abstract class.
		{


		}

		public virtual void test(){
			Console.WriteLine($"DOes this work? {}");
			}
	}
}

