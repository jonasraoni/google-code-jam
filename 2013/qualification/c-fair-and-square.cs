using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CodeJAM {
	public partial class B : System.Web.UI.Page {
		public void O(params object[] o) {
			for(IEnumerator x = o.GetEnumerator(); x.MoveNext(); Response.Write(x.Current + ""))
				;
			Response.Write("<br>");
		}

		public bool isPalindrome(int n) {
			string s = n + "";
			for(int i = 0, l = s.Length; i < l / 2; i++)
				if(s[i] != s[l - 1 - i])
					return false;
			return true;
		}

		protected void Page_Load(object sender, EventArgs e) {
			DateTime start = DateTime.Now;
			string inPath = "d:/www/etc/2013/B.in.txt";
			using(StreamReader input = File.OpenText(inPath)){
				using(StreamWriter output = new StreamWriter(new FileStream(inPath.Replace(".in", ".out"), FileMode.Create))){
					for(int CASE = -1, CASES = int.Parse(input.ReadLine()); ++CASE < CASES && !input.EndOfStream;){
						Match m = Regex.Match(input.ReadLine(), "\\d+");

						int A = int.Parse(m.Captures[0].Value), 
							B = int.Parse(m.NextMatch().Captures[0].Value),
							count = 0;

						double sq = 0;
						for(int i = B + 1; --i >= A;)
							if(isPalindrome(i) && (sq = Math.Sqrt(i)) == (int)sq && isPalindrome((int)sq))
								++count;
						
						output.WriteLine("Case #" + (CASE + 1) + ": " + count);
 					}
				}
			}
			Response.ContentType = "text/plain";
			Response.Write((DateTime.Now - start).ToString() + "\n");
			Response.Write(File.ReadAllText("d:/www/etc/2013/B.out.txt"));
		}
	}
}