<?php
if($argc > 1 && $in = fopen($s = $argv[1], 'r')){
	if($out = fopen(str_replace('.in', '.out', $s), 'w')){
		for($i = 0, $l = +fgets($in); $i < $l && !feof($in);){
			fscanf($in, '%d %d', $snappers, $snaps);
			fputs($out, 'Case #' . ++$i . ': '. (($snaps + 1) % pow(2, $snappers) ? 'OFF' : 'ON') . "\n");
		}
		fclose($out);
	}
	fclose($in);
}
?>