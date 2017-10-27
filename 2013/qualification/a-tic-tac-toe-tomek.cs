using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CodeJAM {
	public partial class A : System.Web.UI.Page {
		public void O(params object[] o) {
			for(IEnumerator x = o.GetEnumerator(); x.MoveNext(); Response.Write(x.Current + ""))
				;
			Response.Write("<br>");
		}
		public enum Type {
			X,
			O,
			T,
			Empty,
			Unassigned
		}

		public enum Result {
			WonX,
			WonO,
			Draw,
			NotCompleted,
			Unknown
		}

		public Dictionary<Type, int> getCounter() {
			return new Dictionary<Type,int>(){
				{Type.T, 0},
				{Type.X, 0},
				{Type.O, 0},
				{Type.Empty, 0}
			};
		}

		public Result checkCounter(Dictionary<Type, int> counter) {
			int required = BLOCKS - counter[Type.T];
			if(counter[Type.O] == required)
				return Result.WonO;
			else if(counter[Type.X] == required)
				return Result.WonX;
			return Result.Unknown;
		}

		public Type translate(char n){
			switch(n){
				case 'X':
					return Type.X;
				case 'O':
					return Type.O;
				case 'T':
					return Type.T;
				case '.':
					return Type.Empty;
			}
			throw new Exception("Unexpected entry");
		}
		
		public string translateResult(Result r){
			switch(r){
				case Result.Draw:
					return "Draw";
				case Result.WonO:
					return "O won";
				case Result.WonX:
					return "X won";
				case Result.NotCompleted:
					return "Game has not completed";
			}
			throw new Exception("Unexpected entry");
		}
		

		const int BLOCKS = 4;

		protected void Page_Load(object sender, EventArgs e) {

			DateTime start = DateTime.Now;
			string inPath = "d:/www/etc/2013/A.in.txt";
			using(StreamReader input = File.OpenText(inPath)){
				using(StreamWriter output = new StreamWriter(new FileStream(inPath.Replace(".in", ".out"), FileMode.Create))){
					for(int CASE = -1, CASES = int.Parse(input.ReadLine()); ++CASE < CASES && !input.EndOfStream;){
						bool hasEmpty = false;
						Type[,] table = new Type[4, 4];
						for(int c = -1, l = -1; ++l < BLOCKS; ) {
							foreach(char n in input.ReadLine()){
								if(translate(n) == Type.Empty)
									hasEmpty = true;
								table[l, ++c] = translate(n);
							}
							c = -1;
						}
						input.ReadLine();

						Result result = Result.Unknown;

						//diagonal
						Dictionary<Type, int> counter = getCounter();
						for(int c = -1, l = -1; ++l < BLOCKS && ++c < BLOCKS; )
							++counter[table[l, c]];

						if((result = checkCounter(counter)) == Result.Unknown) {
							counter = getCounter();
							for(int c = -1, l = BLOCKS; --l >= 0 && ++c < BLOCKS; )
								++counter[table[l, c]];
						}

						if((result = checkCounter(counter)) == Result.Unknown) {
							for(int l = -1; ++l < BLOCKS; ) {
								counter = getCounter();
								for(int c = -1; ++c < BLOCKS; )
									++counter[table[l, c]];

								if((result = checkCounter(counter)) != Result.Unknown)
									break;
							}
						}

						if(result == Result.Unknown) {
							for(int c = -1; ++c < BLOCKS; ) {
								counter = getCounter();
								for(int l = -1; ++l < BLOCKS; )
									++counter[table[l, c]];

								if((result = checkCounter(counter)) != Result.Unknown)
									break;
							}
						}
						
						if(result == Result.Unknown)
							result = hasEmpty ? Result.NotCompleted : Result.Draw;

						output.WriteLine("Case #" + (CASE + 1) + ": " + translateResult(result));
 					}
				}
			}
			Response.ContentType = "text/plain";
			Response.Write((DateTime.Now - start).ToString() + "\n");
			Response.Write(File.ReadAllText("d:/www/etc/2013/A.out.txt"));
		}
	}
}