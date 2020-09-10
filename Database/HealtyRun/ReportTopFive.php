<?php

include("Connect.php");

	$data = array();
	$all_data = array();

	$sql=" SELECT MAX(score.Value_score) as MaxScore, score.UserName, player.UserName
	      FROM score INNER JOIN player ON score.UserName = player.UserName
	      GROUP BY score.UserName
	      ORDER BY MaxScore DESC
	      LIMIT 5";

	$res = mysql_query($sql);
	while ($row = mysql_fetch_assoc($res)) {
		$data = array($row);
		$all_data = array_merge($all_data, $data);
	}

	$retrun["TopFive"] = $all_data;
	echo json_encode($retrun);

?>