<?php
set_time_limit(0);

$inPath = 'C.in.txt';
if($in = fopen($inPath, 'r')){
	if($out = fopen(str_replace('.in', '.out', $inPath), 'w+')){
		for($CASE = -1, $CASES = +fgets($in); ++$CASE < $CASES && !feof($in);){
			preg_match_all('/\d+/', fgets($in), $m);
			$A = array_shift($m[0]);
			$B = array_shift($m[0]);

			$c = 0;
			$cache = array();
			if(strlen($B) > 1)
				for($i = $A - 1, $l = $B; ++$i <= $l;){
					$j = count($n = str_split($i)) - 1;
					do{
						array_unshift($n, array_pop($n));
						if($n[0] == 0)
							continue;
						if(($s = +implode('', $n)) <= $B && $s > $i && !isset($cache[$s . $i])){
							++$c;
							$cache[$s . $i] = 0;
						}
					}
					while(--$j);
				}
			fputs($out, 'Case #' . ($CASE + 1) . ': '. $c . "\n");
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