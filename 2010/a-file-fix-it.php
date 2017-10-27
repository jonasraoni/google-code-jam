<?php
header('content-type: text/plain');
//$in = 'A-small-attempt0.in';
$inPath = 'A-large.in';
if($in = fopen($inPath, 'r')){
	if($out = fopen(str_replace('.in', '.out', $inPath), 'w+')){
		for($CASE = -1, $CASES = +fgets($in); ++$CASE < $CASES && !feof($in);){
			fscanf($in, '%d %d', $N, $M);
			$e = array();
			for($i = $N; $i--;)
				$e[] = fgets($in);

			$root = array();
			foreach($e as $n){
				$c = &$root;
				foreach(explode('/', trim($n, "/\n")) as $n){
					isset($c[$n]) || $c[$n] = array();
					$c = &$c[$n];
				}
			}

			$mk = 0;
			for($i = $M; $i--;){
				$n = fgets($in);
				$ok = 1;
				$c = &$root;
				foreach(explode('/', trim($n, "/\n")) as $n){
					if(!isset($c[$n])){
						$c[$n] = array();
						++$mk;
					}
					$c = &$c[$n];
				}
			}
			fputs($out, 'Case #' . ($CASE + 1) . ': '. $mk . "\n");
		}
		/*echo '<code>';
		rewind($out);
		fpassthru($out);
		echo '</code>';*/
		fclose($out);
	}
	fclose($in);
}
?>