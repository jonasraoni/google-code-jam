using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CodeJAM {
	public partial class A : System.Web.UI.Page {
		public void O(params object[] o) {
			for(IEnumerator x = o.GetEnumerator(); x.MoveNext(); Response.Write(x.Current + ""))
				;
			Response.Write("<br>");
		}

		protected void Page_Load(object sender, EventArgs e) {
			DateTime start = DateTime.Now;

			string inPath = "d:/www/etc/2013A/A.in.txt";
			using(StreamReader input = File.OpenText(inPath)){
				using(StreamWriter output = new StreamWriter(new FileStream(inPath.Replace(".in", ".out"), FileMode.Create))){
					for(int CASE = -1, CASES = int.Parse(input.ReadLine()); ++CASE < CASES && !input.EndOfStream;){

						Match m = Regex.Match(input.ReadLine(), "\\d+");

						ulong radius = ulong.Parse(m.Captures[0].Value),
							paint = ulong.Parse(m.NextMatch().Captures[0].Value);

						int count = 0;
						radius += 1;
						do {
							++count;
							paint -= radius * radius - ((radius - 1) * (radius - 1));
							radius += 2;
						}
						while(paint >= radius * radius - ((radius - 1) * (radius - 1)));

						output.WriteLine("Case #" + (CASE + 1) + ": " + count);
 					}
				}
			}
			Response.ContentType = "text/plain";
			Response.Write((DateTime.Now - start).ToString() + "\n");
			Response.Write(File.ReadAllText("d:/www/etc/2013A/A.out.txt"));
		}
	}
}