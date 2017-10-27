<?php
set_time_limit(0);

$map = array(
	'z' => 'q',
	'o' => 'e',
	'a' => 'y',
	'q' => 'z' //missing input/output map matched
);
foreach(array(
	'our language is impossible to understand' => 'ejp mysljylc kd kxveddknmc re jsicpdrysi',
	'there are twenty six factorial possibilities' => 'rbcpc ypc rtcsra dkh wyfrepkym veddknkmkrkcd',
	'so it is okay if you want to just give up' => 'de kr kd eoya kw aej tysr re ujdr lkgc jv'
) as $a => $b)
	for($i = -1, $l = strlen($a); ++$i < $l; $map[$b[$i]] = $a[$i]);

$inPath = 'A.in.txt';
if($in = fopen($inPath, 'r')){
	if($out = fopen(str_replace('.in', '.out', $inPath), 'w+')){
		for($CASE = -1, $CASES = +fgets($in); ++$CASE < $CASES && !feof($in);){
			$s = trim(fgets($in));
			for($i = -1, $l = strlen($s); ++$i < $l; $s[$i] = $map[$s[$i]]);
			fputs($out, 'Case #' . ($CASE + 1) . ': '. $s . "\n");
		}
		/*
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