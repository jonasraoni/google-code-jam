using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CodeJAM {
	public partial class C : System.Web.UI.Page {
		public void O(params object[] o) {
			for(IEnumerator x = o.GetEnumerator(); x.MoveNext(); Response.Write(x.Current + ""))
				;
			Response.Write("<br>");
		}

		protected void Page_Load(object sender, EventArgs e) {
			DateTime start = DateTime.Now;
			string inPath = "d:/www/etc/2013/C.in.txt";
			using(StreamReader input = File.OpenText(inPath)){
				using(StreamWriter output = new StreamWriter(new FileStream(inPath.Replace(".in", ".out"), FileMode.Create))){
					for(int CASE = -1, CASES = int.Parse(input.ReadLine()); ++CASE < CASES && !input.EndOfStream;){
						Match m = Regex.Match(input.ReadLine(), "\\d+");

						int N = int.Parse(m.Captures[0].Value), 
							M = int.Parse(m.NextMatch().Captures[0].Value);

						int[,] table = new int[N, M];
						Dictionary<int, List<int>> map = new Dictionary<int,List<int>>();
						for(int l = -1; ++l < N; ) {
							m = Regex.Match(input.ReadLine(), "\\d+");
							for(int c = -1; ++c < M; ) {
								table[l, c] = int.Parse(m.Captures[0].Value);
								if(!map.ContainsKey(table[l, c]))
									map[table[l, c]] = new List<int>();
								map[table[l, c]].Add((l * M) + c);
								m = m.NextMatch();
							}
						}
						List<int> heights = new List<int>(map.Keys);
						heights.Sort((a, b) => {
							return b - a;
						});

						int current = heights[0];
						heights.RemoveAt(0);
						bool isPossible = true;
					Quit:
						foreach(int height in heights) {
							if(!isPossible)
								break;

							while(map[height].Count > 0) {
								bool hasVertical = true, hasHorizontal = true;
								int cell = map[height][0], fixedColumn = cell % M, fixedLine = cell / M;
								map[height].RemoveAt(0);
								for(int l = fixedLine, c = -1; ++c < M; ) {
									if(table[l, c] > height) {
										hasHorizontal = false;
										break;
									}
								}
								for(int c = fixedColumn, l = -1; ++l < N; ) {
									if(table[l, c] > height) {
										hasVertical = false;
										break;
									}
								}

								if(!hasHorizontal && !hasVertical) {
									isPossible = false;
									goto Quit;
								}

								foreach(int c in new List<int>(map[height])) {
									if(hasVertical && c % M == fixedColumn)
										map[height].Remove(c);
									if(hasHorizontal && c / M == fixedLine)
										map[height].Remove(c);
								}
							}
						}
														
						output.WriteLine("Case #" + (CASE + 1) + ": " + (isPossible ? "YES" : "NO"));
 					}
				}
			}
			Response.ContentType = "text/plain";
			Response.Write((DateTime.Now - start).ToString() + "\n");
			Response.Write(File.ReadAllText("d:/www/etc/2013/C.out.txt"));
		}
	}
}