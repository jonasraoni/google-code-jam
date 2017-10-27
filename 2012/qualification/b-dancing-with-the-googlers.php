<?php
set_time_limit(0);

$inPath = 'B.in.txt';
if($in = fopen($inPath, 'r')){
	if($out = fopen(str_replace('.in', '.out', $inPath), 'w+')){
		for($CASE = -1, $CASES = +fgets($in); ++$CASE < $CASES && !feof($in);){
			$s = fgets($in);
			preg_match_all('/\d+/', $s, $m);
			$m = $m[0];
			$N = array_shift($m);
			$S = array_shift($m);
			$p = array_shift($m);
			$score = $m;

			$surprise = $best = 0;
			foreach($score as $i => $points){
				if(($points - $p) >> 1 >= max(0, $p - 2)){
					++$best;
					$points > 1 && $points < 29 && $points - ((($points - (floor($points / 3))) >> 1) + floor($points / 3)) < $p && ++$surprise;
				}
			}
			fputs($out, 'Case #' . ($CASE + 1) . ': '. ($best - ($S < $surprise ? max(0, $surprise - $S) : 0)) . "\n");
		}
		//*
		echo '<code>';
		rewind($out);
		fpassthru($out);
		echo '</code>';
		fclose($out);
		//*/
	}
	fclose($in);
}
?>